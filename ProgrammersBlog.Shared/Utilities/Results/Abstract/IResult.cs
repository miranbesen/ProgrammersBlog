using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public class IResult
    {
        public ResultStatus ResultStatus { get; set; } //ResultStatus.Success //ResultStatus.Error Bu şekilde kullanıcaz. Sonuç başarılı veya değil şeklinde durumları birbirinden ayırıyor olacaz.
        public string Message { get; set; } //başarılı olup olmadığını dönüyoruz.
        public Exception Exception { get; set; } //Exception'ları tutabilmek için. 

    }
}
