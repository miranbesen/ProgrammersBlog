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
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId); //Asenkron yazdığımız için Task seklinde yazdık.
        Task<IDataResult<CategoryListDto>> GetAll(); //birden fazla category'i liste şeklinde getir. 
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted(); //silinmemiş kategorileri de getiriyoruz. GetAll'da ise hepsini getirmiş oluyor.
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName); //dto=veri transgeri objesi olarak geciyor. Bunlar viewModel'ler olarak düşünülebilir. Bu dto dediğimiz sınıflar front-end tarafında sadece ihtiyacımız olan alanları barındırıyor. Kullanıcıdan sadece ihtiyaç duyduguğumuz şeyleri front-end'den istiyoruz.
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName); //burada category'nin isdeleted değerini true yapıyor. Gerçekten bir category veya entitity'yi silmiyor. GetAll yaptığı zaman gözükmüyor bu değer true olursa. 
        Task<IResult> HardDelete(int categoryId);//veri tabanından siliyor. 
    }
}
