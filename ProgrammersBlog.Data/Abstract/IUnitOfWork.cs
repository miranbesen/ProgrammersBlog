using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable //context'imizi dispose ediyor olacaz. GarbageCollector'a yardımcı oluyor.
    {
        IArticleRepository Articles { get; } //unitofwork.Artices seklinde çağıracaz. 
        ICategoryRepository Categories { get; }  //_unitofwork.Categories.AddAsync(); şeklinde kullanabilirim.
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository User { get; }
        Task<int> SaveAsync(); //int yapma sebebimiz etklinenen kayıt sayısını dönmek isteyebiliriz. veri tabanımıza kayıt etme işlemi yapıyoruz.
        //Örneğin(saveAsync için):
        //_unitofwork.Categories.AddAsync(category);
        //_unitofwork.Users.AddAsync(user);
        //_unitofwork.SaveAsync();
    }
}
