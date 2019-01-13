using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingCentreManagement.Models;
using TrainingCentreManagement.Models.EntityModels.IdentityEntities;

namespace TrainingCentreManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> Create(RoleCreateViewModel model)
        {
            AppRole role = new AppRole
            {
                Name = model.Name,
                ConcurrencyStamp = model.ConcurrencyStamp,
                NormalizedName = model.NormalizedName
            };
           var result=await  _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return View();
            }
            return View();
        }
    }
}