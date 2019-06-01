﻿using Microsoft.AspNetCore.Mvc;
using LenaQuest.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LenaQuest.ViewModels;

namespace LenaQuest.Controllers
{
    /// <summary>
    /// контроллер отвечающий за управление пользователями
    /// </summary>
    public class UsersController : Controller
    {
        // автосвойство возвращающее апи по управлению пользователями
        private UserManager<User> _userManager { get; }

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // ГЕТ запрос возвращающий список пользователей
        // атрибут Authorize отвечает за получение доступа к списку только конкретной роли
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        // ГЕТ запрос возвращающий информацию о пользователе
        [HttpGet]
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

        // ПОСТ запрос обрабатывающий редактирование пользовательских данных
        [HttpPost]
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

        // ПОСТ запрос обрабатывающий редактирование пользовательских данных
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

        // ГЕТ запрос возвращающий форму для сортировки пользователей
        [HttpGet]
        public IActionResult Sort()
        {
            return View();
        }
        // TODO: finish
        [HttpPost]
        public IActionResult Sort(SortViewModel model)
        {
            return View(model);
        }

        // ПОСТ запрос обрабатывающий удаление пользователя
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

    }
}