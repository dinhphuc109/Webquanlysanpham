using Webquanlysanpham.Data;


namespace Webquanlysanpham.Models.Dao
{
    public class DonViTinhDao
    {
        private readonly AppDbContext _db;
        public DonViTinhDao(AppDbContext db)
        {
            _db = db;
        }

        public DonViTinhDao()
        {
        }

        public DonViTinh GetById(long id)
        {
            return _db.donViTinhs.Find(id);
        }
        public long Insert(DonViTinh entity)
        {
            var donViTinh = _db.donViTinhs.Find(entity.ID);
            _db.donViTinhs.Add(entity);

            _db.SaveChanges();
            return entity.ID;
        }
        public bool Update(DonViTinh entity)
        {
            try
            {
                var donViTinh = _db.donViTinhs.Find(entity.ID);
                donViTinh.MaDVT = entity.MaDVT;
                donViTinh.DVTinh = entity.DVTinh;

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var donViTinh = _db.donViTinhs.Find(id);
                _db.donViTinhs.Remove(donViTinh);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public long Create(DonViTinh donViTinh)
        {

            _db.donViTinhs.Add(donViTinh);
            _db.SaveChanges();



            return donViTinh.ID;
        }

        public List<DonViTinh> ListAll()
        {
            return _db.donViTinhs.Where(x => x.MaDVT != null).OrderBy(x => x.ID).ToList();
        }
    }
}
