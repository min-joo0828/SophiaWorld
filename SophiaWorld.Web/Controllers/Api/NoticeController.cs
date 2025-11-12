using Microsoft.AspNetCore.Mvc;
using SophiaWorld.Core.Entities;
using SophiaWorld.Core.Interfaces;

namespace SophiaWorld.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeService _noticeService;

        public NoticeController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notices = await _noticeService.GetAllAsync();
            return Ok(notices);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Notice notice)
        {
            if (string.IsNullOrWhiteSpace(notice.Title))
                return BadRequest("제목을 입력해주세요.");

            notice.Date = DateTime.Now;
            await _noticeService.AddAsync(notice);
            return Ok(notice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Notice notice)
        {
            var existing = await _noticeService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Title = notice.Title;
            existing.Date = DateTime.Now;

            await _noticeService.UpdateAsync(existing);
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _noticeService.DeleteAsync(id);
            return Ok();
        }
    }
}
