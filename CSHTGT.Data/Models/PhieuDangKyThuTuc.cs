﻿using CSHTGT.Data.Models;
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

        public int MaNgTGGiaoThong { get; set; }

        public string CMNDNgLienQuan { get; set; }

        public DateTime NgayDangKy { get; set; }

        public int XetDuyet { get; set; }

        public string LoaiDangKy { get; set; }

        public string TenPT { get; set; }

        public string BienSo { get; set; }

        public string NhanHieu { get; set; }

        public int SoChoNgoi { get; set; }

        public string SoKhung { get; set; }

        public string SoMay { get; set; }


        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; }
    }
}
