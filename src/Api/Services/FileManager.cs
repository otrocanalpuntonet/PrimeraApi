using Api.Dto;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace Api.Services;

public class FileManager : IFileManagerxx
{
    private readonly string _connectionString;
    public FileManager(IConfiguration configuration)
    {
        _connectionString = configuration["AzureStorages:ConnectionString"] 
            ?? throw new InvalidOperationException("No se encontro la conexion para blob storage");
    }

    public Task DeleteFile(string? route, string container)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SaveFile(string container, ArchivoDto dto)
    {
        var client = new BlobContainerClient(_connectionString, container);
        await client.CreateIfNotExistsAsync();

        var extension = Path.GetExtension(dto.Name);
        var fileName = $"{Guid.NewGuid()}{extension}";
        var blob = client.GetBlobClient(fileName);

        BlobHttpHeaders blobHttpHeaders = new();
        blobHttpHeaders.ContentType = dto.ContentType;
        await blob.UploadAsync(dto.OpenStream(), blobHttpHeaders);

        var sasBuilder = new BlobSasBuilder
        {
            BlobContainerName = container,
            BlobName = fileName,
            Resource = "b",
            ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);

        var sasUri = blob.GenerateSasUri(sasBuilder);
        return sasUri.ToString();
    }
}