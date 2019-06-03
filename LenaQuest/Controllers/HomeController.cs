using Microsoft.AspNetCore.Mvc;

namespace LenaQuestQuest.Controllers
{
    /// <summary>
    /// контроллер отвечающий за домашнюю страницу
    /// </summary>
    public class HomeController : Controller
    {
        // возвращает главную страницу сайта
        public IActionResult Index()
        {
            return View();
        }

        // возвращает частичное представление истории компании
        public IActionResult History()
        {
            return PartialView();
        }

        // возвращает частичное представление информации о компании
        public IActionResult AboutUs()
        {
            return PartialView();
        }

        // возвращает частичное представление галереи
        public IActionResult Gallery()
        {
            return PartialView();
        }

        // возвращает частичное представление о себе
        public IActionResult AboutMe()
        {
            return PartialView();
        }
    }
}
