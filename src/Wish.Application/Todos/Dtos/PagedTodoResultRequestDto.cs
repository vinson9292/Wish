using Abp.Application.Services.Dto;

namespace Wish.Todos.Dto
{
    public class PagedTodoResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public TaskState IsActive { get; set; }
    }
}
