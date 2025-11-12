using Microsoft.AspNetCore.Mvc;
using SophiaWorld.Core.Entities;
using SophiaWorld.Core.Interfaces;

namespace SophiaWorld.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _boardService.GetAllAsync();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BoardPost post)
        {
            if (string.IsNullOrWhiteSpace(post.Title) || string.IsNullOrWhiteSpace(post.Content))
                return BadRequest("제목과 내용을 모두 입력해주세요.");

            post.CreatedAt = DateTime.Now;
            await _boardService.AddAsync(post);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BoardPost post)
        {
            var existing = await _boardService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Title = post.Title;
            existing.Content = post.Content;
            existing.CreatedAt = DateTime.Now;

            await _boardService.UpdateAsync(existing);
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _boardService.DeleteAsync(id);
            return Ok();
        }
    }
}
