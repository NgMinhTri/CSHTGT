using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("PhieuDangKyThuTuc")]
    public class PhieuDangKyThuTuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieu { get; set; }
        public int MaDonVi { get; set; }
        public int MaNgTGGiaoThong { get; set; }
        public DateTime NgayDangKy { get; set; }     

        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong  { get; set; }     

        [ForeignKey("MaDonVi")]
        public virtual DonVi DonVi { get; set; }
        public List<File> Files { get; set; }
    }
}
