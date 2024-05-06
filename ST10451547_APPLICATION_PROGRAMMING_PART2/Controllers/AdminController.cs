using Microsoft.AspNetCore.Mvc;
using ST10451547_APPLICATION_PROGRAMMING_PART2.Data.Entities;

namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersId,UsersToken,RoleId,ClientId,Loginname,Firstname,Lastname,GenderId,EmailAddress,CreatedDate")] User user, int? id)
        {
            return View(user);
        }
    }
}
