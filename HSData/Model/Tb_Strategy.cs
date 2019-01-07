namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_Strategy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Strategy()
        {
            Rl_Collect = new HashSet<Rl_Collect>();
            Rl_Praise = new HashSet<Rl_Praise>();
        }

        [Key]
        public int Strategy_ID { get; set; }

        [StringLength(50)]
        public string Strategy_Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Strategy_Content { get; set; }

        public DateTime? Strategy_PublishTime { get; set; }

        [StringLength(50)]
        public string Strategy_ShowPhoto { get; set; }

        [StringLength(50)]
        public string Strategy_Check { get; set; }

        public int? Strategy_Click { get; set; }

        public int? Strategy_Praise { get; set; }

        public int? User_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rl_Collect> Rl_Collect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rl_Praise> Rl_Praise { get; set; }

        public virtual Tb_User Tb_User { get; set; }
    }
}
