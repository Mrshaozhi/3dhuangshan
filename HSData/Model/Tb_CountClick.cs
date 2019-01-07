namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_CountClick
    {
        [Key]
        public int CountClick_ID { get; set; }

        public int? CountClick_DayNum { get; set; }

        public DateTime? CountClick_Date { get; set; }
    }
}
