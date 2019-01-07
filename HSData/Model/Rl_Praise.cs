namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rl_Praise
    {
        [Key]
        public int Praise_ID { get; set; }

        public int Photo_ID { get; set; }

        public int Strategy_ID { get; set; }

        public int User_ID { get; set; }

        public virtual Tb_Photo Tb_Photo { get; set; }

        public virtual Tb_Strategy Tb_Strategy { get; set; }

        public virtual Tb_User Tb_User { get; set; }
    }
}
