using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSHTGT.Data.Models
{
    [Table("NguoiThamGiaGiaoThong")]
    public class NguoiThamGiaGiaoThong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
       
        [Required]
        [MaxLength(250)]
        public string HoTen { get; set; }

        [Required]
        [MaxLength(250)]
        public string DiaChi { get; set; }

        [Required]
        [MaxLength(250)]
        public string CMND { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }

        [MaxLength(250)]
        public string QueQuan { get; set; }

        [Required]
        [MaxLength(250)]
        public string SDT { get; set; }

        [Required]
        [MaxLength(250)]
        public string PassWord { get; set; }

        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

        public List<PhuongTien> PhuongTiens { get; set; }
        public List<PhieuDangKyThuTuc> PhieuDangKyThuTucs { get; set; }
        public List<GPLX> GPLXes { get; set; }
        public List<BienBanViPham> BienBanViPhams { get; set; }

       // [ForeignKey("MaDoanhNghiepVanTai")]
        //public virtual DoanhNghiepVanTai DoanhNghiepVanTai { get; set; }
    }
}
