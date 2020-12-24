using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("HoSoThuHoiXe")]
    public class HoSoThuHoiPhuongTien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoSo { get; set; }
        public int MaPhuongTien { get; set; }
        public int MaCanBo { get; set; }

        [MaxLength(250)]
        public string LyDo { get; set; }
        public DateTime NgayThuHoi { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }

        [ForeignKey("MaCanBo")]
        public virtual CanBo CanBo { get; set; }
    }
}
