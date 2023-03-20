using System.ComponentModel.DataAnnotations;

namespace Webquanlysanpham.Models
{
    public class SanPham
    {
        [Key]
        public long ID { get; set; }

        public string MaSP { get; set; }

        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public string MoTa { get; set; }
        public int SoLuongSP { get; set; }
        [Range(0, double.MaxValue)]
        public double GiaSP { get; set; }

        public long? DvtID
        {
            get; set;
        }
    }
}
