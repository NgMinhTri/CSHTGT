using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("HoSoSangTenXe")]
    public class HoSoSangTenXe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoSo { get; set; }

        [MaxLength(250)]
        public string LyDo { get; set; }
        public DateTime NgaySangTen { get; set; }

        public virtual PhuongTien PhuongTien { get; set; }
        public virtual CanBo CanBo { get; set; }

    }
}
