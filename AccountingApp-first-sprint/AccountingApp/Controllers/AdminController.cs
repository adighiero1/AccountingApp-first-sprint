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
        //uncomment this line for admin authorization [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        //
        public IActionResult Create()
        {
            return View(new IdentityUser());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityUser user)
        {
            await _userManager.CreateAsync(user);
            return RedirectToAction("Index");
        }


    }
}