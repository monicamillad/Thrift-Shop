namespace Thrift_Shop
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brand>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .HasMany(e => e.products)
                .WithOptional(e => e.brand)
                .HasForeignKey(e => e.brand_id);

            modelBuilder.Entity<product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.category)
                .IsUnicode(false);
        }
    }
}
