using System.Threading.Tasks;
using LenaQuest.Models;
using LenaQuest.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LenaQuest.Controllers
{
    /// <summary>
    /// контроллер отвечающий за регистрацию новых пользователей и их вход в систему
    /// </summary>
    public class AccountController : Controller
    {

        // автосвойство возвращающее апи по управлению пользователями
        private UserManager<User> _userManager { get; }
        //автосвойство возвращающее апи по управлению авторизации пользователей
        private SignInManager<User> _signInManager { get; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ГЕТ запрос возвращающий форму для регистрации пользователя
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ПОСТ запрос принимающий и обрабатывающий модель с формы регистрации
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // все ли свойства модели были переданы с формы
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    City = model.City,
                    Age = model.Age
                };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // обработка ошибок возникающих при регистрации
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        // ГЕТ запрос возвращающий форму для авторизации пользователя
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return PartialView(new LoginViewModel { ReturnUrl = returnUrl });
        }

        // ПОСТ запрос принимающий и обрабатывающий модель с формы авторизации
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        // при отсутствии адреса перенаправления возвращаем пользователя на стартовую страницу
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        // ПОСТ запрос обрабатывающий выход пользователя из учётной записи
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}