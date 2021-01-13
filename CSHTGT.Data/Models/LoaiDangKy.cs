using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CSHTGT.Data.Models
{
    public class LoaiDangKy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDangKy { get; set; }
        public string KieuDangKy { get; set; }
    }
}
