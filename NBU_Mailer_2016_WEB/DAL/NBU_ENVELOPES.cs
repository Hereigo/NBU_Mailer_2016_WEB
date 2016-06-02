namespace NBU_Mailer_2016_WEB.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NBU_ENVELOPES
    {
        public int ID { get; set; }

        [StringLength(15)]
        public string FROM { get; set; }

        [StringLength(15)]
        public string TO { get; set; }

        [StringLength(15)]
        public string FILE_NAME { get; set; }

        public int? FILE_SIZE { get; set; }

        [Column(TypeName = "image")]
        [ScaffoldColumn(false)]
        public byte[] FILE_BODY { get; set; }

        public DateTime? FILE_DATE { get; set; }

        public DateTime? DATE_SENT { get; set; }

        public DateTime? DATE_DELIV { get; set; }

        [StringLength(15)]
        public string ENV_NAME { get; set; }

        [StringLength(255)]
        public string ENV_PATH { get; set; }

        public int? SPRUSNBU_BANK_ID { get; set; }

        public virtual SPRUSNBU_BANKS SPRUSNBU_BANKS { get; set; }
    }
}
