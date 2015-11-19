namespace QuanLyKhoHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuCuaHang")]
    public partial class ChuCuaHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuCuaHang()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        [StringLength(50)]
        public string TenTK { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string SDT { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string Pwd { get; set; }

        [Required]
        [StringLength(10)]
        public string MaCH { get; set; }

        public virtual CuaHang CuaHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
