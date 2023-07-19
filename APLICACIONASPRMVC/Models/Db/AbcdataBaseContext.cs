using Microsoft.EntityFrameworkCore;

namespace APLICACIONASPRMVC.Models.Db;

public partial class AbcdataBaseContext : DbContext
{
    public AbcdataBaseContext()
    {
    }

    public AbcdataBaseContext(DbContextOptions<AbcdataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Automobile> Automobiles { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOPELKYN7; Database=ABCDataBase; Trusted_Connection=True; trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Automobile>(entity =>
        {
            entity.ToTable("Automobile");

            entity.Property(e => e.AutomobileId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee);

            entity.ToTable("Employee");

            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


