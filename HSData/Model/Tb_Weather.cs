namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_Weather
    {
        [Key]
        public int Weather_ID { get; set; }

        [StringLength(50)]
        public string Weather_Type { get; set; }

        [StringLength(50)]
        public string Weather_WindDirection { get; set; }

        [StringLength(50)]
        public string Weather_WindSpeed { get; set; }

        [StringLength(50)]
        public string Weather_TemperMax { get; set; }

        [StringLength(50)]
        public string Weather_TemperMin { get; set; }

        public DateTime? Weather_Date { get; set; }
    }
}
