using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Template_Design_Pattern.DAL.Entities;

namespace Template_Design_Pattern.Controllers
{
    public class DefaultController : Controller
    {
        //Bu sayfada kullanıcılar giriş yapsada yapmasa açılacak
        //Tek önemli olan bu sayfanın giriş yapıp yapmamaya göre nasıl görüneceği olacak. bunuda template ile yapıyoruz
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.Users.ToListAsync();
            return View(values);
        }
    }
}
