namespace HSData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tb_Photo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Photo()
        {
            Rl_Praise = new HashSet<Rl_Praise>();
        }

        [Key]
        public int Photo_ID { get; set; }

        [StringLength(50)]
        public string Photo_Name { get; set; }

        [StringLength(50)]
        public string Photo_Path { get; set; }

        public DateTime? Photo_UploadTime { get; set; }

        [StringLength(50)]
        public string Photo_Check { get; set; }

        public int? Photo_Praise { get; set; }

        public int User_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rl_Praise> Rl_Praise { get; set; }

        public virtual Tb_User Tb_User { get; set; }
    }
}
