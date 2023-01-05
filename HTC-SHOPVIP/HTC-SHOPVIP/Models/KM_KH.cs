using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTC_SHOPVIP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("KM_KH")]
    public partial class KM_KH
    {
        public khuyenmai khuyenmai { get; set; }
        public Khachhang khachhang { get; set; }
        [Key, Column(Order = 1)]
        public int MaKM { get; set; }
        [Key, Column(Order = 2)]
        public int MaKH { get; set; }
    }
}