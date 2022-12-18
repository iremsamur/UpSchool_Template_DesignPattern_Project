using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Template_Design_Pattern.DAL.Entities;

namespace Template_Design_Pattern.DAL
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        //Burada int olarak key ataması yapmazsam bazıları int bazıları string oluyor karışıyor.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-ISO96UVH\\SQLEXPRESS;Database=UpSchoolTemplateDesignPatternDb;integrated security=True;");

        }
    }
}
