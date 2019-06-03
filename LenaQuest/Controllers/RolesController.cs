using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LenaQuest.Models;
using LenaQuest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LenaQuest.Controllers
{
    /// <summary>
    /// контроллер отвечающий за создание и управление административными ролями пользователей
    /// </summary>
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        // автосвойство возвращающее апи по управлению административными ролями
        private RoleManager<IdentityRole> _roleManager { get; }
        // автосвойство возвращающее апи по управлению пользователями
        private UserManager<User> _userManager { get; }
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // возвращает список ролей пользователей
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        // ГЕТ запрос возвращающий форму для создания роли
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ПОСТ запрос обрабатывающий создание роли, где name - имя роли
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
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
            return View(name);
        }

        // ПОСТ запрос обрабатывающий удаление роли
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        // ГЕТ возвращает список ролей
        [HttpGet]
        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        }

        // ГЕТ запрос обрабатывающий изменение роли пользователя
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        // ПОСТ запрос обрабатывающий изменение роли пользователя
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

    }
}
