using Microsoft.EntityFrameworkCore;

namespace Caravans.Models;

public partial class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.Migrate();

    }

    public DbSet<Caravan> Caravans { get; set; }

    public DbSet<Caravanmodel> Caravanmodels { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {      
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Caravanmodel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK_caravanmodels_modelID");

            entity.ToTable("caravanmodels");

            entity.Property(e => e.ModelId).HasColumnName("modelID");
            entity.Property(e => e.Fridge).HasColumnName("fridge");
            entity.Property(e => e.HotWater).HasColumnName("hotWater");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.LengthInside).HasColumnName("lengthInside");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.People).HasColumnName("people");
            entity.Property(e => e.Picture)
                .HasMaxLength(100)
                .HasColumnName("picture");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Producer)
                .HasMaxLength(50)
                .HasColumnName("producer");
            entity.Property(e => e.Shower).HasColumnName("shower");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.WidthInside).HasColumnName("widthInside");
        });

        modelBuilder.Entity<Caravan>(entity =>
        {
            entity.HasKey(e => e.CaravanId).HasName("PK_caravans_caravanID");

            entity.ToTable("caravans");

            entity.Property(e => e.CaravanId).HasColumnName("caravanID");
            entity.Property(e => e.ModelId).HasColumnName("modelID");
            entity.Property(e => e.NumberPlate)
                .HasMaxLength(7)
                .HasColumnName("numberPlate");

            entity.HasOne(d => d.Model).WithMany(p => p.Caravans)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_caravans_caravanmodels");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK_reservations_reservationID");

            entity.ToTable("reservations");

            entity.Property(e => e.ReservationId).HasColumnName("reservationID");
            entity.Property(e => e.ReservationBegin)
                .HasColumnType("date")
                .HasColumnName("reservationBegin");
            entity.Property(e => e.CaravanId).HasColumnName("caravanID");
            entity.Property(e => e.ReservationEnd)
                .HasColumnType("date")
                .HasColumnName("reservationEnd");
            entity.Property(e => e.ReservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("reservationDate");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Caravan).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CaravanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reservations_caravans");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reservations_users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_users_userID");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName"); 

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            entity.Property(e => e.Password)
                .HasMaxLength(70)
                .HasColumnName("password");
        });

        modelBuilder.Entity<User>().HasData(
            new
            {
                UserId = Guid.Parse("DCD6F633-D9A3-48D7-9A2D-08DB5DA24AA6"),
                FirstName = "Damian",
                LastName = "Oliwa",
                Email = "test@test.pl",
                Password = "$2a$11$12GeW/LeEDmL0BERCSsv/efXn5I8HGQ2gVdX9GUDnHWM6eCErsU2a"
            });

        modelBuilder.Entity<Caravanmodel>().HasData(
            new
            {
                ModelId = Guid.Parse("A9FF9DD4-73F4-4C4D-9479-5DC186B012DE"),
                Producer = "Hobby",
                Model = "DeLuxe 400 SFE",
                Price = 120.00m,
                Weight = 1300,
                Length = 2633,
                LengthInside = 1950,
                Width= 2300,
                WidthInside= 2172,
                People = 3,
                Water = 25,
                HotWater = true,
                Shower = false,
                Fridge = true,
                Picture = "Hobby-DeLuxe-400-SFE.jpg"
            },
            new
            {
                ModelId = Guid.Parse("A2E32450-F315-4541-9AD6-2F9CBF5AD1E9"),
                Producer = "Hobby",
                Model = "DeLuxe 490 KMF",
                Price = 200.00m,
                Weight = 1252,
                Length = 6888,
                LengthInside = 5696,
                Width = 2300,
                WidthInside = 2172,
                People = 5,
                Water = 25,
                HotWater = true,
                Shower = true,
                Fridge = true,
                Picture = "Hobby-DeLuxe-490-KMF.jpg"
            },
            new
            {
                ModelId = Guid.Parse("5CC10DEC-3F4D-451B-82FE-28A59384D3ED"),
                Producer = "Hobby",
                Model = "Prestige 650 UMFe",
                Price = 250.00m,
                Weight = 1662,
                Length = 7154,
                LengthInside = 6840,
                Width = 2500,
                WidthInside = 2367,
                People = 5,
                Water = 50,
                HotWater = true,
                Shower = true,
                Fridge = true,
                Picture = "Hobby-Prestige-650-UMFe.jpg"
            },
            new
            {
                ModelId = Guid.Parse("299DA786-B3BB-488C-B628-1698A1B40210"),
                Producer = "KNAUS",
                Model = "Sudwind 580 QS Silver",
                Price = 240.00m,
                Weight = 1260,
                Length = 7850,
                LengthInside = 5680,
                Width = 2500,
                WidthInside = 2340,
                People = 5,
                Water = 25,
                HotWater = true,
                Shower = true,
                Fridge = true,
                Picture = "KNAUS-Sudwind-580-QS-Silver.jpg"
            },
            new
            {
                ModelId = Guid.Parse("21146366-09AD-420B-B6FB-6DC3B4D22EC2"),
                Producer = "BUERSNTER ",
                Model = "PREMIO LIFE 420 TS",
                Price = 100.00m,
                Weight = 1100,
                Length = 4930,
                LengthInside = 4200,
                Width = 2120,
                WidthInside = 2050,
                People = 3,
                Water = 12,
                HotWater = true,
                Shower = false,
                Fridge = true,
                Picture = "premio-life-420-ts.jpg"
            },
            new
            {
                ModelId = Guid.Parse("BF211DFD-C764-4B8B-AFC8-97C252C56337"),
                Producer = "BUERSNTER",
                Model = "PREMIO 495 TK",
                Price = 250.00m,
                Weight = 1160,
                Length = 5870,
                LengthInside = 5250,
                Width = 2320,
                WidthInside = 2150,
                People = 5,
                Water = 44,
                HotWater = true,
                Shower = true,
                Fridge = true,
                Picture = "PREMIO-495-TK.jpg"
            }
        );

        modelBuilder.Entity<Caravan>().HasData(
            new
            {
                CaravanId = Guid.Parse("EB6E972E-FA5B-4627-BCC7-B676A60BD076"),
                NumberPlate = "RZ8429D",
                ModelId = Guid.Parse("A2E32450-F315-4541-9AD6-2F9CBF5AD1E9")
            },
            new 
            {
                CaravanId = Guid.Parse("EBDBC5CA-2FD4-4E4E-9213-A8AC3EBB42D8"),
                NumberPlate = "RZ3BC54",
                ModelId = Guid.Parse("5CC10DEC-3F4D-451B-82FE-28A59384D3ED")
            },
            new 
            {
                CaravanId = Guid.Parse("ED844936-BAB0-412E-83AC-C12F62E4A271"),
                NumberPlate = "RZAF542",
                ModelId = Guid.Parse("A9FF9DD4-73F4-4C4D-9479-5DC186B012DE")
            },
            new 
            {
                CaravanId = Guid.Parse("0AB40796-EBC0-4279-83DE-30E5F3ED1049"),
                NumberPlate = "RZJF35H",
                ModelId = Guid.Parse("A2E32450-F315-4541-9AD6-2F9CBF5AD1E9")
            },
            new 
            {
                CaravanId = Guid.Parse("3279B0A5-D782-4C45-A27A-534DAF9F2ED8"),
                NumberPlate = "RZD2F5S",
                ModelId = Guid.Parse("21146366-09AD-420B-B6FB-6DC3B4D22EC2")
            },
            new 
            {
                CaravanId = Guid.Parse("78004928-164C-4679-A416-A9508825ABD9"),
                NumberPlate = "RZF2G15",
                ModelId = Guid.Parse("299DA786-B3BB-488C-B628-1698A1B40210")
            },
            new 
            {
                CaravanId = Guid.Parse("114C99B9-89A2-44D9-A6F6-EEF2598DCE2E"),
                NumberPlate = "RZ5F2D3",
                ModelId = Guid.Parse("BF211DFD-C764-4B8B-AFC8-97C252C56337")
            },
            new 
            {
                CaravanId = Guid.Parse("CC8323CE-88A6-4BCA-BF85-F5442F6202BB"),
                NumberPlate = "RZG3S6F",
                ModelId = Guid.Parse("A2E32450-F315-4541-9AD6-2F9CBF5AD1E9")
            },
            new 
            {
                CaravanId = Guid.Parse("8B1EE81B-A5CB-4B08-9DB4-69D8914C26E3"),
                NumberPlate = "RZ47336",
                ModelId = Guid.Parse("A9FF9DD4-73F4-4C4D-9479-5DC186B012DE")
            },
            new 
            {
                CaravanId = Guid.Parse("03A77CEF-431A-4CD9-921E-5B4D5C473830"),
                NumberPlate = "RZH4ND6",
                ModelId = Guid.Parse("A2E32450-F315-4541-9AD6-2F9CBF5AD1E9")
            },
            new 
            {
                CaravanId = Guid.Parse("323E9591-2F2D-4005-8FEA-BA56BF7977B1"),
                NumberPlate = "RZH3MD7",
                ModelId = Guid.Parse("5CC10DEC-3F4D-451B-82FE-28A59384D3ED")
            },
            new 
            {
                CaravanId = Guid.Parse("99F05BFD-194C-43B1-8458-FE7D63C32F40"),
                NumberPlate = "RZ4BR5G",
                ModelId = Guid.Parse("21146366-09AD-420B-B6FB-6DC3B4D22EC2")
            }
        );
    }
}
