using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId); //Asenkron yazdığımız için Task seklinde yazdık.
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId); //birden fazla category'i liste şeklinde getir. 
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive(); //silinmemiş kategorileri de getiriyoruz. GetAll'da ise hepsini getirmiş oluyor.
         
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName); //dto=veri transgeri objesi olarak geciyor. Bunlar viewModel'ler olarak düşünülebilir. Bu dto dediğimiz sınıflar front-end tarafında sadece ihtiyacımız olan alanları barındırıyor. Kullanıcıdan sadece ihtiyaç duyduguğumuz şeyleri front-end'den istiyoruz.
        Task<IResult> Update(ArticleUpdateDto atricleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName); //burada category'nin isdeleted değerini true yapıyor. Gerçekten bir category veya entitity'yi silmiyor. GetAll yaptığı zaman gözükmüyor bu değer true olursa. 
        Task<IResult> HardDelete(int articleId);//veri tabanından siliyor. 
    }
}
