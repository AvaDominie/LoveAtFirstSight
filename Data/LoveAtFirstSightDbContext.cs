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
        });

        modelBuilder.Entity<Breed>().HasData(
            new Breed { Id = 1, Name = "English BullDog" },
            new Breed { Id = 2, Name = "Labrador Retriever" },
            new Breed { Id = 3, Name = "Golden Retriever" },
            new Breed { Id = 4, Name = "Bulldog" },
            new Breed { Id = 5, Name = "Beagle" },
            new Breed { Id = 6, Name = "Rottweiler" },
            new Breed { Id = 7, Name = "Shih Tzu" },
            new Breed { Id = 8, Name = "Yorkshire Terrier" },
            new Breed { Id = 9, Name = "Boxer" },
            new Breed { Id = 10, Name = "Border Collie" },
            new Breed { Id = 11, Name = "Siberian Husky" },
            new Breed { Id = 12, Name = "Persian Cat" },
            new Breed { Id = 13, Name = "Siamese Cat" },
            new Breed { Id = 14, Name = "Maine Coon" },
            new Breed { Id = 15, Name = "Abyssinian Cat" },
            new Breed { Id = 16, Name = "Bengal Cat" },
            new Breed { Id = 17, Name = "Bombay Cat" },
            new Breed { Id = 18, Name = "Cornish Rex Cat" },
            new Breed { Id = 19, Name = "Egyptian Mau Cat" },
            new Breed { Id = 20, Name = "Exotic Shorthair Cat" },
            new Breed { Id = 21, Name = "Havana Brown Cat" },
            new Breed { Id = 22, Name = "Scottish Fold Cat" },
            new Breed { Id = 23, Name = "Sphynx Cat" }
        );

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
        }
        );

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
            TimeOfAdoption = new DateTime(2023, 8, 3),
        }
        );
    }
}








// dotnet ef migrations add InitialCreate
// dotnet ef database update