namespace ForInterchangeControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PayerReportType_T
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PayerReportType_T()
        {
            PayerReportRaw_T = new HashSet<PayerReportRaw_T>();
        }

        [Key]
        public int PayerReportType_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeName_VC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayerReportRaw_T> PayerReportRaw_T { get; set; }
    }
}
