using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            await _unitOfWork.Categories.AddAsync(category)
            .ContinueWith(t => _unitOfWork.SaveAsync()); //yeni bir task ile zincirleme devam et demek(continuewith). Bu şekilde daha hızlı gerçekleştiriyor.
            //await _unitOfWork.SaveAsync(); //37'nci video 9'uncu dakikada kaldım.
            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adli kategori basariyla eklenmistir."); //front-end tarafına çok hızlı dönüyoruz return'ü hatta veri tabanına kayıt yapmadan front-end'e sonucu dönüyoruz. Böylece aslında hızdan kazanıyoruz fakat takip zorlaşıyor.
        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} adli kategori basariyla silinmistir.");
            }
            return new Result(ResultStatus.Error, "Hic bir kategori bulunamadı.");
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles); //predicate'mizi categoryId'ye eşit olan category'i getir dedik. Daha sonra o category'e ait articles'i getir dedik.
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadi.", data: null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles); //predicate kısmını null verdik, params includeProperties kısmınıda articles'leri verdik.
            if (categories.Count > -1) //-1 den büyük deme sebebimiz 0 yerine, 0 tane category'de olabilir diye.
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hic bir kategori bulunamadı.", null); //data'sı null,message'si..., şeklinde constructor'a parametreleri yolladık.
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted() //silinmemişleri getiriyor.
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles); //buradaki predicate aynı zamanda c=>c.IsDeleted==false ile aynı anlamı taşır.Yani true olmayanları dön diyor.
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hic bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles); //buradaki predicate aynı zamanda c=>c.IsDeleted==false ile aynı anlamı taşır.Yani true olmayanları dön diyor.
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hic bir kategori bulunamadı.", null);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} adli kategori basariyla veritabanindan silinmistir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadi.");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName) //bu fonksiyonların içini automapper ile yazıyoruz normalde. Şuanlık bu şekilde yazıyoruz.
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} adli kategori basariyla guncellenmistir."); //front-end tarafına çok hızlı dönüyoruz return'ü hatta veri tabanına kayıt yapmadan front-end'e sonucu dönüyoruz. Böylece aslında hızdan kazanıyoruz fakat takip zorlaşıyor.
        }
    }
}
