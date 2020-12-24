using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("HoSoSangTenXe")]
    public class HoSoSangTenPhuongTien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoSo { get; set; }
        public int MaPhuongTien { get; set; }
        public int MaCanBo { get; set; }

        [MaxLength(250)]
        public string LyDo { get; set; }
        public DateTime NgaySangTen { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }

        [ForeignKey("MaCanBo")]
        public virtual CanBo CanBo { get; set; }

    }
}
