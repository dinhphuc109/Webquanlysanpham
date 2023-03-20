using Microsoft.AspNetCore.Mvc;
using Webquanlysanpham.Data;
using Webquanlysanpham.Models;

namespace Webquanlysanpham.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly AppDbContext _db;
        public NhaCungCapController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<NhaCungCap> nhaCungCapsList = _db.nhaCungCaps;
            return View(nhaCungCapsList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhaCungCap obj)
        {
            if (ModelState.IsValid)
            {
                _db.nhaCungCaps.Add(obj);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Tao Thanh Cong";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var NhaCungCapFromDb = _db.nhaCungCaps.Find(id);
            if (NhaCungCapFromDb == null)
            {
                return NotFound();
            }
            return View(NhaCungCapFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NhaCungCap obj)
        {
            if (ModelState.IsValid)
            {
                _db.nhaCungCaps.Update(obj);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Sua Thanh Cong";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var NhaCungCapFromDb = _db.nhaCungCaps.Find(id);
            if (NhaCungCapFromDb == null)
            {
                return NotFound();
            }
            return View(NhaCungCapFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.nhaCungCaps.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.nhaCungCaps.Remove(obj);
            _db.SaveChanges();
            TempData["Thanh cong"] = "Xoa Thanh Cong";
            return RedirectToAction("Index");

        }
    }
}
