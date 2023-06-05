﻿// <auto-generated />
using System;
using Caravans.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Caravans.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Caravans.Models.Caravan", b =>
                {
                    b.Property<Guid>("CaravanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("caravanID");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("modelID");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("numberPlate");

                    b.HasKey("CaravanId")
                        .HasName("PK_caravans_caravanID");

                    b.HasIndex("ModelId");

                    b.ToTable("caravans", (string)null);

                    b.HasData(
                        new
                        {
                            CaravanId = new Guid("eb6e972e-fa5b-4627-bcc7-b676a60bd076"),
                            ModelId = new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"),
                            NumberPlate = "RZ8429D"
                        },
                        new
                        {
                            CaravanId = new Guid("ebdbc5ca-2fd4-4e4e-9213-a8ac3ebb42d8"),
                            ModelId = new Guid("5cc10dec-3f4d-451b-82fe-28a59384d3ed"),
                            NumberPlate = "RZ3BC54"
                        },
                        new
                        {
                            CaravanId = new Guid("ed844936-bab0-412e-83ac-c12f62e4a271"),
                            ModelId = new Guid("a9ff9dd4-73f4-4c4d-9479-5dc186b012de"),
                            NumberPlate = "RZAF542"
                        },
                        new
                        {
                            CaravanId = new Guid("0ab40796-ebc0-4279-83de-30e5f3ed1049"),
                            ModelId = new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"),
                            NumberPlate = "RZJF35H"
                        },
                        new
                        {
                            CaravanId = new Guid("3279b0a5-d782-4c45-a27a-534daf9f2ed8"),
                            ModelId = new Guid("21146366-09ad-420b-b6fb-6dc3b4d22ec2"),
                            NumberPlate = "RZD2F5S"
                        },
                        new
                        {
                            CaravanId = new Guid("78004928-164c-4679-a416-a9508825abd9"),
                            ModelId = new Guid("299da786-b3bb-488c-b628-1698a1b40210"),
                            NumberPlate = "RZF2G15"
                        },
                        new
                        {
                            CaravanId = new Guid("114c99b9-89a2-44d9-a6f6-eef2598dce2e"),
                            ModelId = new Guid("bf211dfd-c764-4b8b-afc8-97c252c56337"),
                            NumberPlate = "RZ5F2D3"
                        },
                        new
                        {
                            CaravanId = new Guid("cc8323ce-88a6-4bca-bf85-f5442f6202bb"),
                            ModelId = new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"),
                            NumberPlate = "RZG3S6F"
                        },
                        new
                        {
                            CaravanId = new Guid("8b1ee81b-a5cb-4b08-9db4-69d8914c26e3"),
                            ModelId = new Guid("a9ff9dd4-73f4-4c4d-9479-5dc186b012de"),
                            NumberPlate = "RZ47336"
                        },
                        new
                        {
                            CaravanId = new Guid("03a77cef-431a-4cd9-921e-5b4d5c473830"),
                            ModelId = new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"),
                            NumberPlate = "RZH4ND6"
                        },
                        new
                        {
                            CaravanId = new Guid("323e9591-2f2d-4005-8fea-ba56bf7977b1"),
                            ModelId = new Guid("5cc10dec-3f4d-451b-82fe-28a59384d3ed"),
                            NumberPlate = "RZH3MD7"
                        },
                        new
                        {
                            CaravanId = new Guid("99f05bfd-194c-43b1-8458-fe7d63c32f40"),
                            ModelId = new Guid("21146366-09ad-420b-b6fb-6dc3b4d22ec2"),
                            NumberPlate = "RZ4BR5G"
                        });
                });

            modelBuilder.Entity("Caravans.Models.Caravanmodel", b =>
                {
                    b.Property<Guid>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("modelID");

                    b.Property<bool>("Fridge")
                        .HasColumnType("bit")
                        .HasColumnName("fridge");

                    b.Property<bool>("HotWater")
                        .HasColumnType("bit")
                        .HasColumnName("hotWater");

                    b.Property<int>("Length")
                        .HasColumnType("int")
                        .HasColumnName("length");

                    b.Property<int>("LengthInside")
                        .HasColumnType("int")
                        .HasColumnName("lengthInside");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("model");

                    b.Property<int>("People")
                        .HasColumnType("int")
                        .HasColumnName("people");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("picture");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("producer");

                    b.Property<bool>("Shower")
                        .HasColumnType("bit")
                        .HasColumnName("shower");

                    b.Property<int>("Water")
                        .HasColumnType("int")
                        .HasColumnName("water");

                    b.Property<int>("Weight")
                        .HasColumnType("int")
                        .HasColumnName("weight");

                    b.Property<int>("Width")
                        .HasColumnType("int")
                        .HasColumnName("width");

                    b.Property<int>("WidthInside")
                        .HasColumnType("int")
                        .HasColumnName("widthInside");

                    b.HasKey("ModelId")
                        .HasName("PK_caravanmodels_modelID");

                    b.ToTable("caravanmodels", (string)null);

                    b.HasData(
                        new
                        {
                            ModelId = new Guid("a9ff9dd4-73f4-4c4d-9479-5dc186b012de"),
                            Fridge = true,
                            HotWater = true,
                            Length = 2633,
                            LengthInside = 1950,
                            Model = "DeLuxe 400 SFE",
                            People = 3,
                            Picture = "Hobby-DeLuxe-400-SFE.jpg",
                            Price = 120.00m,
                            Producer = "Hobby",
                            Shower = false,
                            Water = 25,
                            Weight = 1300,
                            Width = 2300,
                            WidthInside = 2172
                        },
                        new
                        {
                            ModelId = new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"),
                            Fridge = true,
                            HotWater = true,
                            Length = 6888,
                            LengthInside = 5696,
                            Model = "DeLuxe 490 KMF",
                            People = 5,
                            Picture = "Hobby-DeLuxe-490-KMF.jpg",
                            Price = 200.00m,
                            Producer = "Hobby",
                            Shower = true,
                            Water = 25,
                            Weight = 1252,
                            Width = 2300,
                            WidthInside = 2172
                        },
                        new
                        {
                            ModelId = new Guid("5cc10dec-3f4d-451b-82fe-28a59384d3ed"),
                            Fridge = true,
                            HotWater = true,
                            Length = 7154,
                            LengthInside = 6840,
                            Model = "Prestige 650 UMFe",
                            People = 5,
                            Picture = "Hobby-Prestige-650-UMFe.jpg",
                            Price = 250.00m,
                            Producer = "Hobby",
                            Shower = true,
                            Water = 50,
                            Weight = 1662,
                            Width = 2500,
                            WidthInside = 2367
                        },
                        new
                        {
                            ModelId = new Guid("299da786-b3bb-488c-b628-1698a1b40210"),
                            Fridge = true,
                            HotWater = true,
                            Length = 7850,
                            LengthInside = 5680,
                            Model = "Sudwind 580 QS Silver",
                            People = 5,
                            Picture = "KNAUS-Sudwind-580-QS-Silver.jpg",
                            Price = 240.00m,
                            Producer = "KNAUS",
                            Shower = true,
                            Water = 25,
                            Weight = 1260,
                            Width = 2500,
                            WidthInside = 2340
                        },
                        new
                        {
                            ModelId = new Guid("21146366-09ad-420b-b6fb-6dc3b4d22ec2"),
                            Fridge = true,
                            HotWater = true,
                            Length = 4930,
                            LengthInside = 4200,
                            Model = "PREMIO LIFE 420 TS",
                            People = 3,
                            Picture = "premio-life-420-ts.jpg",
                            Price = 100.00m,
                            Producer = "BUERSNTER ",
                            Shower = false,
                            Water = 12,
                            Weight = 1100,
                            Width = 2120,
                            WidthInside = 2050
                        },
                        new
                        {
                            ModelId = new Guid("bf211dfd-c764-4b8b-afc8-97c252c56337"),
                            Fridge = true,
                            HotWater = true,
                            Length = 5870,
                            LengthInside = 5250,
                            Model = "PREMIO 495 TK",
                            People = 5,
                            Picture = "PREMIO-495-TK.jpg",
                            Price = 250.00m,
                            Producer = "BUERSNTER",
                            Shower = true,
                            Water = 44,
                            Weight = 1160,
                            Width = 2320,
                            WidthInside = 2150
                        });
                });

            modelBuilder.Entity("Caravans.Models.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("reservationID");

                    b.Property<Guid>("CaravanId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("caravanID");

                    b.Property<DateTime>("ReservationBegin")
                        .HasColumnType("date")
                        .HasColumnName("reservationBegin");

                    b.Property<bool>("ReservationConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReservationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("reservationDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("ReservationEnd")
                        .HasColumnType("date")
                        .HasColumnName("reservationEnd");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userID");

                    b.HasKey("ReservationId")
                        .HasName("PK_reservations_reservationID");

                    b.HasIndex("CaravanId");

                    b.HasIndex("UserId");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("Caravans.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("password");

                    b.HasKey("UserId")
                        .HasName("PK_users_userID");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("dcd6f633-d9a3-48d7-9a2d-08db5da24aa6"),
                            Email = "test@test.pl",
                            FirstName = "Damian",
                            LastName = "Oliwa",
                            Password = "$2a$11$12GeW/LeEDmL0BERCSsv/efXn5I8HGQ2gVdX9GUDnHWM6eCErsU2a"
                        });
                });

            modelBuilder.Entity("Caravans.Models.Caravan", b =>
                {
                    b.HasOne("Caravans.Models.Caravanmodel", "Model")
                        .WithMany("Caravans")
                        .HasForeignKey("ModelId")
                        .IsRequired()
                        .HasConstraintName("FK_caravans_caravanmodels");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Caravans.Models.Reservation", b =>
                {
                    b.HasOne("Caravans.Models.Caravan", "Caravan")
                        .WithMany("Reservations")
                        .HasForeignKey("CaravanId")
                        .IsRequired()
                        .HasConstraintName("FK_reservations_caravans");

                    b.HasOne("Caravans.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_reservations_users");

                    b.Navigation("Caravan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Caravans.Models.Caravan", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Caravans.Models.Caravanmodel", b =>
                {
                    b.Navigation("Caravans");
                });

            modelBuilder.Entity("Caravans.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
