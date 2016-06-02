namespace NBU_Mailer_2016_WEB.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<NBU_ENVELOPES> NBU_ENVELOPES { get; set; }
        public virtual DbSet<SPRUSNBU_BANKS> SPRUSNBU_BANKS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPRUSNBU_BANKS>()
                .HasMany(e => e.NBU_ENVELOPES)
                .WithOptional(e => e.SPRUSNBU_BANKS)
                .HasForeignKey(e => e.SPRUSNBU_BANK_ID);
        }
    }
}
