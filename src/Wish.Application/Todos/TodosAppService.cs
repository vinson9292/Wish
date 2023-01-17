using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Net.Mail;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using System.Linq;
using Wish.Authorization;
using Wish.Authorization.Users;
using Wish.IRepositories;
using Wish.Todos.Dto;
using Wish.Todos.Dtos;
using Wish.Users.Dto;

namespace Wish.Todos
{
    /// <summary>
    /// TodosAppService
    /// </summary>
    [AbpAuthorize(PermissionNames.Pages_Tasks)]
    public class TodosAppService : AsyncCrudAppService<Todo, TodoDto, long, PagedTodoResultRequestDto, CreateTodoDto, TodoDto>, ITodosAppService
    {
        /// <summary>
        /// Logger
        /// </summary>
        public ILogger Logger { get; set; }
        private readonly ITodoRepository _todoRepository;
        private readonly IAbpSession _session;
        private readonly ICacheManager _cacheManager;
        private readonly IObjectMapper _objectMapper;

        //private readonly IRepository<Todo> _todoRepository;

        /// <summary>
        /// TodosAppService
        /// </summary>
        /// <param name="repository">repository</param>
        /// <param name="todoRepository"></param>
        /// <param name="session">session</param>
        /// <param name="cacheManager">cacheManager</param>
        /// <param name="objectMapper">objectMapper</param>
        public TodosAppService(
            IRepository<Todo, long> repository,
            ITodoRepository todoRepository, 
            IAbpSession session,
            ICacheManager cacheManager,
            IObjectMapper objectMapper
            ) : base(repository)
        {
            _todoRepository = todoRepository;
            Logger = NullLogger.Instance;
            _session = session;
            _cacheManager = cacheManager;
            _objectMapper = objectMapper;
        }

        ///// <summary>
        ///// GetAll
        ///// </summary>
        ///// <returns></returns>
        //public GetTodosOutput GetAll()
        //{
        //    var t1 =  new GetTodosOutput()
        //    {
        //        Todos = _todoRepository.GetAll().Select(x => _objectMapper.Map<TodoDto>(x)).ToList()
        //    };
        //    return t1;
        //}

        ///// <summary>
        ///// CreateTask
        ///// </summary>
        ///// <param name="input"></param>
        //public void Create(CreateTodoInput input)
        //{
        //    var todo = _objectMapper.Map<Todo>(input);
        //    _todoRepository.InsertAsync(todo);
        //    Logger.Debug($"_session.UserId=>{_session.UserId}");
        //}

        ///// <summary>
        ///// GetTodos
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public GetTodosOutput Get(GetTodosInput input)
        //{
        //    return new GetTodosOutput()
        //    {
        //        Todos = _todoRepository.GetAll().Where(x => x.Id == input.id || x.IsActive == (int)input.State).Select(x => _objectMapper.Map<TodoDto>(x)).ToList()
        //    };
        //}

        ///// <summary>
        ///// UpdateTask
        ///// </summary>
        ///// <param name="input"></param>
        //public void Update(UpdateTodoInput input)
        //{
        //    var todo = _objectMapper.Map<Todo>(input);
        //    _todoRepository.UpdateAsync(todo);
        //}

        ///// <summary>
        ///// Detele
        ///// </summary>
        ///// <param name="id"></param>
        //public void Detele(int id)
        //{
        //    _todoRepository.DeleteAsync(id);
        //}

        /// <summary>
        /// GetFromCache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Todo GetFromCache(int id)
        {
            //Try to get from cache
            return _cacheManager
                    .GetCache("MyTodo")
                    .Get(id.ToString(), (id) => GetFromDatabase(id)) as Todo;
        }

        /// <summary>
        /// GetFromDatabase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Todo GetFromDatabase(string id)
        {
            return _todoRepository.Get(int.Parse(id));
        }
    }
}
