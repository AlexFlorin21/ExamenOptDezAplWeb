using Microsoft.EntityFrameworkCore;

namespace Examen_scypt.Models
{
    public class ExamenContext : DbContext
    {
        public DbSet<Examen> Examene { get; set; }

        public DbSet<Produs> Produse { get; set; }

        public DbSet<Utilizator> Utilizators { get; set; }

        public DbSet<Comenzi> Comenzii { get; set; }

        public DbSet<ComenziProdus> ComenziProduse { get; set; }

        public ExamenContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ComenziProdus>()
                .HasKey(cp => new { cp.ComenziId, cp.ProdusId });


            modelBuilder.Entity<ComenziProdus>()
                .HasOne(cp => cp.Comenzi)
                .WithMany(t => t.ComenziProdus)
                .HasForeignKey(cp => cp.ComenziId);

            modelBuilder.Entity<ComenziProdus>()
                .HasOne(cp => cp.Produs)
                .WithMany(u => u.ComenziProdus)
                .HasForeignKey(cp => cp.ComenziId);

            modelBuilder.Entity<Comenzi>()
             .HasOne(u => u.Utilizator)
             .WithMany(c => c.Comenzi)
             .HasForeignKey(u => u.UtilizatorId);
        }
    }
}
