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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u=>u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique(); //kayıt olunan e-mailden 1 tane olacak şadece.
            builder.Property(u=>u.Username).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)"); //md5 ile şifrelicez. Aslında gerek yok 500 dememize ama ileriye yönelik olurda şifreleme algoritmasını değiştirirsek diye böyle yazdık.
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u=>u.Picture).HasMaxLength(250);
            builder.HasOne<Role>(u=>u.Role).WithMany(r=>r.Users).HasForeignKey(u=>u.RoleId); //bir rol'ün 1'den fazla user'i olabilir.
            builder.Property(u => u.CreatedByName).IsRequired();
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.Note).HasMaxLength(500);
            builder.ToTable("Users");
            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Miran",
                LastName = "Besen",
                Username = "miranbesen",
                Email = "miranbesen@hotmail.com",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Description = "İlk Admin kullanicisi",
                Note = "Admin Kullanicisi",
                PasswordHash = Encoding.ASCII.GetBytes("a178ffc4647fa79f5c53ba7fdb3246e0"), //md5 şifremizi byte olarak vermek için böyle yazdık. 
                Picture= "https://www.kolaydata.com/wp-content/uploads/2017/01/Windows-Kullanici-adini-degistirme-kapak.jpg"
            });
        }
    }
}
