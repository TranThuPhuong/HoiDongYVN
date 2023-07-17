//using HoiDongYVN.Models;
//using HoiDongYVN.Repository;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;

//namespace HoiDongYVN.Controllers
//{
//    public class LoginController : Controller
//    {
//        private readonly iCreator creatorRepo;

//        public LoginController(iCreator creatorRepo)
//        {
//            this.creatorRepo = creatorRepo;
//        }
//        public IActionResult Login()
//        {
//            //ClaimsPrincipal claimUser = HttpContext.User;
//            //// _logger.LogInformation("This is my string: " + claimUser.Identity.IsAuthenticated, "");
//            //if (claimUser.Identity.IsAuthenticated)
//            //{
//            //    string role = claimUser.FindFirstValue(ClaimTypes.Role);
//            //    if (role == "user")
//            //    {
//            //        return RedirectToAction("Index", "Home");
//            //    }
//            //    else
//            //    {
//            //        return RedirectToRoute("admin");
//            //    }
//            //}
//            //if (TempData.ContainsKey("Message"))
//            //{
//            //    ViewBag.Message = TempData["Message"];
//            //}

//            return View();
//        }
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public IActionResult Login(LoginModel loginModel)
//        //{
//        //    var creator = creatorRepo.GetCreatorByUsernameAndPassword(loginModel.Username,loginModel.Password);

//        //    if (creator != null)
//        //    {
//        //        HttpContext.Session.SetString("username", loginModel.Username);
//        //        var username = HttpContext.Session.GetString("username");
//        //        if (creator.IRole == 1 )
//        //        {
//        //            return RedirectToAction("Index", "Creators");
//        //        }    

//        //    }

//        //    //TempData["ErrorMessage"] = "Sai mật khẩu hoặc tên đăng nhập";
//        //    return RedirectToAction("Index", "Home");
//        //}

//        public async Task setDataToClaim(Creator user)
//        {
//            List<Claim> claims = new List<Claim>() {
//                new Claim(ClaimTypes.Sid, user.PkICreatorId.ToString()),
//                new Claim(ClaimTypes.Name, user.SUsername),
//                //new Claim(ClaimTypes.Role, user.SUsername),
//                new Claim(ClaimTypes.Role, user.IRole),
//            };

//            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            AuthenticationProperties properties = new AuthenticationProperties()
//            {
//                AllowRefresh = true,
//                IsPersistent = true,
//            };

//            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(string Username, string Password)
//        {
//            var user = creatorRepo.GetCreatorByUsernameAndPassword(Username, Password);
//            if (user == null)
//            {
//                TempData["Message"] = "Tài khoản không tồn tại!";
//                return RedirectToRoute("Login/Login");
//            }
//            await setDataToClaim(user);
//            HttpContext.Session.SetString("id", user.PkICreatorId.ToString());
//            HttpContext.Session.SetString("email", user.SEmail);
//            HttpContext.Session.SetString("username", user.SUsername);
//            if (user.IRole == "Admin")
//            {

//                return RedirectToAction("Index", "Creators");
//            }
//            return RedirectToAction("Index", "Home");
//        }

//    }
//}
using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HoiDongYVN.Controllers
{
    public class LoginController : Controller
    {
        private readonly iCreator creatorRepo;

        public LoginController(iCreator creatorRepo)
        {
            this.creatorRepo = creatorRepo;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = creatorRepo.GetCreatorByUsernameAndPassword(loginModel.Username, loginModel.Password);

            if (user != null)
            {
                await setDataToClaim(user);

                if (user.IRole == "Admin")
                {
                    return RedirectToAction("Index", "Creators");
                }
            }

            TempData["ErrorMessage"] = "Sai tên đăng nhập hoặc mật khẩu.";
            return RedirectToAction("Login");
        }

        private async Task setDataToClaim(Creator user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.PkICreatorId.ToString()),
                new Claim(ClaimTypes.Name, user.SUsername),
                new Claim(ClaimTypes.Role, user.IRole)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
        }
    }
}
