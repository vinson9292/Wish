using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Todos.Dtos;

namespace Wish.Todos
{
    public interface ITodosAppService : IApplicationService
    {
        GetTodosOutput GetTodos(GetTodosInput input);

        void UpdateTask(UpdateTodoInput input);

        void CreateTask(CreateTodoInput input);
    }
}
