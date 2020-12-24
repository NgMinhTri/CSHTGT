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

        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; }
        public virtual HinhThucXuPhat HinhThucXuPhat { get; set; }
        public virtual CanBo CanBo { get; set; }
    }
}
