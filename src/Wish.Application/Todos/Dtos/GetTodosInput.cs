using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wish.Todos.Dtos
{
    /// <summary>
    /// GetTodosInput
    /// </summary>
    public class GetTodosInput
    {
        /// <summary>
        /// 是否作用中
        /// </summary>
        public TaskState? State { get; set; }
    }
}
