namespace ForInterchangeControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InterchangeControl_T
    {
        [Key]
        public int InterchangeControl_ID { get; set; }

        public int Output_ID { get; set; }

        public DateTime DateTimeCreated_DT { get; set; }

        [StringLength(50)]
        public string OutputFileName_VC { get; set; }

        public int? TA1_ID { get; set; }

        public virtual TA1_T TA1_T { get; set; }
    }
}
