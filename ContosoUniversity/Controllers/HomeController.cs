using ContosoUniversity.DatabaseFolder;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContosoUniversity.Controllers
{
    public class HomeController(IStudentList student) : Controller
    {


        #region insert
        //****************************************************************************

        public IActionResult Insert()
        {
            return View(SItem.Empty());
        }
        //****************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
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
        #endregion

        #region edit
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
        [HttpPost, ValidateAntiForgeryToken]
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
        #endregion

        #region delete
        //****************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await student.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }
        #endregion


        public IActionResult Details(int id)
        {
            GradeDetails details = student.Details(id);
            if (details == null)
            {
                return NotFound();
            }
            else return View(details);


        }

        //****************************************************************************
        public IActionResult Index(int scolumn = (int)enum_ColumnStudent.ID, int sorder = (int)enum_SortType.Asc)
        {


            var k = new VDSort()
            {
                Column = (enum_ColumnStudent)scolumn,
                Order = (enum_SortType)sorder
            };

            string gl = k.Glyph();

            ViewData["scolumn"] = k;


          
            IEnumerable<SItem> list = student.ReadStudents(k);
            return View(list);
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
