namespace HTC_SHOPVIP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            CTDonHangs = new HashSet<CTDonHang>();
            SP_anh = new HashSet<SP_anh>();
            SP_Danhgia = new HashSet<SP_Danhgia>();
            //khuyenmais = new HashSet<khuyenmai>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        public int? Gia { get; set; }

        public int MaloaiSP { get; set; }

        public int? Sltrongkho { get; set; }

    

        public string mota { get; set; }


   
        public int ? MaNguoiBan { get; set; }

        public int? MaHangSx { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }

        public virtual HangSanXuat HangSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SP_anh> SP_anh { get; set; }

        public virtual SP_Theloai SP_Theloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SP_Danhgia> SP_Danhgia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<khuyenmai> khuyenmais { get; set; }
    }
}
