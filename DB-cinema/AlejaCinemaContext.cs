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
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string myname = "Aleja_";

            modelBuilder.Entity<Showing>().ToTable(myname + "Showings");          
            modelBuilder.Entity<Chair>().ToTable(myname + "Chairs");
            modelBuilder.Entity<LevelChair>().ToTable(myname + "Levels_Chair");
            modelBuilder.Entity<Ticket>().ToTable(myname + "Tickets");
            modelBuilder.Entity<Sale>().ToTable(myname + "Sales");
            modelBuilder.Entity<Schedule>().ToTable(myname + "Schedule");
        }
    }
}