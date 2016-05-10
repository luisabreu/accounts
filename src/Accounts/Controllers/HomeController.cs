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
        public async Task<ViewResult> Index() {
            var users = (await _context.Users.ToListAsync()).Select(u => u.ToScreen()).ToList();
            return View(new UserInfoListViewModel {Users = users});
        }

        public async Task<IActionResult> AddUser(UserInfoViewModel userInfo) {
            if (ModelState.IsValid) {
                var user = new UserInfo {
                                            Department = userInfo.Department,
                                            Description = userInfo.Description,
                                            GivenName = userInfo.GivenName,
                                            Surname = userInfo.Surname
                                        };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("NewUser", userInfo);
        }

        public IActionResult NewUser(UserInfoViewModel viewModel) {
            return View(viewModel);
        }
    }
}