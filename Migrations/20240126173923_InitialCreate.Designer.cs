﻿// <auto-generated />
using System;
using LoveAtFirstSight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoveAtFirstSight.Migrations
{
    [DbContext(typeof(LoveAtFirstSightDbContext))]
    [Migration("20240126173923_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LoveAtFirstSight.Models.Adopted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<bool>("Foster")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeOfAdoption")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Adoptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalId = 3,
                            Foster = false,
                            TimeOfAdoption = new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 2,
                            AnimalId = 2,
                            Foster = true,
                            TimeOfAdoption = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 3,
                            AnimalId = 5,
                            Foster = false,
                            TimeOfAdoption = new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 4,
                            AnimalId = 6,
                            Foster = true,
                            TimeOfAdoption = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 2
                        });
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Fostered")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDog")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMale")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UrlPic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 1,
                            Available = true,
                            DateAdded = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fostered = false,
                            IsDog = true,
                            IsMale = false,
                            Name = "Ruby",
                            UrlPic = "https://i.pinimg.com/736x/5f/9c/ff/5f9cff29b653ac04d6d5fb3d317ca268.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Age = 1,
                            Available = true,
                            DateAdded = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fostered = true,
                            IsDog = true,
                            IsMale = true,
                            Name = "Baron",
                            UrlPic = "https://i.pinimg.com/736x/2c/52/e9/2c52e9e6ecb5d8fd9d3b6426c6a22684.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Age = 2,
                            Available = false,
                            DateAdded = new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fostered = false,
                            IsDog = true,
                            IsMale = true,
                            Name = "Lynyrd",
                            UrlPic = "https://i.pinimg.com/736x/ce/b9/78/ceb9786a73f06208c1fbb76d91e94cc1.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Age = 1,
                            Available = true,
                            DateAdded = new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fostered = false,
                            IsDog = false,
                            IsMale = false,
                            Name = "Storm",
                            UrlPic = "https://i.pinimg.com/736x/aa/ff/48/aaff4805200a41a4caa46a222b16d51c.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Age = 2,
                            Available = false,
                            DateAdded = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fostered = false,
                            IsDog = false,
                            IsMale = false,
                            Name = "Elena",
                            UrlPic = "https://i.pinimg.com/736x/39/55/fb/3955fb5e4a3168fae68c51696ee94f1e.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Age = 1,
                            Available = false,
                            DateAdded = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fostered = true,
                            IsDog = false,
                            IsMale = false,
                            Name = "Cloud",
                            UrlPic = "https://i.pinimg.com/736x/28/8b/fa/288bfa66c76c39834fc3c6f53b5ccb02.jpg"
                        });
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.AnimalBreed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<int>("BreedId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("BreedId");

                    b.ToTable("AnimalBreeds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalId = 1,
                            BreedId = 5
                        },
                        new
                        {
                            Id = 2,
                            AnimalId = 1,
                            BreedId = 9
                        },
                        new
                        {
                            Id = 3,
                            AnimalId = 2,
                            BreedId = 3
                        },
                        new
                        {
                            Id = 4,
                            AnimalId = 2,
                            BreedId = 4
                        },
                        new
                        {
                            Id = 5,
                            AnimalId = 3,
                            BreedId = 5
                        },
                        new
                        {
                            Id = 6,
                            AnimalId = 3,
                            BreedId = 6
                        },
                        new
                        {
                            Id = 7,
                            AnimalId = 4,
                            BreedId = 12
                        },
                        new
                        {
                            Id = 8,
                            AnimalId = 4,
                            BreedId = 13
                        },
                        new
                        {
                            Id = 9,
                            AnimalId = 5,
                            BreedId = 14
                        },
                        new
                        {
                            Id = 10,
                            AnimalId = 5,
                            BreedId = 15
                        },
                        new
                        {
                            Id = 11,
                            AnimalId = 6,
                            BreedId = 12
                        });
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDog")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Breeds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDog = true,
                            Name = "English BullDog"
                        },
                        new
                        {
                            Id = 2,
                            IsDog = true,
                            Name = "Labrador Retriever"
                        },
                        new
                        {
                            Id = 3,
                            IsDog = true,
                            Name = "Golden Retriever"
                        },
                        new
                        {
                            Id = 4,
                            IsDog = true,
                            Name = "Bulldog"
                        },
                        new
                        {
                            Id = 5,
                            IsDog = true,
                            Name = "Beagle"
                        },
                        new
                        {
                            Id = 6,
                            IsDog = true,
                            Name = "Rottweiler"
                        },
                        new
                        {
                            Id = 7,
                            IsDog = true,
                            Name = "Shih Tzu"
                        },
                        new
                        {
                            Id = 8,
                            IsDog = true,
                            Name = "Yorkshire Terrier"
                        },
                        new
                        {
                            Id = 9,
                            IsDog = true,
                            Name = "Boxer"
                        },
                        new
                        {
                            Id = 10,
                            IsDog = true,
                            Name = "Border Collie"
                        },
                        new
                        {
                            Id = 11,
                            IsDog = true,
                            Name = "Siberian Husky"
                        },
                        new
                        {
                            Id = 12,
                            IsDog = false,
                            Name = "Persian Cat"
                        },
                        new
                        {
                            Id = 13,
                            IsDog = false,
                            Name = "Siamese Cat"
                        },
                        new
                        {
                            Id = 14,
                            IsDog = false,
                            Name = "Maine Coon"
                        },
                        new
                        {
                            Id = 15,
                            IsDog = false,
                            Name = "Abyssinian Cat"
                        },
                        new
                        {
                            Id = 16,
                            IsDog = false,
                            Name = "Bengal Cat"
                        },
                        new
                        {
                            Id = 17,
                            IsDog = false,
                            Name = "Bombay Cat"
                        },
                        new
                        {
                            Id = 18,
                            IsDog = false,
                            Name = "Cornish Rex Cat"
                        },
                        new
                        {
                            Id = 19,
                            IsDog = false,
                            Name = "Egyptian Mau Cat"
                        },
                        new
                        {
                            Id = 20,
                            IsDog = false,
                            Name = "Exotic Shorthair Cat"
                        },
                        new
                        {
                            Id = 21,
                            IsDog = false,
                            Name = "Havana Brown Cat"
                        },
                        new
                        {
                            Id = 22,
                            IsDog = false,
                            Name = "Scottish Fold Cat"
                        },
                        new
                        {
                            Id = 23,
                            IsDog = false,
                            Name = "Sphynx Cat"
                        });
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Employee")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            Email = "admina@strator.comx",
                            Employee = true,
                            FullName = "Admina Strator",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Address = "5165 Crosswood dr.",
                            Email = "rachelmdominie@example.com",
                            Employee = false,
                            FullName = "Rachel Dominie",
                            IdentityUserId = "5678efgh-0829-4ac5-a3ed-180f5e916a5f",
                            UserName = "RachelD"
                        },
                        new
                        {
                            Id = 3,
                            Address = "456 Main Street",
                            Email = "elizabethspencer@example.com",
                            Employee = false,
                            FullName = "Elizabeth Spencer",
                            IdentityUserId = "9012ijkl-0829-4ac5-a3ed-180f5e916a5f",
                            UserName = "ElizabethS"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            Name = "Admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f",
                            Name = "User",
                            NormalizedName = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "11311240-ade6-4a71-97fe-320b89386a80",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEARC5NZ91iFYA4mIwPPsRs0IBXwGje9grvOO4QCMTj+6rNsQfZz8f3ExDGkGTo/XMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5da53b0d-7fe8-4dc2-bafc-c663ce5f4b7c",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "5678efgh-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dde4a239-a283-4faa-b662-c383c33194d3",
                            Email = "rachelmdominie@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEK+rhDaM6YbPkgQB6t1OwEd7rSUgreS7PiopqzBgbnJNA4Zmp5jxdYffLec2f6Bbaw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "62a0623f-4404-44b9-8b2a-60330806e138",
                            TwoFactorEnabled = false,
                            UserName = "RachelD"
                        },
                        new
                        {
                            Id = "9012ijkl-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8ec02fbf-e24a-43f7-a894-abb3d07a0fad",
                            Email = "elizabethspencer@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEFX1IxbwVY6AGT8BRoV9d6l6cUKaARSLvnQ6Y+92ZhKSDQLtZBg0WATxJFxyb32/hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "027dcc5b-3a38-4fca-bc6b-283dea1d554f",
                            TwoFactorEnabled = false,
                            UserName = "ElizabethS"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        },
                        new
                        {
                            UserId = "5678efgh-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f"
                        },
                        new
                        {
                            UserId = "9012ijkl-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.Adopted", b =>
                {
                    b.HasOne("LoveAtFirstSight.Models.Animal", "Animal")
                        .WithMany("Adoptions")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoveAtFirstSight.Models.UserProfile", "UserProfile")
                        .WithMany("Adoptions")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.AnimalBreed", b =>
                {
                    b.HasOne("LoveAtFirstSight.Models.Animal", "Animal")
                        .WithMany("AnimalBreeds")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoveAtFirstSight.Models.Breed", "Breed")
                        .WithMany("AnimalBreeds")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.Animal", b =>
                {
                    b.Navigation("Adoptions");

                    b.Navigation("AnimalBreeds");
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.Breed", b =>
                {
                    b.Navigation("AnimalBreeds");
                });

            modelBuilder.Entity("LoveAtFirstSight.Models.UserProfile", b =>
                {
                    b.Navigation("Adoptions");
                });
#pragma warning restore 612, 618
        }
    }
}