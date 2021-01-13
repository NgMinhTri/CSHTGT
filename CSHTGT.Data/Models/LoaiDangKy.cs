using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("LoaiDangKy")]
    public class LoaiDangKy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDangKy { get; set; }
        public int KieuDangKy { get; set; }
        public List<PhieuDangKyThuTuc> PhieuDangKyThuTucs { get; set; }

    }
}
