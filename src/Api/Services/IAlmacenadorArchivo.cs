using Api.Dto;

namespace Api.Services;

public interface IAlmacenadorArchivo
{
    Task<string> SaveFile(string container, ArchivoDto dto);
    Task DeleteFile(string? ruta, string container);
    async Task<string> Update(string? ruta, string container, ArchivoDto dto)
    {
        await DeleteFile(ruta, container);
        return await SaveFile(container, dto);
    }
}