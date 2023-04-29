using Microsoft.EntityFrameworkCore;

namespace DB_cinema
{
    public class AlejaCinemaContext : DbContext
    {
        public AlejaCinemaContext(DbContextOptions<AlejaCinemaContext> options) : base(options)
        {
      
        }

        public DbSet<Showing> Showings { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<LevelChair> Levels { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string myname = "Aleja_";

            modelBuilder.Entity<Showing>().ToTable(myname + "Showings");          
            modelBuilder.Entity<Chair>().ToTable(myname + "Chairs");
            modelBuilder.Entity<LevelChair>().ToTable(myname + "Levels_Chair");
            modelBuilder.Entity<Ticket>()
                /*.HasOne<Showing>()
                .WithMany()
                .HasForeignKey(show => show.IdShowing)
                .OnDelete(DeleteBehavior.Cascade)*/
                .ToTable(myname + "Tickets");

            modelBuilder.Entity<Sale>()
                /*.HasOne<Showing>()
                .WithMany()
                .HasForeignKey(sale => sale.ShowingID)
                .OnDelete(DeleteBehavior.Cascade)*/
                .ToTable(myname + "Sales");
        }
    }
}