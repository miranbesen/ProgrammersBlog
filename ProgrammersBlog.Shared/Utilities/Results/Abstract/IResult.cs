using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;} //ResultStatus.Success //ResultStatus.Error Bu şekilde kullanıcaz. Sonuç başarılı veya değil şeklinde durumları birbirinden ayırıyor olacaz.
        public string Message { get;} //başarılı olup olmadığını dönüyoruz.
        public Exception Exception { get;} //Exception'ları tutabilmek için. 

    }
}
