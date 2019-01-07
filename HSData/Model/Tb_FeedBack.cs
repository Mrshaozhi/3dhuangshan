namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_FeedBack
    {
        [Key]
        public int FeedBack_ID { get; set; }

        [StringLength(50)]
        public string FeedBack_Type { get; set; }

        [Column(TypeName = "ntext")]
        public string FeedBack_Content { get; set; }

        public DateTime? FeedBack_Time { get; set; }

        public int User_ID { get; set; }

        public virtual Tb_User Tb_User { get; set; }
    }
}
