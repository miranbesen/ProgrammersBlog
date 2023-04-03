using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Kategori Adı")] //Name alanının nasıl gözükmesini istiyorsak onu belirlediğimiz bir annotation.
        [Required(ErrorMessage = "{0} Adı boş geçilmemelidir.")] //Bu alanın zorunlu olmasını istiyoruz. Boş geçilmemesini. {0} kısmında DisplayName alanı gözüküyor direk.
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{0}=DisplayName, {1}=70 
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
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

        [DisplayName("Silindi mi?")] //Name alanının nasıl gözükmesini istiyorsak onu belirlediğimiz bir annotation.
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }
    }
}
