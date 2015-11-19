<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhoHang.Models.Entities
{
    public class PhieuThuChi
    {
=======
﻿
namespace QuanLyKhoHang.Models.Entities
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThuChi")]
    public partial class PhieuThuChi
    {
        [Key]
        [StringLength(10)]
        public string MaPH { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDT { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHD { get; set; }
        [Required]
        public float GiaTri { get; set; }
        [Required]
        public bool LoaiPhieu { get; set; }
        [Required]
        public DateTime Thoigian { get; set; }
        public virtual DoiTac DoiTac { get; set; }
        public virtual HoaDon HoaDon { get; set; }
>>>>>>> origin/master
    }
}