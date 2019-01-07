namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_CountAddress
    {
        [Key]
        public int CountAddress_ID { get; set; }

        [StringLength(50)]
        public string CountAddress_IP { get; set; }

        [StringLength(50)]
        public string CountAddress_Address { get; set; }

        public int? CountAddress_Num { get; set; }
    }
}
