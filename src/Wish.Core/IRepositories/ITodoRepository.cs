using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Todos;

namespace Wish.IRepositories
{
    /// <summary>
    /// ITodoRepository
    /// </summary>
    public interface ITodoRepository : IRepository<Todo,long>
    {
        List<Todo> GetTodos();
    }
}
