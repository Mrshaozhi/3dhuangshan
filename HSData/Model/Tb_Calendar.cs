namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_Calendar
    {
        [Key]
        public int Calendar_ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Calendar_Content { get; set; }

        public DateTime? Calendar_BeginTime { get; set; }

        public DateTime? Calendar_EndTime { get; set; }

        public int User_ID { get; set; }

        public virtual Tb_User Tb_User { get; set; }
    }
}
