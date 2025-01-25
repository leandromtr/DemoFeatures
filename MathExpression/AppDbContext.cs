using mathExpression.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mathExpression
{
    public class AppDbContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MathExpression> MathExpressions { get; set; }
        public DbSet<MathExpressionSensor> MathExpressionSensors { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MathExpressionSensor>()
             .HasKey(mes => new { mes.MathExpressionId, mes.SensorId });

            modelBuilder.Entity<MathExpressionSensor>()
                .HasOne(mes => mes.MathExpression)
                .WithMany(m => m.MathExpressionSensors)
                .HasForeignKey(mes => mes.MathExpressionId);

            modelBuilder.Entity<MathExpressionSensor>()
                .HasOne(mes => mes.Sensor)
                .WithMany(s => s.MathExpressionSensors)
                .HasForeignKey(mes => mes.SensorId);

            modelBuilder.Entity<Sensor>().HasData(
                new Sensor { Id = 1, Name = "Sensor1", Value = 42.5m },
                new Sensor { Id = 2, Name = "Sensor2", Value = 101.3m },
                new Sensor { Id = 3, Name = "Sensor3", Value = 55.7m },
                new Sensor { Id = 4, Name = "Sensor4", Value = 76m },
                new Sensor { Id = 5, Name = "Sensor5", Value = 89.9m }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Carregar configurações do arquivo appsettings.json
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
