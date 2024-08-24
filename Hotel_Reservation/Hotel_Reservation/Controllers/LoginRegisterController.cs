using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation.Models;
using Microsoft.Extensions.Hosting;

namespace Hotel_Reservation.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LoginRegisterController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,ImagePath,ImageFile")] UserProfile userProfile, string username, string password)
        {
            if (ModelState.IsValid)
            {

                if (userProfile.ImageFile != null)
                {
                    string wwwrootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + userProfile.ImageFile.FileName;
                    string path = Path.Combine(wwwrootPath + "/image/" + fileName); ;
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await userProfile.ImageFile.CopyToAsync(filestream);
                    }
                    userProfile.ImagePath = fileName;
                    _context.Add(userProfile);
                    await _context.SaveChangesAsync();
                    UserLogin userLogin = new UserLogin();
                    userLogin.Username = username;
                    userLogin.Password = password;
                    userLogin.UserProfileId = userProfile.Id;
                    userLogin.RoleId= 21;
                    _context.Add(userLogin);
                    await _context.SaveChangesAsync();
                    HttpContext.Response.Cookies.Append("user_id", userLogin.Id.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    HttpContext.Response.Cookies.Append("role_id", userLogin.RoleId.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    HttpContext.Response.Cookies.Append("signed", "true", new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    HttpContext.Response.Cookies.Append("user_img", userProfile.ImagePath.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username,Password")] UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {


                var auth = _context.UserLogins.Include(m => m.UserProfile).Where(x => x.Username == userlogin.Username && x.Password == userlogin.Password).SingleOrDefault();
                if (auth != null)
                {

                    HttpContext.Response.Cookies.Append("user_id", auth.Id.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    HttpContext.Response.Cookies.Append("role_id", auth.RoleId.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    HttpContext.Response.Cookies.Append("signed", "true", new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });
                    HttpContext.Response.Cookies.Append("user_img", auth.UserProfile.ImagePath.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                        // every othe options like path , ...
                    });

                    switch (auth.RoleId)
                    {
                        case 21:
                            return RedirectToAction("Index", "Home");
                        case 2:
                            return RedirectToAction("Index", "Home");
                        case 3:
                            return RedirectToAction("Index", "Home");
                        default:
                            return RedirectToAction("Login", "LoginRegister");

                    }
                }

            }
            return View();
        }
        public IActionResult SignOut()
        {
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
