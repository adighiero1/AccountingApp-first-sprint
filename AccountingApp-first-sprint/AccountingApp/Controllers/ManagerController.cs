using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.Controllers
{
    public class ManagerController : Controller
    {
        [Authorize(Roles="Admin, Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}