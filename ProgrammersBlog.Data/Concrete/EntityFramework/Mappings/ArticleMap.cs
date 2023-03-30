using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    //veritabanı nesnelerimizin özelliklerini yazdığımız class( Mesela article nesnemizin Id alanı pk olacak, identity özelliği açık olacaktır gibi...)
    public class ArticleMap : IEntityTypeConfiguration<Article>  //Mapping işlemi olduğunu anlamak için IEntityTypeConfiguration interface'sinden implement ediyoruz.
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id); //Id alanımızı pk yaptık.
            builder.Property(a=>a.Id).ValueGeneratedOnAdd(); //Identity yaptık.
            builder.Property(a => a.Title).HasMaxLength(100);//maks uzunluk.
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)"); //Alabileceği maks uzunlukta makalede alabilir. 100 kelimelikte olur 1000 kelimelikte gibi.
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50); //yazar ismini maks 50 karakter verebilcez.
            builder.Property(a=>a.SeoDescription).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a=>a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId); //bir categorinin birden fazla makalesi olabilir. Yani 1 e çok ilişki.
            builder.HasOne<User>(a=>a.User).WithMany(u=>u.Articles).HasForeignKey(a => a.UserId); // Bir User'in birden fazla makalesi olabilir.
            builder.ToTable("Articles");

        }
    }
}
