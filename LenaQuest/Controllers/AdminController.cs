using LenaQuest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace LenaQuest.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // автосвойство возвращающее апи по управлению пользователями
        private UserManager<User> _userManager { get; }

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExportUsers()
        {
            var users = _userManager.Users;

            if (users == null)
            {
                return NotFound();
            }

            return ExportToExcel(users, "users " + DateTime.Now.ToString());
        }

        FileStreamResult ExportToExcel(IEnumerable<User> dataSet, string fileName)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].LoadFromCollection(dataSet, true);

            return File(new MemoryStream(excel.GetAsByteArray()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName + ".xlsx");
        }
    }
}