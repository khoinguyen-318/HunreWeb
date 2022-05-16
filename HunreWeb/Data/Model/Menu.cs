namespace HunreWeb.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu:Function
    {
        public long ID { get; set; }

        public string Name { get; set; }
        public string _meta;
        public string Metatitle { get => _meta; set => _meta = utf8Convert1(Name); }

        public int? DisplayOrder { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}
