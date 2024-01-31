using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LoveAtFirstSight.Models;
using Microsoft.AspNetCore.Identity;


namespace LoveAtFirstSight.Data;


public class LoveAtFirstSightDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Adopted> Adoptions { get; set; }
    public DbSet<AnimalBreed> AnimalBreeds { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public LoveAtFirstSightDbContext(DbContextOptions<LoveAtFirstSightDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        },
        new IdentityRole
        {
            Id = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f",
            Name = "User",
            NormalizedName = "user"
        }
        );

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },
        new IdentityUser
        {
            Id = "5678efgh-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "RachelD",
            Email = "rachelmdominie@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
        },
        new IdentityUser
        {
            Id = "9012ijkl-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "ElizabethS",
            Email = "elizabethspencer@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
        },
        new IdentityUser
        {
            Id = "2013iqkp-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "MattS",
            Email = "mattspencer@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
        }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        },
        new IdentityUserRole<string>
        {
            RoleId = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f",
            UserId = "5678efgh-0829-4ac5-a3ed-180f5e916a5f"
        },
        new IdentityUserRole<string>
        {
            RoleId = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f",
            UserId = "9012ijkl-0829-4ac5-a3ed-180f5e916a5f"
        },
        new IdentityUserRole<string>
        {
            RoleId = "abcdefgh-0829-4ac5-a3ed-180f5e916a5f",
            UserId = "2013iqkp-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            FullName = "Admina Strator",
            Email = "admina@strator.comx",
            Address = "101 Main Street",
            UserName = "Administrator",
            Employee = true,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"

        },
        new UserProfile
        {
            Id = 2,
            FullName = "Rachel Dominie",
            Email = "rachelmdominie@example.com",
            Address = "5165 Crosswood dr.",
            UserName = "RachelD",
            Employee = false,
            IdentityUserId = "5678efgh-0829-4ac5-a3ed-180f5e916a5f"
        },
        new UserProfile
        {
            Id = 3,
            FullName = "Elizabeth Spencer",
            Email = "elizabethspencer@example.com",
            Address = "456 Main Street",
            UserName = "ElizabethS",
            Employee = false,
            IdentityUserId = "9012ijkl-0829-4ac5-a3ed-180f5e916a5f"
        },
        new UserProfile
        {
            Id = 4,
            FullName = "Matt Spencer",
            Email = "mattspencer@example.com",
            Address = "456 Main Street",
            UserName = "MattS",
            Employee = false,
            IdentityUserId = "2013iqkp-0829-4ac5-a3ed-180f5e916a5f"

        }
        );

        modelBuilder.Entity<Animal>().HasData(new Animal
        {
            Id = 1,
            IsDog = true,
            IsMale = false,
            Name = "Ruby",
            Age = 1,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 11, 12),
            UrlPic = "https://i.pinimg.com/736x/5f/9c/ff/5f9cff29b653ac04d6d5fb3d317ca268.jpg"
        },
        new Animal
        {
            Id = 2,
            IsDog = true,
            IsMale = true,
            Name = "Baron",
            Age = 1,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 11, 12),
            UrlPic = "https://i.pinimg.com/736x/2c/52/e9/2c52e9e6ecb5d8fd9d3b6426c6a22684.jpg"
        },
        new Animal
        {
            Id = 3,
            IsDog = true,
            IsMale = true,
            Name = "Lynyrd",
            Age = 2,
            Available = false,
            Fostered = false,
            DateAdded = new DateTime(2023, 8, 4),
            UrlPic = "https://i.pinimg.com/736x/ce/b9/78/ceb9786a73f06208c1fbb76d91e94cc1.jpg"
        },
        new Animal
        {
            Id = 4,
            IsDog = false,
            IsMale = false,
            Name = "Storm",
            Age = 1,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 12, 19),
            UrlPic = "https://i.pinimg.com/736x/aa/ff/48/aaff4805200a41a4caa46a222b16d51c.jpg"
        },
        new Animal
        {
            Id = 5,
            IsDog = false,
            IsMale = false,
            Name = "Elena",
            Age = 2,
            Available = false,
            Fostered = false,
            DateAdded = new DateTime(2023, 7, 1),
            UrlPic = "https://i.pinimg.com/736x/39/55/fb/3955fb5e4a3168fae68c51696ee94f1e.jpg"
        },
        new Animal
        {
            Id = 6,
            IsDog = false,
            IsMale = false,
            Name = "Cloud",
            Age = 1,
            Available = false,
            Fostered = true,
            DateAdded = new DateTime(2023, 7, 1),
            UrlPic = "https://i.pinimg.com/736x/28/8b/fa/288bfa66c76c39834fc3c6f53b5ccb02.jpg"
        },
        new Animal
        {
            Id = 7,
            IsDog = false,
            IsMale = true,
            Name = "Macaroni",
            Age = 4,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2024, 1, 14),
            UrlPic = "https://i.pinimg.com/736x/5f/94/1e/5f941eef60452df3f0ac34aec60fcb40.jpg"
        },
        new Animal
        {
            Id = 8,
            IsDog = true,
            IsMale = true,
            Name = "Cupid",
            Age = 2,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 11, 11),
            UrlPic = "https://i.pinimg.com/736x/9f/82/9e/9f829e14c2d024d182500ba2944787cc.jpg"
        },
        new Animal
        {
            Id = 9,
            IsDog = true,
            IsMale = true,
            Name = "Buddy",
            Age = 3,
            Available = false,
            Fostered = false,
            DateAdded = new DateTime(2024, 7, 1),
            UrlPic = "https://i.pinimg.com/736x/7b/4e/b8/7b4eb8590d0cd613c4dfa9d56430d19d.jpg"
        },
        new Animal
        {
            Id = 10,
            IsDog = false,
            IsMale = false,
            Name = "Leopard",
            Age = 2,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2024, 1, 7),
            UrlPic = "https://i.pinimg.com/736x/55/a0/95/55a095b943469a92a210911a6ac33f50.jpg"
        },
        new Animal
        {
            Id = 11,
            IsDog = false,
            IsMale = false,
            Name = "Cupcake",
            Age = 1,
            Available = false,
            Fostered = false,
            DateAdded = new DateTime(2023, 7, 1),
            UrlPic = "https://i.pinimg.com/736x/a8/5a/ac/a85aac5eb0339960d60b5f7d05a39c70.jpg"
        },
        new Animal
        {
            Id = 12,
            IsDog = false,
            IsMale = true,
            Name = "Finn",
            Age = 5,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2024, 1, 14),
            UrlPic = "https://i.pinimg.com/736x/53/b7/b2/53b7b2db9a65660a2fab522b25fedf30.jpg"
        },
        new Animal
        {
            Id = 13,
            IsDog = true,
            IsMale = false,
            Name = "Pearl",
            Age = 3,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 11, 2),
            UrlPic = "https://i.pinimg.com/736x/3d/b2/f4/3db2f49640bd254b5cff5c51b0d0dc8d.jpg"
        },
        new Animal
        {
            Id = 14,
            IsDog = true,
            IsMale = true,
            Name = "Snowball",
            Age = 4,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 12, 8),
            UrlPic = "https://i.pinimg.com/736x/d9/a7/38/d9a73802a827bfc7c30e157818e219fc.jpg"
        },
        new Animal
        {
            Id = 15,
            IsDog = true,
            IsMale = true,
            Name = "Jiro",
            Age = 8,
            Available = false,
            Fostered = true,
            DateAdded = new DateTime(2023, 8, 8),
            UrlPic = "https://i.pinimg.com/736x/b8/d8/69/b8d869e8b81e6f6467c06d6fe01d2e5d.jpg"
        },
        new Animal
        {
            Id = 16,
            IsDog = true,
            IsMale = true,
            Name = "Snowball",
            Age = 4,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 12, 8),
            UrlPic = "https://i.pinimg.com/736x/d9/a7/38/d9a73802a827bfc7c30e157818e219fc.jpg"
        },
        new Animal
        {
            Id = 17,
            IsDog = true,
            IsMale = true,
            Name = "Jack",
            Age = 2,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 9, 2),
            UrlPic = "https://i.pinimg.com/736x/d1/4f/61/d14f617b6f985844084f4ba56beaaaaa.jpg"
        },
        new Animal
        {
            Id = 18,
            IsDog = true,
            IsMale = true,
            Name = "Oreo",
            Age = 3,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 9, 8),
            UrlPic = "https://i.pinimg.com/736x/43/cf/bc/43cfbcfa2af3159d9ef1bd1f7c125ee5.jpg"
        },
        new Animal
        {
            Id = 19,
            IsDog = false,
            IsMale = false,
            Name = "Ladybug",
            Age = 2,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2024, 1, 4),
            UrlPic = "https://i.pinimg.com/736x/11/56/5f/11565fefe92d0b3201708f4800bcf447.jpg"
        },
        new Animal
        {
            Id = 20,
            IsDog = true,
            IsMale = true,
            Name = "Ross",
            Age = 4,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 9, 8),
            UrlPic = "https://i.pinimg.com/736x/44/c7/1a/44c71acc470ed8a620ffe38333da967f.jpg"
        },
        new Animal
        {
            Id = 21,
            IsDog = false,
            IsMale = true,
            Name = "David",
            Age = 2,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 11, 14),
            UrlPic = "https://i.pinimg.com/736x/45/03/3e/45033e9bd60171960fb433c234e8d080.jpg"
        },
        new Animal
        {
            Id = 22,
            IsDog = false,
            IsMale = true,
            Name = "Pumpkin",
            Age = 4,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 4, 4),
            UrlPic = "https://i.pinimg.com/736x/e7/6e/57/e76e572bdf56f3701bc727f522a9a3a0.jpg"
        },
        new Animal
        {
            Id = 23,
            IsDog = true,
            IsMale = false,
            Name = "Rapunzel",
            Age = 2,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2024, 1, 21),
            UrlPic = "https://i.pinimg.com/736x/31/d5/57/31d557a89c7ca9be7bca40a9723f4414.jpg"
        },
        new Animal
        {
            Id = 24,
            IsDog = false,
            IsMale = false,
            Name = "Silver",
            Age = 2,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 12, 8),
            UrlPic = "https://i.pinimg.com/736x/1a/1b/64/1a1b64fcf14ec02ed90238e18605cb72.jpg"
        },
        new Animal
        {
            Id = 25,
            IsDog = false,
            IsMale = false,
            Name = "Jade",
            Age = 2,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2024, 1, 26),
            UrlPic = "https://i.pinimg.com/736x/de/dc/03/dedc03adc361892786996d4a77c9a30e.jpg"
        },
        new Animal
        {
            Id = 26,
            IsDog = true,
            IsMale = false,
            Name = "Cider",
            Age = 4,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 12, 8),
            UrlPic = "https://i.pinimg.com/736x/40/4f/7e/404f7ef751fbaec6e37281fc7034a7a2.jpg"
        },
        new Animal
        {
            Id = 27,
            IsDog = true,
            IsMale = false,
            Name = "Muppet",
            Age = 2,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2024, 1, 29),
            UrlPic = "https://i.pinimg.com/736x/b5/c2/35/b5c235e7095d6e872bb41c569d23939a.jpg"
        },
        new Animal
        {
            Id = 28,
            IsDog = false,
            IsMale = false,
            Name = "Asteroid",
            Age = 2,
            Available = true,
            Fostered = false,
            DateAdded = new DateTime(2023, 11, 14),
            UrlPic = "https://i.pinimg.com/736x/98/e8/67/98e867f4170dd56072a03600600f1788.jpg"
        },
        new Animal
        {
            Id = 29,
            IsDog = false,
            IsMale = false,
            Name = "Raven",
            Age = 2,
            Available = false,
            Fostered = false,
            DateAdded = new DateTime(2023, 10, 1),
            UrlPic = "https://i.pinimg.com/736x/bf/e7/f2/bfe7f281036371a171331b280f967fb6.jpg"
        },
        new Animal
        {
            Id = 30,
            IsDog = true,
            IsMale = false,
            Name = "Lou",
            Age = 3,
            Available = true,
            Fostered = true,
            DateAdded = new DateTime(2023, 10, 24),
            UrlPic = "https://i.pinimg.com/736x/f4/66/5d/f4665db0b5b001a6b2064eeca673e52d.jpg"
        });

        modelBuilder.Entity<Breed>().HasData(
        new Breed
        {
            Id = 1,
            Name = "English BullDog",
            IsDog = true
        },
        new Breed
        {
            Id = 2,
            Name = "Labrador Retriever",
            IsDog = true
        },
        new Breed
        {
            Id = 3,
            Name = "Golden Retriever",
            IsDog = true
        },
        new Breed
        {
            Id = 4,
            Name = "Bulldog",
            IsDog = true
        },
        new Breed
        {
            Id = 5,
            Name = "Beagle",
            IsDog = true
        },
        new Breed
        {
            Id = 6,
            Name = "Rottweiler",
            IsDog = true
        },
        new Breed
        {
            Id = 7,
            Name = "Shih Tzu",
            IsDog = true
        },
        new Breed
        {
            Id = 8,
            Name = "Yorkshire Terrier",
            IsDog = true
        },
        new Breed
        {
            Id = 9,
            Name = "Boxer",
            IsDog = true
        },
        new Breed
        {
            Id = 10,
            Name = "Border Collie",
            IsDog = true
        },
        new Breed
        {
            Id = 11,
            Name = "Siberian Husky",
            IsDog = true
        },
        new Breed
        {
            Id = 12,
            Name = "Persian Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 13,
            Name = "Siamese Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 14,
            Name = "Maine Coon",
            IsDog = false
        },
        new Breed
        {
            Id = 15,
            Name = "Abyssinian Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 16,
            Name = "Bengal Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 17,
            Name = "Bombay Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 18,
            Name = "Cornish Rex Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 19,
            Name = "Egyptian Mau Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 20,
            Name = "Exotic Shorthair Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 21,
            Name = "Havana Brown Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 22,
            Name = "Scottish Fold Cat",
            IsDog = false
        },
        new Breed
        {
            Id = 23,
            Name = "Sphynx Cat",
            IsDog = false
        });


        modelBuilder.Entity<AnimalBreed>().HasData(new AnimalBreed
        {
            Id = 1,
            AnimalId = 1,
            BreedId = 5
        },
        new AnimalBreed
        {
            Id = 2,
            AnimalId = 1,
            BreedId = 9
        },
        new AnimalBreed
        {
            Id = 3,
            AnimalId = 2,
            BreedId = 3
        },
        new AnimalBreed
        {
            Id = 4,
            AnimalId = 2,
            BreedId = 4
        },
        new AnimalBreed
        {
            Id = 5,
            AnimalId = 3,
            BreedId = 5
        },
        new AnimalBreed
        {
            Id = 6,
            AnimalId = 3,
            BreedId = 6
        },
        new AnimalBreed
        {
            Id = 7,
            AnimalId = 4,
            BreedId = 12
        },
        new AnimalBreed
        {
            Id = 8,
            AnimalId = 4,
            BreedId = 13
        },
        new AnimalBreed
        {
            Id = 9,
            AnimalId = 5,
            BreedId = 14
        },
        new AnimalBreed
        {
            Id = 10,
            AnimalId = 5,
            BreedId = 15
        },
        new AnimalBreed
        {
            Id = 11,
            AnimalId = 6,
            BreedId = 12
        });

        modelBuilder.Entity<Adopted>().HasData(new Adopted
        {
            Id = 1,
            Foster = false,
            AnimalId = 3,
            UserProfileId = 2,
            TimeOfAdoption = new DateTime(2023, 12, 18)
        },
        new Adopted
        {
            Id = 2,
            Foster = true,
            AnimalId = 2,
            UserProfileId = 2,
        },
        new Adopted
        {
            Id = 3,
            Foster = false,
            AnimalId = 5,
            UserProfileId = 3,
            TimeOfAdoption = new DateTime(2023, 8, 3)
        },
        new Adopted
        {
            Id = 4,
            Foster = true,
            AnimalId = 6,
            UserProfileId = 2
        },
        new Adopted
        {
            Id = 5,
            Foster = true,
            AnimalId = 8,
            UserProfileId = 3
        },
        new Adopted
        {
            Id = 6,
            Foster = true,
            AnimalId = 13,
            UserProfileId = 3
        },
        new Adopted
        {
            Id = 7,
            Foster = true,
            AnimalId = 16,
            UserProfileId = 2
        },
        new Adopted
        {
            Id = 8,
            Foster = true,
            AnimalId = 17,
            UserProfileId = 4
        },
        new Adopted
        {
            Id = 9,
            Foster = true,
            AnimalId = 20,
            UserProfileId = 4
        },
        new Adopted
        {
            Id = 10,
            Foster = true,
            AnimalId = 23,
            UserProfileId = 4
        },
        new Adopted
        {
            Id = 11,
            Foster = true,
            AnimalId = 30,
            UserProfileId = 4
        },
        new Adopted
        {
            Id = 12,
            Foster = false,
            AnimalId = 9,
            UserProfileId = 4,
            TimeOfAdoption = new DateTime(2024, 8, 3)
        },
        new Adopted
        {
            Id = 13,
            Foster = false,
            AnimalId = 11,
            UserProfileId = 4,
            TimeOfAdoption = new DateTime(2023, 8, 4)
        },
        new Adopted
        {
            Id = 14,
            Foster = false,
            AnimalId = 15,
            UserProfileId = 3,
            TimeOfAdoption = new DateTime(2023, 11, 4)
        },
        new Adopted
        {
            Id = 15,
            Foster = false,
            AnimalId = 29,
            UserProfileId = 4,
            TimeOfAdoption = new DateTime(2024, 1, 2)
        });
    }
}








// dotnet ef migrations add InitialCreate
// dotnet ef database update