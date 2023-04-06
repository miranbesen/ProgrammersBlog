using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
            Exception = exception;
        }

        public T Data { get; }

        public ResultStatus ResultStatus { get; } //ResultStatus.Success //ResultStatus.Error Bu şekilde kullanıcaz. Sonuç başarılı veya değil şeklinde durumları birbirinden ayırıyor olacaz.
        public string Message { get; } //başarılı olup olmadığını dönüyoruz.
        public Exception Exception { get; } //Exception'ları tutabilmek için. 
    }
}
