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
        [Display(Name = "Від кого")]
        public string FROM { get; set; }

        [StringLength(15)]
        [Display(Name = "Кому")]
        public string TO { get; set; }

        [StringLength(15)]
        [Display(Name = "Файл")]
        public string FILE_NAME { get; set; }

        public int? FILE_SIZE { get; set; }

        [Column(TypeName = "image")]
        [ScaffoldColumn(false)]
        public byte[] FILE_BODY { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Був змінений")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM HH:mm}")]
        public DateTime? FILE_DATE { get; set; }

        [Display(Name = "Відправлено")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM HH:mm}")]
        public DateTime? DATE_SENT { get; set; }

        [Display(Name = "Отримано")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM HH:mm}")]
        public DateTime? DATE_DELIV { get; set; }

        [StringLength(15)]
        [Display(Name = "Конверт")]
        public string ENV_NAME { get; set; }

        [StringLength(255)]
        public string ENV_PATH { get; set; }

        public int? SPRUSNBU_BANK_ID { get; set; }

        public virtual SPRUSNBU_BANKS SPRUSNBU_BANKS { get; set; }
    }
}
