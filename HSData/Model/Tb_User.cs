namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_User()
        {
            Rl_Collect = new HashSet<Rl_Collect>();
            Rl_Praise = new HashSet<Rl_Praise>();
            Tb_Calendar = new HashSet<Tb_Calendar>();
            Tb_FeedBack = new HashSet<Tb_FeedBack>();
            Tb_Log = new HashSet<Tb_Log>();
            Tb_Photo = new HashSet<Tb_Photo>();
            Tb_Strategy = new HashSet<Tb_Strategy>();
        }

        [Key]
        public int User_ID { get; set; }

        [StringLength(50)]
        public string User_Name { get; set; }

        [StringLength(50)]
        public string User_PW { get; set; }

        [StringLength(50)]
        public string User_Email { get; set; }

        [StringLength(50)]
        public string User_Photo { get; set; }

        [StringLength(50)]
        public string User_Sex { get; set; }

        [StringLength(50)]
        public string User_Theme { get; set; }

        public int? User_Level { get; set; }

        public DateTime? User_RegisterTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rl_Collect> Rl_Collect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rl_Praise> Rl_Praise { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Calendar> Tb_Calendar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_FeedBack> Tb_FeedBack { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Log> Tb_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Photo> Tb_Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Strategy> Tb_Strategy { get; set; }
    }
}
