using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase //Temel değerleri veriyoruz.
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; //Oluşturulma tarihini oluşturulduğu zamanın.
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now; //Değiştirilme tarihi değiştirildiği degere atandı.
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; }
        public virtual string ModifiedByName { get;set; }
    }
}
