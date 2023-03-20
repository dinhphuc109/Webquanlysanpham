using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webquanlysanpham.Data;
using Webquanlysanpham.Models;

namespace Webquanlysanpham.Controllers
{
    public class SanPham_NhaCungCapController : Controller
    {
        private readonly AppDbContext _db;
        public SanPham_NhaCungCapController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham_NhaCungCap> sanPhams_nhaCungCapList = _db.sanPham_NhaCungCaps;
            return View(sanPhams_nhaCungCapList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Listnhacungcap = new SelectList(_db.nhaCungCaps.ToList(), "ID", "TenNCC");
            ViewBag.Listsanpham = new SelectList(_db.sanPhams.ToList(), "ID", "TenSP");           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham_NhaCungCap model)
        {
            ViewBag.Listnhacungcap = new SelectList(_db.nhaCungCaps.ToList(), "ID", "TenNCC");
            ViewBag.Listsanpham = new SelectList(_db.sanPhams.ToList(), "ID", "TenSP");
            if (ModelState.IsValid)
            {
                
                _db.sanPham_NhaCungCaps.Add(model);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Tao Thanh Cong";
                return RedirectToAction("Index");
            }


            return View("Index");
        }
    }
}
