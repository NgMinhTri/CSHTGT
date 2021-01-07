using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("DonVi")]
    public class DonVi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDonVi { get; set; }

        [MaxLength(250)]
        public string TenDonVi { get; set; }

        [MaxLength(250)]
        public string DiaDiem { get; set; }

        [MaxLength(250)]
        public string NhiemVu { get; set; }

        public List<PhieuDangKyThuTuc> PhieuDangKyThuTucs { get; set; }
        public List<GPLX> GPLXes { get; set; }
        public List<CanBo> CanBos { get; set; }
       // public List<PhuongTien> PhuongTien { get; set; }
    }
}
