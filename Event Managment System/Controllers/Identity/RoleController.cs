using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index ()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.Name);

                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Name));
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Name", "Role Already Exists");
                return View(nameof(Index), await _roleManager.Roles.ToListAsync());
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit (string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            
            if (role is null)
            {
                ModelState.AddModelError("Id", "No Role Exists With This Id");
                return RedirectToAction(nameof(Index));
            }

            UpdateRoleViewModel mappedRole = new UpdateRoleViewModel
            {
                Id = Id,
                Name = role.Name!
            };

            return View(mappedRole);
        }


        [HttpPost]
        public async Task<IActionResult> Edit (UpdateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync (model.Name);

                if (!roleExists)
                {
                    var role = await _roleManager.FindByIdAsync(model.Id);
                   if (role is not null)
                    {
                        role.Name = model.Name;
                        await _roleManager.UpdateAsync(role!);
                    }

                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    ModelState.AddModelError("Name", "Role Already Exists");
                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete (string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if (role != null)
                await _roleManager.DeleteAsync(role); 

            return RedirectToAction(nameof(Index));

            


        }
    }
}
