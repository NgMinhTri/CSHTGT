using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("File")]
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MaPhieuThuTuc { get; set; }

        [MaxLength(250)]
        public string TenFile { get; set; }
        public string LinkFile { get; set; }

        [ForeignKey("MaPhieuThuTuc")]
        public virtual PhieuDangKyThuTuc PhieuDangKyThuTuc { get; set; }
    }
}
