using Microsoft.EntityFrameworkCore;
using SophiaWorld.Core.Entities;
using SophiaWorld.Core.Interfaces;
using SophiaWorld.Infrastructure.Data;

namespace SophiaWorld.Infrastructure.Services
{
    public class BoardService : IBoardService
    {
        private readonly AppDbContext _context;

        public BoardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BoardPost>> GetAllAsync()
        {
            return await _context.BoardPosts
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<BoardPost?> GetByIdAsync(int id)
        {
            return await _context.BoardPosts.FindAsync(id);
        }

        public async Task AddAsync(BoardPost post)
        {
            _context.BoardPosts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BoardPost post)
        {
            _context.BoardPosts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.BoardPosts.FindAsync(id);
            if (post != null)
            {
                _context.BoardPosts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
