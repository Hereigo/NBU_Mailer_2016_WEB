namespace NBU_Mailer_2016_WEB.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPRUSNBU_BANKS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPRUSNBU_BANKS()
        {
            NBU_ENVELOPES = new HashSet<NBU_ENVELOPES>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(6)]
        public string IDHOST { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Кореспондент")]
        public string FNHOST { get; set; }

        public int? MFOM { get; set; }

        public int? OKPO { get; set; }

        [StringLength(30)]
        public string KTELE { get; set; }

        [StringLength(50)]
        public string KFASE { get; set; }

        public bool? PARTNER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NBU_ENVELOPES> NBU_ENVELOPES { get; set; }
    }
}
