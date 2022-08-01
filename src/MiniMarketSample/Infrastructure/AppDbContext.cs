using Entities.Interface;
using Entities.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext: IdentityDbContext<User,Role,Guid>
    {
        public AppDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Assembly assembly=typeof(IEntity).Assembly;   //نوع همه ی کلاسایی که از اینترفیس اینتتی استفاده کرده اند را میریزه تو اسمبلی
            builder.RegisterAllEntities<IEntity>(assembly);
        }
    }
}
