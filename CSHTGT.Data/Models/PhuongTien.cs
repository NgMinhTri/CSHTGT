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

        [Required]
        [MaxLength(250)]
        public string TenPT { get; set; }

        [Required]
        [MaxLength(20)]
        public string BienSo { get; set; }

        [Required]
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

        [ForeignKey("MaLoaiPT")]
        public virtual LoaiPhuongTien LoaiPhuongTien { get; set; }

        [ForeignKey("MaNgTGGiaoThong")]
        public virtual NguoiThamGiaGiaoThong NguoiThamGiaGiaoThong { get; set; }
       
    }
}
