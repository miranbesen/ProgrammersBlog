using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto  //dto=veri transgeri objesi olarak geciyor. Bunlar viewModel'ler olarak düşünülebilir. Bu dto dediğimiz sınıflar front-end tarafında sadece ihtiyacımız olan alanları barındırıyor. Kullanıcıdan sadece ihtiyaç duyduguğumuz şeyleri front-end'den istiyoruz.
    {
        [DisplayName("Kategori Adı")] //Name alanının nasıl gözükmesini istiyorsak onu belirlediğimiz bir annotation.
        [Required(ErrorMessage ="{0} Adı boş geçilmemelidir.")] //Bu alanın zorunlu olmasını istiyoruz. Boş geçilmemesini. {0} kısmında DisplayName alanı gözüküyor direk.
        [MaxLength(70,ErrorMessage ="{0} {1} karakterden büyük olmamalıdır.")] //{0}=DisplayName, {1}=70 
        [MinLength(3,ErrorMessage ="{0} {1} karakterden az olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")] //Name alanının nasıl gözükmesini istiyorsak onu belirlediğimiz bir annotation.
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{0}=DisplayName, {1}=70 
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")] //Name alanının nasıl gözükmesini istiyorsak onu belirlediğimiz bir annotation.
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{0}=DisplayName, {1}=70 
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Note { get; set; }

        [DisplayName("Aktif mi?")] //Name alanının nasıl gözükmesini istiyorsak onu belirlediğimiz bir annotation.
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; } //belki kullanıcı category'nin aktiv olmasını istemeyebilir.
    }
}
// {0} {1} alanını dinamik kullandığımız için sadece isim değişikliğiyle hallettik.