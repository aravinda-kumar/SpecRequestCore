using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpecRequestCore.Models;
using SpecRequestCore.Models.RoleAdminViewModels;

namespace SpecRequestCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public RoleAdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index() => View(roleManager.Roles);

        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var users = userManager.Users.ToList();
            var members = new List<ApplicationUser>();
            var nonMembers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    members.Add(user);
                }
                else
                {
                    nonMembers.Add(user);
                }
                
            }

            var model = new EditRoleViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;

            // Is form valid?
            if(ModelState.IsValid)
            {
                // Add users to role (if any)
                foreach(var userId in model.IdsToAdd ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);

                    if(user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            foreach (var error in result.Errors)
                                ModelState.AddModelError("", error.Description);
                    }
                }
                // Then remove users from role (if any)
                foreach (var userId in model.IdsToRemove ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            foreach (var error in result.Errors)
                                ModelState.AddModelError("", error.Description);
                    }
                }
            }

            // then bring them back to the index
            return RedirectToAction(nameof(Index));
        }
    }
}