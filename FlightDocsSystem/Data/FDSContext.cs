using Microsoft.EntityFrameworkCore;

namespace FlightDocsSystem.Data
{
    public class FDSContext : DbContext
    {
        public FDSContext(DbContextOptions<FDSContext> options) : base(options) { }
        // Định nghĩa các thuộc tính để truy cập đến các bảng trong cơ sở dữ liệu
        public DbSet<Document>? Documents { get; set; }
        public DbSet<Aircraft>? Aircrafts { get; set; }
        public DbSet<Flight>? Flights { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<DocumentFlight>? DocumentFlights { get; set; }
        public DbSet<FlightDocServer>? FlightDocServers { get; set; }
        public DbSet<ServerDocument>? ServerDocuments { get; set; }
        public DbSet<UserDocument>? UserDocuments { get; set; }

        // Cấu hình kết nối đến cơ sở dữ liệu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("MyConnectionString");
            }
        }

        // Định nghĩa các phương thức để thực hiện các hoạt động truy vấn dữ liệu và lưu trữ thay đổi
        // ví dụ:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .HasKey(d => d.DocumentId);

            modelBuilder.Entity<Document>()
                .Property(d => d.DocumentName)
                .IsRequired();

            modelBuilder.Entity<Document>()
                .HasMany(d => d.DocumentFlights)
                .WithOne(df => df.Document)
                .HasForeignKey(df => df.DocumentId);

            modelBuilder.Entity<Flight>()
                .HasKey(f => f.FlightId);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.DocumentFlights)
                .WithOne(df => df.Flight)
                .HasForeignKey(df => df.FlightId);
        }
    }
}