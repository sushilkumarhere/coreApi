using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exceltosql.Controllers
{
    public class His_IPD_Admission : Controller
    {
        // GET: His_IPD_Admission
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: His_IPD_Admission/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: His_IPD_Admission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: His_IPD_Admission/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: His_IPD_Admission/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: His_IPD_Admission/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: His_IPD_Admission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: His_IPD_Admission/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
