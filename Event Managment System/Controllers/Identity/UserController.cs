using Event_Booking_System.Models.Identity.Users;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
           _userManager = userManager;
           _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync(); 
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user); 
                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email!,
                    Username = user.UserName!,
                    Roles = roles
                });
            }

            return View(userViewModels);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string Id )
        
        {
            var User = await _userManager.FindByIdAsync(Id);

            var Roles = await _roleManager.Roles.ToListAsync();

            var UserModel = new UserRoleViewModel
            {
                UserId = User!.Id,
                Username = User.UserName!,
                Roles = Roles.Select(role => new UpdateRoleViewModel
                {

                    Id = role.Id,
                    Name = role.Name!,
                    IsSelected = _userManager.IsInRoleAsync(User, role.Name!).Result
                }).ToList()
            };


            return View(UserModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleViewModel model)
        {
            var User = await _userManager.FindByIdAsync(model.UserId);

            var Roles = await _userManager.GetRolesAsync(User);

            foreach (var role in model.Roles)
            {
                if(Roles.Any(r => r ==  role.Name ) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(User, role.Name);

                if (!Roles.Any(r => r == role.Name) && role.IsSelected)
                    await _userManager.AddToRoleAsync(User, role.Name);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
