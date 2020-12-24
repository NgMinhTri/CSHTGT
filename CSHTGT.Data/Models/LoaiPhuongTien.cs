using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSHTGT.Data.Models
{
    [Table("LoaiPhuongTien")]
    public class LoaiPhuongTien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

       
        [MaxLength(250)]
        public string TenLoai { get; set; }

        [MaxLength(250)]
        public string MoTa { get; set; }
        public List<PhuongTien> PhuongTiens { get; set; }
    }
}
