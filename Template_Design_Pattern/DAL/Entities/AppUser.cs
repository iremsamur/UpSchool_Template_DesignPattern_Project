using Microsoft.AspNetCore.Identity;

namespace Template_Design_Pattern.DAL.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
