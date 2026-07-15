namespace Api.Dto;

public static class FileExtensions
{
    public static ArchivoDto ConvertToFileDTO(this IFormFile formFile)
    {
        var fileLimit = 2 * 1024 * 1024;

        if (formFile.Length > fileLimit)
            throw new InvalidOperationException(" El archivo supera el mimite máximo de 2MB");

        var file = new ArchivoDto(
            formFile.FileName,
            formFile.ContentType,
            () => formFile.OpenReadStream());

        return file;
    }
}