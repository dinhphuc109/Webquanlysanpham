using System.ComponentModel.DataAnnotations;

namespace Webquanlysanpham.Models
{
    public class NhaCungCap
    {
        [Key]
        public long ID { get; set; }

        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }
}
