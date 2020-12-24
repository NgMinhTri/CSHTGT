using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("DoanhNghiepVanTai")]
    public class DoanhNghiepVanTai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(250)]
        public string TenDN { get; set; }

        [MaxLength(250)]
        public string DiaChi { get; set; }

        [MaxLength(250)]
        public string TinhTrang { get; set; }

        public List<NguoiThamGiaGiaoThong> NguoiThamGiaGiaoThongs { get; set; }
    }
}
