using System.ComponentModel.DataAnnotations;

namespace SophiaWorld.Web.Models
{
    public class NoticeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "제목을 입력해주세요.")]
        [Display(Name = "제목")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "작성일")]
        public DateTime Date { get; set; } = DateTime.Now;

        public string DateString => Date.ToString("yyyy-MM-dd");
    }

}
