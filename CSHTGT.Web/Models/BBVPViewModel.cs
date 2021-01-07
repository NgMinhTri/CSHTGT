using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSHTGT.WebAPI.Models
{
    public class BBVPViewModel
    {
        [Key]
        public int MaBienBan { get; set; }
        [Required]
        public int MaNgTGGiaoThong { get; set; }
        [Required]
        public int MaHinhThucXuPhat { get; set; }
        [Required]
        public int MaCanBo { get; set; }
        [Required]
        public DateTime HanNopPhat { get; set; }
        [Required]
        public string LoiViPham { get; set; }
        [Required]
        public DateTime NgayLap { get; set; }
        [Required]
        public DateTime NgayViPham { get; set; }
        [Required]
        public string SoQuyetDinh { get; set; }
        [Required]
        [Range(10000, int.MaxValue, ErrorMessage = "So tien phat >= 10000")]
        public int SoTienPhat { get; set; }
        [Required]
        public string TinhTrangNopPhat { get; set; }
    }
}
