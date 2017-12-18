using Data.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Base
{
    public abstract class BaseEntity<TKeyType> : IBaseEntity<TKeyType> where TKeyType : new()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKeyType Id { get; set; }

        public BaseEntity()
        {
        }

        [Column()]
        public bool IsDeleted { get; set; } = false;

        [Column()]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
