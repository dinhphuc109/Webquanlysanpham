using Webquanlysanpham.Data;

namespace Webquanlysanpham.Models.Dao
{
    public class SanPhamDao
    {
        public readonly AppDbContext _db;
        public SanPhamDao(AppDbContext db)
        {
            _db = db;
        }
        public SanPham GetById(long id)
        {
            return _db.sanPhams.Find(id);
        }
        public long Insert(SanPham entity)
        {
            var sanPham = _db.sanPhams.Find(entity.ID);
            _db.sanPhams.Add(entity);

            _db.SaveChanges();
            return entity.ID;
        }
        public bool Update(SanPham entity)
        {
            try
            {
                var sanPham = _db.sanPhams.Find(entity.ID);
                sanPham.MaSP = entity.MaSP;
                sanPham.TenSP = entity.TenSP;
                sanPham.LoaiSP = entity.LoaiSP;
                sanPham.MoTa = entity.MoTa;
                sanPham.SoLuongSP = entity.SoLuongSP;
                sanPham.GiaSP = entity.GiaSP;

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(long id)
        {
            try
            {
                var sanPham = _db.sanPhams.Find(id);
                _db.sanPhams.Remove(sanPham);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public long Create(SanPham sanPham)
        {

            _db.sanPhams.Add(sanPham);
            _db.SaveChanges();



            return sanPham.ID;
        }
    }
}
