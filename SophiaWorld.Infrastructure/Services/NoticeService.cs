using Microsoft.EntityFrameworkCore;
using SophiaWorld.Core.Entities;
using SophiaWorld.Core.Interfaces;
using SophiaWorld.Infrastructure.Data;

namespace SophiaWorld.Infrastructure.Services
{
    public class NoticeService : INoticeService
    {
        private readonly AppDbContext _db;

        public NoticeService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Notice>> GetAllAsync()
        {
            return await _db.Notices.OrderByDescending(n => n.Date).ToListAsync();
        }

        public async Task<Notice?> GetByIdAsync(int id)
        {
            return await _db.Notices.FindAsync(id);
        }

        public async Task AddAsync(Notice notice)
        {
            _db.Notices.Add(notice);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notice notice)
        {
            _db.Notices.Update(notice);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notice = await _db.Notices.FindAsync(id);
            if (notice != null)
            {
                _db.Notices.Remove(notice);
                await _db.SaveChangesAsync();
            }
        }
    }
}
