using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.API.Entity
{
    public class EntityBase:IEntityBase
    {
        public virtual int Id { get; set; }
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifieldDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
