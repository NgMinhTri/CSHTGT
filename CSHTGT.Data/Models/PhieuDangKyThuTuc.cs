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
        public DateTime NgayDangKy { get; set; }

        public List<File> Files { get; set; }

        public virtual DonVi DonVi { get; set; }
    }
}
