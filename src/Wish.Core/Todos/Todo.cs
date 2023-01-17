using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wish.Todos
{
    [Table("Todos")]
    public class Todo : IEntity<long>, IHasCreationTime
    {
        /// <summary>
        /// 工作代號
        /// </summary>
        [Key]
        public virtual long Id { get; set; }

        /// <summary>
        /// 父層代號
        /// </summary>
        public virtual long Parent { get; set; }

        [Required]
        /// <summary>
        /// 是否作用中
        /// </summary>
        public virtual int IsActive { get; set; }
        [MaxLength(100)]

        /// <summary>
        /// 標題
        /// </summary>
        public virtual string Title { get; set; }
        [Required]
        [MaxLength(100)]

        /// <summary>
        /// 工作描敍
        /// </summary>
        public virtual string Decsription { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        [Required]
        public virtual DateTime StartTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 結束時間
        /// </summary>
        [Required]
        public virtual DateTime EndTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 工作明細
        /// </summary>
        [MaxLength(500)]
        public virtual string Detail { get; set; }

        /// <summary>
        /// 工作順序
        /// </summary>
        public virtual int? Sort { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public virtual DateTime CreationTime { get; set ; } = DateTime.Now;

        public bool IsTransient()
        {
            return true;
        }
    }
}
