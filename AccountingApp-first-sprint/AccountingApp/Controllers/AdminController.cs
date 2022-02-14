using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.Controllers
{
    public class AdminController : Controller
    {

        //this allows for management of different users within this controller
        UserManager<IdentityUser> _userManager;
        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        //displays the initial admin webpage if you are an admin. 
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        //
        public IActionResult CreateUser()
        {
            return View("CreateUser");
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(IdentityUser user,string password)
        {
            await _userManager.CreateAsync(user, password);
            return RedirectToAction("Index");

            //IdentityResult result = await _userManager.CreateAsync(user);

            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (IdentityError error in result.Errors)
            //        ModelState.AddModelError("", error.Description);
            //}

        }



        //[HttpPut]
        //public async Task<IActionResult> Deactivate(IdentityUser user)
        //{
        //    await _userManager.
        //}


    }
}