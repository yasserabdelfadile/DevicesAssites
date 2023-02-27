using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication11.Models.Userview;

namespace WebApplication11.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserviewController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserviewController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager= userManager;
            _roleManager= roleManager;  
        }



        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new Userviewcs
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result

            }).ToListAsync();

            return View(users);
        }


        public async Task<IActionResult> ManageRole(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var roles=await _roleManager.Roles.ToListAsync();
            var ViewModel = new UserRoles
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(Role => new Roleview
                {
                    RoleId = Role.Id,
                    RoleName = Role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, Role.Name).Result
                }).ToList()
            };  
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRole(UserRoles model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }
            
            var userRoles =await _userManager.GetRolesAsync(user);
            foreach(var role in model.Roles)
            {
                if(userRoles.Any(r=>r==role.RoleName)&& !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
                if(!userRoles.Any(r=>r==role.RoleName)&& role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
