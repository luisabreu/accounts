using Accounts.Model;
using Accounts.ViewModel;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Accounts.Controllers {
    public class HomeController : Controller {
        private readonly UsersContext _context;

        public HomeController(UsersContext context) {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(UserInfoViewModel model) {
            return View(new UserInfoViewModel());
        }
    }
}