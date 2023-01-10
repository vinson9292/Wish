using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wish.Todos.Dto
{
    /// <summary>
    /// 待辦項目
    /// </summary>
    [AutoMapTo(typeof(Todo))]
    public class TodoDto : EntityDto<int>
    {
        /// <summary>
        /// 工作代號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 是否作用中
        /// </summary>
        public TaskState IsActive { get; set; }

        /// <summary>
        /// 標題
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 工作描敍
        /// </summary>
        public string Decsription { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 工作明細
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 工作順序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 父層代號
        /// </summary>
        public int Parent { get; set; }
    }
}
