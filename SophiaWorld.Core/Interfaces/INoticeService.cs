using SophiaWorld.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophiaWorld.Core.Interfaces
{
    public interface INoticeService
    {
        Task<IEnumerable<Notice>> GetAllAsync();
        Task<Notice?> GetByIdAsync(int id);
        Task AddAsync(Notice notice);
        Task UpdateAsync(Notice notice);
        Task DeleteAsync(int id);
    }
}
