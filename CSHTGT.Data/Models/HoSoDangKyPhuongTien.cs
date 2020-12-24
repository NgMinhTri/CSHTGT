using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("HoSoDangKyXe")]
    public class HoSoDangKyPhuongTien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoSoDK { get; set; }
        public int MaPhuongTien { get; set; }
        public int MaCanBo { get; set; }

        [MaxLength(250)]
        public string LyDo { get; set; }
        public DateTime NgayDangKy { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }

        [ForeignKey("MaCanBo")]
        public virtual CanBo CanBo { get; set; }

    }
}
