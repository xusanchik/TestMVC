using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Collections.Generic;
using TestMVC.Data;
using TestMVC.Dto_s;
using TestMVC.ExtensionFunctions;
using TestMVC.Interface;
using TestMVC.Models;
using TestMVC.Models.ERole;

namespace TestMVC.Controllers
{
    public class UserResultController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public UserResultController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
         
        }


        public async Task<IActionResult> Index()
        {

            var tolist = await _appDbContext.UserResults.ToListAsync();
            return View("Index", tolist);
        }

        
    }
}
