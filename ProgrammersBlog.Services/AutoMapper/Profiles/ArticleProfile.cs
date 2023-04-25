using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile //entities katmanınımızda olan dtos ile concrete sınıfımlarımızı eşlemeye yarıyor. 
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)); //ArticleDto icinde mesela createdDate alanı yok. Biz bunu her eslestiginde doldurmak icin, ForMember() fonksiyonu kullaniyoruz. bu fonksiyon, yazdigimiz parametrelerin icerindeki bir property icin islem yapacagimi soyluyor. Daha sonra options kısmında MapFrom yani map içinde bu islemi yap diyoruz.  Yani burada article icindeki bu degerimizi, bizim verdigimiz ayar dosyasını datetime.now eklemis olacak.
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now)); //ArticleUpdateDto'yu al sen, article'ye donustur diyor.

        }
    }
}
