using Api.Dto;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace Api.Services;

public class AlmacenadorArchivo : IAlmacenadorArchivo
{
    private readonly string _connectionString;

    public AlmacenadorArchivo(IConfiguration configuration)
    {
        _connectionString = configuration["AzureStorages:ConnectionString"]
            ?? throw new InvalidOperationException("No se encontró la connection string de Azure Storage");
    }

    public async Task<string> SaveFile(string container, ArchivoDto dto)
    {
        var cliente = new BlobContainerClient(_connectionString, container);
        await cliente.CreateIfNotExistsAsync();

        var extension = Path.GetExtension(dto.Name);
        var nombreArchivo = $"{Guid.NewGuid()}{extension}";
        var blob = cliente.GetBlobClient(nombreArchivo);

        BlobHttpHeaders blobHttpHeaders = new();
        blobHttpHeaders.ContentType = dto.ContentType;
        await blob.UploadAsync(dto.OpenStream(), blobHttpHeaders);


        var sasBuilder = new BlobSasBuilder
        {
            BlobContainerName = container,
            BlobName = nombreArchivo,
            Resource = "b",
            ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);

        var sasUri = blob.GenerateSasUri(sasBuilder);
        return sasUri.ToString();
    }

    public async Task DeleteFile(string? ruta, string container)
    {
        if (string.IsNullOrEmpty(ruta))
        {
            return;
        }

        var cliente = new BlobContainerClient(_connectionString, container);
        await cliente.CreateIfNotExistsAsync();

        var nombreArchivo = Path.GetFileName(ruta);
        var blob = cliente.GetBlobClient(nombreArchivo);

        await blob.DeleteIfExistsAsync();
    }
}