using Api.Dto;

namespace Api.Services;

public interface IFileManagerxx
{
    Task<string> SaveFile(string container, ArchivoDto dto);
    Task DeleteFile(string? route, string container);
    async Task<string> Update(string? route, string container, ArchivoDto dto)
    {
        await DeleteFile(route, container);
        return await SaveFile(container, dto);
    }
}