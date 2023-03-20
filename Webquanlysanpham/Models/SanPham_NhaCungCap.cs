using System.ComponentModel.DataAnnotations;

namespace Webquanlysanpham.Models
{
    public class SanPham_NhaCungCap
    {
        [Key]
        public long ID { get; set; }

        public long? SanPhamID { get; set; }

        public long? NCCID { get; set; }
    }
}
