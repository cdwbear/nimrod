namespace ForInterchangeControl
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CWDBModel : DbContext
    {
        public CWDBModel()
            : base("name=CWDBModel")
        {
        }

        public virtual DbSet<InterchangeControl_T> InterchangeControl_T { get; set; }
        public virtual DbSet<PayerReportParseStatus_T> PayerReportParseStatus_T { get; set; }
        public virtual DbSet<PayerReportRaw_T> PayerReportRaw_T { get; set; }
        public virtual DbSet<PayerReportType_T> PayerReportType_T { get; set; }
        public virtual DbSet<TA1_T> TA1_T { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InterchangeControl_T>()
                .Property(e => e.OutputFileName_VC)
                .IsUnicode(false);

            modelBuilder.Entity<PayerReportParseStatus_T>()
                .Property(e => e.Description_VC)
                .IsUnicode(false);

            modelBuilder.Entity<PayerReportRaw_T>()
                .Property(e => e.PayerReportFileName_VC)
                .IsUnicode(false);

            modelBuilder.Entity<PayerReportRaw_T>()
                .Property(e => e.PayerReportFileContents_MX)
                .IsUnicode(false);

            modelBuilder.Entity<PayerReportRaw_T>()
                .Property(e => e.PayerReportSortingTestDescription_VC)
                .IsUnicode(false);

            modelBuilder.Entity<PayerReportType_T>()
                .Property(e => e.TypeName_VC)
                .IsUnicode(false);

            modelBuilder.Entity<PayerReportType_T>()
                .HasMany(e => e.PayerReportRaw_T)
                .WithRequired(e => e.PayerReportType_T)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TA1_T>()
                .Property(e => e.InterchangeAcknowledgementCode_VC)
                .IsUnicode(false);

            modelBuilder.Entity<TA1_T>()
                .Property(e => e.InterchangeNoteCode_VC)
                .IsUnicode(false);
        }
    }
}
