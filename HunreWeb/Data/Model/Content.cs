namespace HunreWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content:Function
    {
        public long ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Name { get; set; }
        public string _meta;
        [StringLength(250)]
        public string MetaTitle { get => _meta; set => _meta = utf8Convert1(Name); }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public long? CatergoryID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }
    }
}
