using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("PhuongTien")]
    public class PhuongTien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPT { get; set; }
        public int MaLoaiPT { get; set; }
        public int MaNgTGGiaoThong { get; set; }
        public int MaDonVi { get; set; }

        [MaxLength(250)]
        public string TenPT { get; set; }       
        [MaxLength(20)]
        public string BienSo { get; set; }          

        [MaxLength(250)]
        public string NhanHieu { get; set; }

        public int SoChoNgoi { get; set; }

        [MaxLength(250)]
        public string SoKhung { get; set; }

        [MaxLength(250)]
        public string SoMay { get; set; }

        [MaxLength(250)]
        public string TaiTrong { get; set; }

        [MaxLength(250)]
        public string TrangThai { get; set; }

        [MaxLength(250)]
        public string LoaiDangKy { get; set; }

        [ForeignKey("MaLoaiPT")]
        public virtual LoaiPhuongTien LoaiPhuongTien { get; set; }

        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; } 

        [ForeignKey("MaDonVi")]
        public virtual DonVi DonVi { get; set; }
        
        public virtual HoSoDangKyPhuongTien HoSoDangKyPhuongTien { get; set; }

        public virtual HoSoThuHoiPhuongTien HoSoThuHoiPhuongTien { get; set; }

        public virtual HoSoSangTenPhuongTien HoSoSangTenPhuongTien { get; set; }

        public List<BienBanViPham> BienBanViPhams { get; set; }
    }
}
