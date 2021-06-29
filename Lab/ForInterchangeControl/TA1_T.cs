namespace ForInterchangeControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TA1_T
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TA1_T()
        {
            InterchangeControl_T = new HashSet<InterchangeControl_T>();
        }

        [Key]
        public int TA1_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string InterchangeAcknowledgementCode_VC { get; set; }

        [Required]
        [StringLength(3)]
        public string InterchangeNoteCode_VC { get; set; }

        public DateTime DateTimeReceived_DT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterchangeControl_T> InterchangeControl_T { get; set; }
    }
}
