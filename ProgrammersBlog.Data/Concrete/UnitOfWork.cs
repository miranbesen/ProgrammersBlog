using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork //entityframework yapısıyla ilgisi olmadığı için EntityFramework klasörünün içine eklemedik.
    {
        private readonly ProgrammersBlogContext _context; //repository'lerimiz constructor içinde bir context istiyor diye kendi context'timizi oluşturuyoruz.
        private EfArticleRepository _articleRepository; //interface'lerin somut(concrete) hallerini de eklememiz gerek. Yoksa return edemeyiz.
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfRoleRepository _roleRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }
        // ?? operatörü (Null Coalescing Operatörü) sayesinde bir değişkenin null olduğu durumda alternatif değer döndürebiliriz. 
        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context); //birisi bizden IArticleRepository istediğinde biz _articleRepository'i return edicez. Yani somut halini dönüyoruz.

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);

        public IUserRepository User => _userRepository ?? new EfUserRepository(_context);


        public async ValueTask DisposeAsync() //Dispose(), bir işlemden sonra yapılan işlemi bellekten atmak demek.Yani, siz bir işlemi bitirirken Close() metodu kullandığınız zaman bu işlem bellekte durmaya ve yer kaplamaya devam eder. Dispose() metodu, bu yapılan işlemi bellekten atar. Context'timizi dispose ediyor olacaz.
        {
             await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); //context'imizin savechanges methodu int deger dönüyor zaten Ondan ekstra bir şey yapmadık.
        }
    }
}
