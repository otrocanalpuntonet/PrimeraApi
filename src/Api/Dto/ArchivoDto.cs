namespace Api.Dto;

public record ArchivoDto(string Name, string ContentType, Func<Stream> OpenStream);