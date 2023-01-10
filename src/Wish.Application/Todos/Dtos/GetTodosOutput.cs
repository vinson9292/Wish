using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Todos.Dto;

namespace Wish.Todos.Dtos
{
    /// <summary>
    /// GetTodosOutput
    /// </summary>
    public class GetTodosOutput
    {
        /// <summary>
        /// Todos
        /// </summary>
        public List<TodoDto> Todos { get; set; }
    }
}
