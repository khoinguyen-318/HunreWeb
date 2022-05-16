namespace HunreWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HeadLine")]
    public partial class HeadLine
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
