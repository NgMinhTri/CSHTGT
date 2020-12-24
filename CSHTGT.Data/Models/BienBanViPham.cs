using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("BienBanViPham")]
    public class BienBanViPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBienBan { get; set; }
        public int MaNgTGGiaoThong { get; set; }
        public int MaHinhThucXuPhat { get; set; }
        public int MaCanBo { get; set; }
        public int MaPhuongTien { get; set; }
        public DateTime NgayViPham { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime HanNopPhat { get; set; }

        [MaxLength(250)]
        public string LoiViPham { get; set; }
        [MaxLength(250)]
        public string SoQuyetDinh { get; set; }
        public int SoTienPhat { get; set; }

        [MaxLength(250)]
        public string TinhTrangNopPhat { get; set; }

        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; }

        [ForeignKey("MaHinhThucXuPhat")]
        public virtual HinhThucXuPhat HinhThucXuPhat { get; set; }

        [ForeignKey("MaCanBo")]
        public virtual CanBo CanBo { get; set; }

        [ForeignKey("MaPhuongTien")]
        public virtual PhuongTien PhuongTien { get; set; }
    }
}
