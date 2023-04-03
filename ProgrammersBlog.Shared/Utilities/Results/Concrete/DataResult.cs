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
        public DataResult(T data, ResultStatus resultStatus)
        {
            Data = data;
            ResultStatus = resultStatus;
        }

        public DataResult(T data, ResultStatus resultStatus, string message) : this(data, resultStatus)
        {
            Message = message;
        }

        public DataResult(T data, ResultStatus resultStatus, string message, Exception exception) : this(data, resultStatus, message)
        {
            Exception = exception;
        }

        public T Data { get; }

        public ResultStatus ResultStatus { get; } //ResultStatus.Success //ResultStatus.Error Bu şekilde kullanıcaz. Sonuç başarılı veya değil şeklinde durumları birbirinden ayırıyor olacaz.
        public string Message { get; } //başarılı olup olmadığını dönüyoruz.
        public Exception Exception { get; } //Exception'ları tutabilmek için. 
    }
}
