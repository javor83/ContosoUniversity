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
        public async Task<IActionResult> Insert(SItem sender)
        {
            if (ModelState.IsValid)
            {
                await student.Insert(sender);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
                return View(sender);
        }


        //****************************************************************************
        public IActionResult Edit(int id)
        {
            SItem q = student.Element(id);
            if (q == null)
            {
                return BadRequest();
            }
            else
            {
                return View(q);
            }
        }
        //****************************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SItem sender)
        {
            if (ModelState.IsValid)
            {
                await student.Update(sender);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                return View(sender);
            }
        }

        //****************************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await student.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), "Home");

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
