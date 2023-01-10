using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Net.Mail;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Authorization.Roles;
using Wish.Authorization.Users;
using Wish.IRepositories;
using Wish.Todos;
using Wish.Todos.Dto;
using Wish.Todos.Dtos;
using Wish.Users.Dto;

namespace Wish.Todos
{
    /// <summary>
    /// TodosAppService
    /// </summary>
    public class TodosAppService : ITodosAppService
    {
        /// <summary>
        /// Logger
        /// </summary>
        public ILogger Logger { get; set; }
        //private readonly ITodoRepository _todoRepository;
        private readonly IAbpSession _session;
        private readonly ICacheManager _cacheManager;
        private readonly IObjectMapper _objectMapper;
        private readonly IEmailSender _emailSender;

        private readonly IRepository<Todo> _todoRepository;

        /// <summary>
        /// TodosAppService
        /// </summary>
        /// <param name="todoRepository"></param>
        /// <param name="session">session</param>
        /// <param name="cacheManager">cacheManager</param>
        /// <param name="objectMapper">objectMapper</param>
        /// <param name="emailSender">emailSender</param>
        public TodosAppService(
            IRepository<Todo> todoRepository, 
            IAbpSession session,
            ICacheManager cacheManager,
            IObjectMapper objectMapper,
            IEmailSender emailSender
            )
        {
            _todoRepository = todoRepository;
            Logger = NullLogger.Instance;
            _session = session;
            _cacheManager = cacheManager;
            _objectMapper = objectMapper;
            _emailSender = emailSender;
        }

        /// <summary>
        /// CreateTask
        /// </summary>
        /// <param name="input"></param>
        public void CreateTask(CreateTodoInput input)
        {
            var todo = _objectMapper.Map<Todo>(input);
            _todoRepository.InsertAsync(todo);
            Logger.Debug("Successfully inserted!");
            Logger.Debug($"_session.TenantId=>{_session.TenantId}");
            Logger.Debug($"_session.UserId=>{_session.UserId}");
            //Send a notification email
            _emailSender.Send(
                to: "vinson.tw@gmail.com",
                subject: "You have a new task!",
                body: $"A new task is assigned for you: <b>{input.Title}</b>",
                isBodyHtml: true
            );
        }

        /// <summary>
        /// GetTodos
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GetTodosOutput GetTodos(GetTodosInput input)
        {
            return new GetTodosOutput()
            {
                //Todos = _todoRepository.GetAll().Select(t => new TodoDto() { IsActive = (TaskState)t.IsActive }).ToList()
                Todos = _todoRepository.GetAll().Select(x => _objectMapper.Map<TodoDto>(x)).ToList()
            };
        }

        /// <summary>
        /// UpdateTask
        /// </summary>
        /// <param name="input"></param>
        public void UpdateTask(UpdateTodoInput input)
        {
            var todo = _objectMapper.Map<Todo>(input);
            _todoRepository.UpdateAsync(todo);
        }

        public Todo GetItem(int id)
        {
            //Try to get from cache
            return _cacheManager
                    .GetCache("MyTodo")
                    .Get(id.ToString(), (id) => GetFromDatabase(id)) as Todo;
        }

        public Todo GetFromDatabase(string id)
        {
            //... retrieve item from database
            return _todoRepository.Get(int.Parse(id));
        }
    }
}
