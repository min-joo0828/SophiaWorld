using SophiaWorld.Core.Entities;

namespace SophiaWorld.Core.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardPost>> GetAllAsync();
        Task<BoardPost?> GetByIdAsync(int id);
        Task AddAsync(BoardPost post);
        Task UpdateAsync(BoardPost post);
        Task DeleteAsync(int id);
    }
}
