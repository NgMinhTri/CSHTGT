using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("HinhThucXuPhat")]
    public class HinhThucXuPhat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHinhThuc { get; set; }

        [MaxLength(250)]
        public string TenHinhThuc { get; set; }

        [MaxLength(250)]
        public string MoTa { get; set; }

        public List<BienBanViPham> BienBanViPhams { get; set; }
    }
    
}
