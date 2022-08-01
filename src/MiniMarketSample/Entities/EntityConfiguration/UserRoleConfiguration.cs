using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.EntityConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        { 
            //در رابطه چند به چند یه جدول واسط میسازیم که اسم هر دو جدول توشه مثل یوزر رول
            builder.HasOne(u=>u.User)   //یه دونه یوزر دارم که 
                .WithMany(r=>r.UserRoles)   // چندتا رول داره
                .HasForeignKey(u=>u.UserId)   //با کلید یوزرآی دی
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(r => r.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
