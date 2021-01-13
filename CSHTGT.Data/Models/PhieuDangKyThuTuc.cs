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
        public int MaNgTGGiaoThong1 { get; set; }
       public int MaNgTGGiaoThong2 { get; set; }
        public int MaPhuongTien { get; set; }
        public DateTime NgayDangKy { get; set; }    
        public int XetDuyet { get; set; }
        public int MaLoaiDangKy { get; set; }

        [ForeignKey("MaNgTGGiaoThong1")]
        
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong1  { get; set; }

        [ForeignKey("MaNgTGGiaoThong2")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong2 { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }

        [ForeignKey("MaDonVi")]
        public virtual DonVi DonVi { get; set; }

        [ForeignKey("MaLoaiDangKy")]
        public virtual LoaiDangKy LoaiDangKy { get; set; }
    }
}
