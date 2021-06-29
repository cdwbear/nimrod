namespace ForInterchangeControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PayerReportRaw_T
    {
        [Key]
        public long PayerReportRaw_ID { get; set; }

        public int Output_ID { get; set; }

        public int PayerReportType_ID { get; set; }

        [Required]
        [StringLength(300)]
        public string PayerReportFileName_VC { get; set; }

        [Required]
        public string PayerReportFileContents_MX { get; set; }

        [StringLength(300)]
        public string PayerReportSortingTestDescription_VC { get; set; }

        public DateTime? CreatedDate_DT { get; set; }

        public DateTime? LastUpdate_DT { get; set; }

        public int? PayerReportParseStatus_ID { get; set; }

        public int? ClaimCount_IN { get; set; }

        public bool? VendorReportCreated { get; set; }

        public virtual PayerReportParseStatus_T PayerReportParseStatus_T { get; set; }

        public virtual PayerReportType_T PayerReportType_T { get; set; }
    }
}
