using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }

        public Result(ResultStatus resultStatus, string message) : this(resultStatus)
        {
            Message = message;
        }

        public Result(ResultStatus resultStatus, string message, Exception exception) : this(resultStatus, message)
        {
            Exception = exception;
        }

        //public ResultStatus ResultStatus { get;} //ResultStatus.Success //ResultStatus.Error Bu şekilde kullanıcaz. Sonuç başarılı veya değil şeklinde durumları birbirinden ayırıyor olacaz.
        //public string Message { get;} //başarılı olup olmadığını dönüyoruz.
        //public Exception Exception { get;} //Exception'ları tutabilmek için. 

    }
}

//Örnek olarak mesela result sınıfını kullanırken : new Result(ResultStatus.Error,exception.message,exception) gibi kullanabilir  iz.
