using System.Web.Mvc;
using System.Web.Security;
using Core.Abstract;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccessService _access;

        public AccountController(IAccessService accessService)
        {
            _access = accessService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_access.CheckLogin(loginViewModel.Login, loginViewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.Login, false);
                    return Redirect(returnUrl ?? Url.Action("ProfilePage", "Main"));
                }
                ModelState.AddModelError("", "Invalid authentication");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(Url.Action("Login", "Account"));
        }
    }

}