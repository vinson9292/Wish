using Abp.AutoMapper;
using Abp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.IRepositories;
using Wish.Todos;

namespace Wish.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// TodoRepository
    /// </summary>
    public class TodoRepository : WishRepositoryBase<Todo,int>,ITodoRepository
    {
        public TodoRepository(IDbContextProvider<WishDbContext> dbContextProvider) : base(dbContextProvider)
        { 
        
        }

        public List<Todo> GetTodos()
        {
            return GetAll().ToList();
        }

        public List<Todo> GetTodosById(int id)
        {
            var query = GetAll();
            if (id > 0)
            {
                query = query.Where(c => c.Id == id);
            }
            return query.ToList();
        }
    }
}
