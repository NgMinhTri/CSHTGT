using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("GPLX")]
    public class GPLX
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(250)]
        public string Hang { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }

        [MaxLength(250)]
        public string SoGPLX { get; set; }

        [MaxLength(250)]
        public string TrangThai { get; set; }

        public virtual DonVi DonVi { get; set; }
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; }

    }
}
