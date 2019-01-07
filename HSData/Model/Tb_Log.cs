namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_Log
    {
        [Key]
        public int Log_ID { get; set; }

        public DateTime? Log_RegisterTime { get; set; }

        [StringLength(50)]
        public string Log_Content { get; set; }

        public int User_ID { get; set; }

        public virtual Tb_User Tb_User { get; set; }
    }
}
