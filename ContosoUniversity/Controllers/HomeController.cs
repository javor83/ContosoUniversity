using ContosoUniversity.DatabaseFolder;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContosoUniversity.Controllers
{
    public class HomeController(IStudentList student) : Controller
    {
        //****************************************************************************
        public IActionResult Index()
        {
            IEnumerable<SItem> list = student.ReadStudents();
            return View(list);
        }
        //****************************************************************************

        public IActionResult Insert()
        {
            return View(SItem.Empty());
        }
        //****************************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Insert(SItem sender)
        {
            return View(SItem.Empty());
        }
        //****************************************************************************
        public IActionResult Privacy()
        {
            return View();
        }
        //****************************************************************************
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //****************************************************************************
    }
}
