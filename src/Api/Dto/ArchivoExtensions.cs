namespace Api.Dto;

public static class ArchivoExtensions
{
    public static ArchivoDto ConvertirArchivoDTO(this IFormFile formFile)
    {
        var limite = 2 * 1024 * 1024;

        if (formFile.Length > limite)
            throw new InvalidOperationException("El archivo supera el tamaño máximo permitido (2 MB)");

        var archivo = new ArchivoDto(
            formFile.FileName,
            formFile.ContentType,
            () => formFile.OpenReadStream());

        return archivo;
    }
}