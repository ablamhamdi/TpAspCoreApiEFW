using APiEntity.Entitys;
using Microsoft.EntityFrameworkCore;

namespace APiEntity.DbCont
{
    public class FormationDbContext : DbContext
    {

        public FormationDbContext(DbContextOptions<FormationDbContext> options) : base(options) { }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Restaurant> Cuisins { get; set; }
        public virtual DbSet<Restaurant> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => new { e.Id }).HasName("PK_Restaurant");
                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
                // Auto-increment      
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(20).IsUnicode(false).IsRequired(true);
                entity.HasMany(e => e.Cuisins).WithOne(r => r.Restaurant).HasForeignKey(p => p.RestaurantId).HasConstraintName("FK_Cuisins_RestaurantId");
                entity.Property(e => e.Description).HasMaxLength(200);
            });
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => new { e.Id }).HasName("PK_Contact"); entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
                // Auto-increment     
                entity.HasOne(e => e.Restaurant).WithOne(m => m.Contact).HasForeignKey<Restaurant>(p => p.ContactId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Restaurant_Contact");
            }); modelBuilder.Entity<Cuisin>(entity =>
            {
                entity.HasKey(e => new { e.Id }).HasName("PK_Cuisin"); entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
                // Auto-increment     
                entity.HasOne(e => e.Restaurant).WithMany(r => r.Cuisins).HasForeignKey(p => p.RestaurantId).HasConstraintName("FK_Cuisins_RestaurantId");
            });
        }
    }
}

