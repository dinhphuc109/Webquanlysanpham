using System.ComponentModel.DataAnnotations;

namespace Webquanlysanpham.Models
{
    public class DonViTinh
    {
        [Key]
        public long ID { get; set; }

        public string MaDVT { get; set; }

        public string DVTinh { get; set; }
    }
}
