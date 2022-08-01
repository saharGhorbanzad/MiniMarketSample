using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.EntityConfiguration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //رابطه یک به چند
            builder.HasOne(c=>c.category)   //یه کتگوری دارم که 
                .WithMany(p=>p.Products)    //چندتا محصول داره
                .HasForeignKey(c=>c.CategoryID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
