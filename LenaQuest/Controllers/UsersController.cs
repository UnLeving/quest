using Microsoft.AspNetCore.Mvc;
using LenaQuest.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LenaQuest.ViewModels;

namespace LenaQuest.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();

        public async Task<IActionResult> Profile(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            ProfileViewModel model = new ProfileViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Age = user.Age,
                City = user.City,
                QuestExpirience = user.QuestExpirience,
                QuestDetails = user.QuestDetails ?? "waiting for validation"
            };
            return View(model);
        }

        public async Task<IActionResult> Edit(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Age = user.Age };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Age = model.Age;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> ChangePassword(string id)
        //{
        //    User user = await _userManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _userManager.FindByIdAsync(model.Id);
        //        if (user != null)
        //        {
        //            IdentityResult result =
        //                await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                foreach (var error in result.Errors)
        //                {
        //                    ModelState.AddModelError(string.Empty, error.Description);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Пользователь не найден");
        //        }
        //    }
        //    return View(model);
        //}
    }
}