using Microsoft.EntityFrameworkCore;
using Webquanlysanpham.Models;

namespace Webquanlysanpham.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<SanPham_NhaCungCap> sanPham_NhaCungCaps { get; set; }
        public DbSet<DonViTinh> donViTinhs { get; set; }
    }
}
