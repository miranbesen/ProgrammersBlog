using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity, new() //Tip verecez ve verdiğimiz tipe göre repository işlemleri yapılacak. //newlenebilir olmalı.
    { 
        //Asenkron method-Task ile yazıyoruz.
        //Bunu bu şekilde yapmamızın sebebis Mesela ben 1'den fazla şey çağırmak isteyebilirim. Users, yorum, makale,... | gibi (params=parametre) tanımlama sebebimiz ise 1'den fazla parametre de alabilir, tek parametre de alabilir. Birde array şeklinde tanımladık bahsettiğimiz olaydan dolayı.  
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includeProperties); //"var kullanici =repository.GetAsync(k=>k.Id==15);" Cağırırken biz bu şekilde çağırıyoruz. GetAsync() içinde olan kısımda biz expression'umuzu yazıyoruz. Hangi kullaniciyi istiyorsak onu yazdığımız expression'a predicate diyoruz.  

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); //null olursa hepsini listeliyecek.
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity); 
        
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Mesela alper isimli bir kullanıcı var mı? Örneğin: var result= _userRepository.AnyAsync(u=>u.FirstName=="Alper");
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    }
}
