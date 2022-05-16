namespace HunreWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("catergory")]
    public partial class catergory:Function
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
        public string _meta;
        [StringLength(250)]
        public string MetaTitle { get => _meta; set => _meta = utf8Convert1(Name); }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public long? IDMenu { get; set; }
    }
}
