using Microsoft.AspNetCore.Mvc;
using ST10451547_APPLICATION_PROGRAMMING_PART2.BusinessLogic.Services;
using ST10451547_APPLICATION_PROGRAMMING_PART2.Enumerators;

namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        private const string Key = "UserId";
        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var user = _userService.GetUsersAsync().Result.Where(k => k.Loginname == model.Username && k.LoginPassword == model.Password).FirstOrDefault();

                    if (user != null)
                    {
                        //  if you are here it means the user logged in successfully.

                        //  get the role of the user

                        var users = _userService.GetUsersAsync().Result.FirstOrDefault(h => h.UsersId == user.UsersId);
                        //var devices = db.VloggerData.Where(h => h.Clientid == user.ClientId).FirstOrDefault();

                        if (users == null)
                        {
                            return Content("No role has been configured for this user");
                        }

                        //  set sessions here
                        //  you need to set sessions before you redirect, the corresponding dashboard (Marker / Admin) will read from session



                        //HttpContext.Session.SetInt32("roleID", users.RoleId);
                        //HttpContext.Session.SetInt32("clientID", users.ClientId);
                        HttpContext.Session.SetInt32("usersID", users.UsersId);
                        HttpContext.Session.SetString("EmailAddress", Convert.ToString(user.EmailAddress));
                        //HttpContext.Session.SetString("Device", Convert.ToString(devices.Device));

                        //  BASED ON THE ROLES ON THE SERVER REDIRECT TO SPECIFIC PAGE FOR EITHER MARKER OF SUPER ADMIN
                        //  MARKER
                        if (users.RoleId == (int)RoleIDs.User)
                        {
                            //  get marker record
                            //var User = db.Users.Where(u => u.UsersId == users.UsersId).FirstOrDefault();

                            if (users == null)
                            {
                                return new ContentResult()
                                {
                                    StatusCode = 404,
                                    ContentType = "application/text",
                                    Content = "Marker record does not exist"
                                };
                            }


                            HttpContext.Session.SetString(Key, Convert.ToString(users.UsersId));
                            return RedirectToAction("Index", "Admin");
                        }


                        //  ADMINISTRATOR
                        else if (users.RoleId == (int)RoleIDs.Administrator)
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        //  SUPERADMIN
                        else if (users.RoleId == (int)RoleIDs.SuperAdmin)
                        {
                            ViewBag.Message = "Opss User Name already exsist, Please try another User Name !!!";
                            return RedirectToAction("Index", "Admin");

                        }

                        //  Supervisor

                        else if (users.RoleId == (int)RoleIDs.Supervisor)
                        {
                            return RedirectToAction("Index", "Admin");

                        }

                        //Employee 

                        else if (users.RoleId == (int)RoleIDs.Employee)
                        {
                            return RedirectToAction("Index", "Admin");

                        }
                        //Farmers 
                        else if (users.RoleId == (int)RoleIDs.Farmers)
                        {
                            return RedirectToAction("Index", "Admin");

                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return View(model);
        }
    }
}
