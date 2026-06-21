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
        public IActionResult Index(string sOrder="")
        {
            //накъде да сочи връзката за следващото сортиране по id...
            ViewData["order_id"] = student.NextOrderType(sOrder, enum_SortStudentOrder.id_asc, enum_SortStudentOrder.id_desc);

            //накъде да сочи връзката за следващото сортиране по име...
            ViewData["order_fname"] = student.NextOrderType(sOrder,enum_SortStudentOrder.fname_asc,enum_SortStudentOrder.fname_desc);
            //накъде да сочи връзката за следващото сортиране по фамилия...
            ViewData["order_lname"] = student.NextOrderType(sOrder, enum_SortStudentOrder.lname_asc, enum_SortStudentOrder.lname_desc);
            //накъде да сочи връзката за следващото сортиране по дата...
            ViewData["order_edate"] = student.NextOrderType(sOrder, enum_SortStudentOrder.edate_asc, enum_SortStudentOrder.edate_desc);

            IEnumerable<SItem> list = student.ReadStudents(sOrder);
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
