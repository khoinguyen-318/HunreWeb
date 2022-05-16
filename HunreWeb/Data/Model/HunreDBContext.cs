using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HunreWeb.Data.Model
{
    public partial class HunreDBContext : DbContext
    {
        public HunreDBContext()
            : base("name=HunreDBContext")
        {
        }

        public virtual DbSet<catergory> catergories { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<HeadLine> HeadLines { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
