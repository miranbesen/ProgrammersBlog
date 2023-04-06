using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note = categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName, 
                ModifiedDate = DateTime.Now, //Bu değerleri normalde entitybase içinde vermiştik fakat anlaşılır olsun diye tekrar yazdık.
                IsDeleted = false
            }).ContinueWith(t => _unitOfWork.SaveAsync()); //yeni bir task ile zincirleme devam et demek(continuewith). Bu şekilde daha hızlı gerçekleştiriyor.
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir."); //font-end tarafına çok hızlı dönüyoruz return'ü hatta veri tabanına kayıt yapmadan front-end'e sonucu dönüyoruz. Böylece aslında hızdan kazanıyoruz fakat takip zorlaşıyor.
        }

        public Task<IResult> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles); //predicate'mizi categoryId'ye eşit olan category'i getir dedik. Daha sonra o category'e ait articles'i getir dedik.
            if (category != null)
            {
                return new DataResult<Category>(ResultStatus.Success, category);
            }
            return new DataResult<Category>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", data: null);
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles); //predicate kısmını null verdik, params includeProperties kısmınıda articles'leri verdik.
            if (categories.Count > -1) //-1 den büyük deme sebebimiz 0 yerine, 0 tane category'de olabilir diye.
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", null); //data'sı null,message'si..., şeklinde constructor'a parametreleri yolladık.
        }

        public async Task<IDataResult<IList<Category>>> GetAllByNonDeleted() //silinmemişleri getiriyor.
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles); //buradaki predicate aynı zamanda c=>c.IsDeleted==false ile aynı anlamı taşır.Yani true olmayanları dön diyor.
            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", null);
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id); //güncellemek istediğimiz category'i çektik.
            if (category != null)
            {
                category.Name = categoryUpdateDto.Name;
                category.Description = categoryUpdateDto.Description;
                category.Note=categoryUpdateDto.Note;
                category.IsActive= categoryUpdateDto.IsActive;
                category.IsDeleted= categoryUpdateDto.IsDeleted;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                //burada kaldım. 3o'uncu video 10'uncu dakika.
            }
        }
    }
}
