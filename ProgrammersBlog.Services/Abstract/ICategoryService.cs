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
        Task<IDataResult<Category>> Get(int categoryId); //Asenkron yazdığımız için Task seklinde yazdık.
        Task<IDataResult<IList<Category>>> GetAll(); //birden fazla category'i liste şeklinde getir. 
        Task<IDataResult<IList<Category>>> GetAllByNonDeleted(); //silinmemiş kategorileri de getiriyoruz. GetAll'da ise hepsini getirmiş oluyor.
        Task<IResult> Add(CategoryAddDto categoryAddDto,string createdByName); //dto=veri transgeri objesi olarak geciyor. Bunlar viewModel'ler olarak düşünülebilir. Bu dto dediğimiz sınıflar front-end tarafında sadece ihtiyacımız olan alanları barındırıyor. Kullanıcıdan sadece ihtiyaç duyduguğumuz şeyleri front-end'den istiyoruz.
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId); //burada category'nin isdeleted değerini true yapıyor. Gerçekten bir category veya entitity'yi silmiyor. GetAll yaptığı zaman gözükmüyor bu değer true olursa. 
        Task<IResult> HardDelete(int categoryId);//veri tabanından siliyor. 

    }
}
