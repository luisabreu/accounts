using System.Threading.Tasks;
using Accounts.Model;
using Accounts.ViewModel;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Accounts.Controllers {
    public class HomeController : Controller {
        private readonly UsersContext _context;

        public HomeController(UsersContext context) {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index() {
            var users = (await _context.Users.ToListAsync()).Select(u => u.ToScreen()).ToList();
            return View(users);
        }

        public IActionResult NewUser(UserInfoViewModel model) {
            return View(new UserInfoViewModel());
        }
    }
}