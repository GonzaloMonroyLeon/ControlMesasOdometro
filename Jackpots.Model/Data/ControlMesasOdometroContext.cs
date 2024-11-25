using ControlMesasOdometro.ControlMesasOdometro;
using Microsoft.EntityFrameworkCore;

namespace ControlMesasOdometroApi.Data
{
    public class ControlMesasOdometroContext : DbContext
    {
        public ControlMesasOdometroContext()
        {
        }

        public ControlMesasOdometroContext(DbContextOptions<ControlMesasOdometroContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
        }

        public virtual DbSet<ControlMesasOdometroModel> Jackpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}