using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("HoSoThuHoiXe")]
    public class HoSoThuHoiXe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoSo { get; set; }

        [MaxLength(250)]
        public string LyDo { get; set; }
        public DateTime NgayThuHoi { get; set; }
        public virtual PhuongTien PhuongTien { get; set; }
        public virtual CanBo CanBo { get; set; }
    }
}
