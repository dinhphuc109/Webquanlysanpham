using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webquanlysanpham.Data;
using Webquanlysanpham.Models;
using Webquanlysanpham.Models.Dao;

namespace Webquanlysanpham.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly AppDbContext _db;
        public SanPhamController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanPhamsList = _db.sanPhams;
            return View(sanPhamsList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<DonViTinh> donViTinhList = new List<DonViTinh>();
            donViTinhList = (from donViTinhs in _db.donViTinhs
                             select donViTinhs).ToList();
            donViTinhList.Insert(0, new DonViTinh { ID = 0, MaDVT = "Select" });
            ViewBag.ListofdonViTinh = donViTinhList;
            ViewBag.Listdonvitinh = new SelectList(_db.donViTinhs.ToList(), "ID", "MaDVT");
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham model)
        {
            List<DonViTinh> donViTinhList = new List<DonViTinh>();
            donViTinhList = (from donViTinhs in _db.donViTinhs
                             select donViTinhs).ToList();
            donViTinhList.Insert(0, new DonViTinh { ID = 0, MaDVT = "Select" });
            ViewBag.ListofdonViTinh=donViTinhList;
            if (ModelState.IsValid)
            {
                _db.sanPhams.Add(model);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Tao Thanh Cong";
                return RedirectToAction("Index");
            }
            SetViewBag();
            
            return View("Index");
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new DonViTinhDao();
            ViewBag.donViTinhID = new SelectList(ListAll(), "ID", "MaDVT", selectedId);
        }
        public List<DonViTinh> ListAll()
        {
            return _db.donViTinhs.Where(x => x.MaDVT != null).OrderBy(x => x.ID).ToList();
        }

        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SanPhamFromDb = _db.sanPhams.Find(id);
            if (SanPhamFromDb == null)
            {
                return NotFound();
            }
            ViewBag.Listdonvitinh = new SelectList(_db.donViTinhs.ToList(), "ID", "MaDVT");
            return View(SanPhamFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SanPham obj)
        {
            if (ModelState.IsValid)
            {
                _db.sanPhams.Update(obj);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Sua Thanh Cong";
                return RedirectToAction("Index");
            }
            ViewBag.Listdonvitinh = new SelectList(_db.donViTinhs.ToList(), "ID", "MaDVT");
            return View(obj);

        }

        [HttpGet]
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SanPhamFromDb = _db.sanPhams.Find(id);
            if (SanPhamFromDb == null)
            {
                return NotFound();
            }
            return View(SanPhamFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(long? id)
        {
            var obj = _db.sanPhams.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.sanPhams.Remove(obj);
            _db.SaveChanges();
            TempData["Thanh cong"] = "Xoa Thanh Cong";
            return RedirectToAction("Index");


        }
    }
}
