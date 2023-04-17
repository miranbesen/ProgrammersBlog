using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; } //virtual olarak tanımladık. Böylece sanal bir property olmalısın diyoruz. Böylece daha sonra kullanıldığı zaman override edebilelim. 

    }
}
