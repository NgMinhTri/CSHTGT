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
        public string CMNDNgTGGiaoThongLienQuan { get; set; }
        public DateTime NgayDangKy { get; set; }   
        public int? MaPhuongTien { get; set; }
        public int XetDuyet { get; set; }
        public int MaDangKy { get; set; }

        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong  { get; set; }

        //[ForeignKey("MaNgTGGiaoThong2")]
        //public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong2 { get; set; }

        [ForeignKey("MaDonVi")]
        public virtual DonVi DonVi { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }

        [ForeignKey("MaDangKy")]
        public virtual LoaiDangKy LoaiDangKy { get; set; }

    }
}
