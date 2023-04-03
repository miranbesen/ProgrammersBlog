using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult //user'da taşıyabilir, başka birşeyde taşıyabilir o yüzden generic yaptık.(T şeklinde). Bunun dışında tipimizi out olma sebebi category'yi tek başına da taşıyabiliriz, onun dışında IList, IEnumerable şeklinde de taşıyabiliriz. Bu yüzden her iki işlem içinde ayrı ayrı prop'lar yerine bu şekilde kullanırsak ister bir liste ister bir entities taşıyabiliyor olacaz. 
    {
        public T Data { get; } //new DataResult<Category>(ResultStatus.Success,category);  //new DataResult<IList<Category>>(Result.Success, categoryList); şeklinde kullanabiliyoruz.


    }
}
