using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.Data.Models
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
<<<<<<< Updated upstream:CSHTGT.Data/Models/BienBanViPham.cs
        public int MaPhuongTien { get; set; }
        public DateTime NgayViPham { get; set; }
        public DateTime NgayLap { get; set; }
=======
        [Required]
>>>>>>> Stashed changes:CSHTGT.Data/Models/BBVPViewModel.cs
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
<<<<<<< Updated upstream:CSHTGT.Data/Models/BienBanViPham.cs

        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; }

        [ForeignKey("MaHinhThucXuPhat")]
        public virtual HinhThucXuPhat HinhThucXuPhat { get; set; }

        [ForeignKey("MaCanBo")]
        public virtual CanBo CanBo { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }
=======
>>>>>>> Stashed changes:CSHTGT.Data/Models/BBVPViewModel.cs
    }
}
