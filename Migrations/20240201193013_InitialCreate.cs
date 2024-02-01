using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoveAtFirstSight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDog = table.Column<bool>(type: "boolean", nullable: false),
                    IsMale = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false),
                    Fostered = table.Column<bool>(type: "boolean", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UrlPic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDog = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Employee = table.Column<bool>(type: "boolean", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    BreedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalBreeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalBreeds_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalBreeds_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Foster = table.Column<bool>(type: "boolean", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    TimeOfAdoption = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptions_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptions_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Available", "DateAdded", "Fostered", "IsDog", "IsMale", "Name", "UrlPic" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Ruby", "https://i.pinimg.com/736x/5f/9c/ff/5f9cff29b653ac04d6d5fb3d317ca268.jpg" },
                    { 2, 1, true, new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, "Baron", "https://i.pinimg.com/736x/2c/52/e9/2c52e9e6ecb5d8fd9d3b6426c6a22684.jpg" },
                    { 3, 2, false, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, true, "Lynyrd", "https://i.pinimg.com/736x/ce/b9/78/ceb9786a73f06208c1fbb76d91e94cc1.jpg" },
                    { 4, 1, true, new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Storm", "https://i.pinimg.com/736x/aa/ff/48/aaff4805200a41a4caa46a222b16d51c.jpg" },
                    { 5, 2, false, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Elena", "https://i.pinimg.com/736x/39/55/fb/3955fb5e4a3168fae68c51696ee94f1e.jpg" },
                    { 6, 1, false, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, "Cloud", "https://i.pinimg.com/736x/28/8b/fa/288bfa66c76c39834fc3c6f53b5ccb02.jpg" },
                    { 7, 4, true, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, "Macaroni", "https://i.pinimg.com/736x/5f/94/1e/5f941eef60452df3f0ac34aec60fcb40.jpg" },
                    { 8, 2, true, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, "Cupid", "https://i.pinimg.com/736x/9f/82/9e/9f829e14c2d024d182500ba2944787cc.jpg" },
                    { 9, 3, false, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, true, "Buddy", "https://i.pinimg.com/736x/7b/4e/b8/7b4eb8590d0cd613c4dfa9d56430d19d.jpg" },
                    { 10, 2, true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, "Leopard", "https://i.pinimg.com/736x/55/a0/95/55a095b943469a92a210911a6ac33f50.jpg" },
                    { 11, 1, false, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Cupcake", "https://i.pinimg.com/736x/a8/5a/ac/a85aac5eb0339960d60b5f7d05a39c70.jpg" },
                    { 12, 5, true, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, "Finn", "https://i.pinimg.com/736x/53/b7/b2/53b7b2db9a65660a2fab522b25fedf30.jpg" },
                    { 13, 3, true, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, "Pearl", "https://i.pinimg.com/736x/3d/b2/f4/3db2f49640bd254b5cff5c51b0d0dc8d.jpg" },
                    { 14, 4, true, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, true, "Snowball", "https://i.pinimg.com/736x/d9/a7/38/d9a73802a827bfc7c30e157818e219fc.jpg" },
                    { 15, 8, false, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, "Jiro", "https://i.pinimg.com/736x/b8/d8/69/b8d869e8b81e6f6467c06d6fe01d2e5d.jpg" },
                    { 16, 4, true, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, true, "Snowball", "https://i.pinimg.com/736x/d9/a7/38/d9a73802a827bfc7c30e157818e219fc.jpg" },
                    { 17, 2, true, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, "Jack", "https://i.pinimg.com/736x/d1/4f/61/d14f617b6f985844084f4ba56beaaaaa.jpg" },
                    { 18, 3, true, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, true, "Oreo", "https://i.pinimg.com/736x/43/cf/bc/43cfbcfa2af3159d9ef1bd1f7c125ee5.jpg" },
                    { 19, 2, true, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, "Ladybug", "https://i.pinimg.com/736x/11/56/5f/11565fefe92d0b3201708f4800bcf447.jpg" },
                    { 20, 4, true, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, "Ross", "https://i.pinimg.com/736x/44/c7/1a/44c71acc470ed8a620ffe38333da967f.jpg" },
                    { 21, 2, true, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, "David", "https://i.pinimg.com/736x/45/03/3e/45033e9bd60171960fb433c234e8d080.jpg" },
                    { 22, 4, true, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true, "Pumpkin", "https://i.pinimg.com/736x/e7/6e/57/e76e572bdf56f3701bc727f522a9a3a0.jpg" },
                    { 23, 2, true, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, "Rapunzel", "https://i.pinimg.com/736x/31/d5/57/31d557a89c7ca9be7bca40a9723f4414.jpg" },
                    { 24, 2, true, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Silver", "https://i.pinimg.com/736x/1a/1b/64/1a1b64fcf14ec02ed90238e18605cb72.jpg" },
                    { 25, 2, true, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Jade", "https://i.pinimg.com/736x/de/dc/03/dedc03adc361892786996d4a77c9a30e.jpg" },
                    { 26, 4, true, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Cider", "https://i.pinimg.com/736x/40/4f/7e/404f7ef751fbaec6e37281fc7034a7a2.jpg" },
                    { 27, 2, true, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Muppet", "https://i.pinimg.com/736x/b5/c2/35/b5c235e7095d6e872bb41c569d23939a.jpg" },
                    { 28, 2, true, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Asteroid", "https://i.pinimg.com/736x/98/e8/67/98e867f4170dd56072a03600600f1788.jpg" },
                    { 29, 2, false, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Raven", "https://i.pinimg.com/736x/bf/e7/f2/bfe7f281036371a171331b280f967fb6.jpg" },
                    { 30, 3, true, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, "Lou", "https://i.pinimg.com/736x/f4/66/5d/f4665db0b5b001a6b2064eeca673e52d.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abcdefgh-0829-4ac5-a3ed-180f5e916a5f", null, "User", "user" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Employee", "employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2013iqkp-0829-4ac5-a3ed-180f5e916a5f", 0, "78b357b1-6aa1-4fb9-aa35-26fd79547ae0", "mattspencer@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEL0fdwPRKRq/T9OG+w0JUPkRJQuKlX43km8sgFrJd2Fv0J+oUSaqN2UULEp5Oo9+Hw==", null, false, "a55b7ef9-c657-47c2-bf4c-b89a2ea32ff6", false, "MattS" },
                    { "5678efgh-0829-4ac5-a3ed-180f5e916a5f", 0, "4b0a97c8-ffca-4f99-8a37-ac7797e3e192", "rachelmdominie@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAED5PI+MN0RK6BkP6qQ5nRII79xNq7FBoG+m29xAgyfBb3exKqJCiyVF0bjppl56LwA==", null, false, "87fe7821-127e-4095-8a82-d6b0b0c2170e", false, "RachelD" },
                    { "9012ijkl-0829-4ac5-a3ed-180f5e916a5f", 0, "baf9ef38-26fa-4648-bf0d-5c20087e753e", "elizabethspencer@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEM0QH6BfZ8NZlrY9QWOv0K+c3+us1Z86k6pivu3yB4p6rCs43VXeB01iLqOk2Edv/Q==", null, false, "bae1e55a-4505-475f-a277-05f310f5c963", false, "ElizabethS" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "b29b3c6a-ee3c-42b0-b8b7-aca73ec7f6bb", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEAMRg/cLTPTwKdCZc9b5p3fft97v8LI0zLw7ukAYcO4c+PIbQjrwh+8vYXNuLlsJTA==", null, false, "8dfda1d5-2544-40d8-b51e-3a49c2bcb4e3", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "IsDog", "Name" },
                values: new object[,]
                {
                    { 1, true, "English BullDog" },
                    { 2, true, "Labrador Retriever" },
                    { 3, true, "Golden Retriever" },
                    { 4, true, "Bulldog" },
                    { 5, true, "Beagle" },
                    { 6, true, "Rottweiler" },
                    { 7, true, "Shih Tzu" },
                    { 8, true, "Yorkshire Terrier" },
                    { 9, true, "Boxer" },
                    { 10, true, "Border Collie" },
                    { 11, true, "Siberian Husky" },
                    { 12, false, "Persian Cat" },
                    { 13, false, "Siamese Cat" },
                    { 14, false, "Maine Coon" },
                    { 15, false, "Abyssinian Cat" },
                    { 16, false, "Bengal Cat" },
                    { 17, false, "Bombay Cat" },
                    { 18, false, "Cornish Rex Cat" },
                    { 19, false, "Egyptian Mau Cat" },
                    { 20, false, "Exotic Shorthair Cat" },
                    { 21, false, "Havana Brown Cat" },
                    { 22, false, "Scottish Fold Cat" },
                    { 23, false, "Sphynx Cat" }
                });

            migrationBuilder.InsertData(
                table: "AnimalBreeds",
                columns: new[] { "Id", "AnimalId", "BreedId" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 1, 9 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 3, 5 },
                    { 6, 3, 6 },
                    { 7, 4, 12 },
                    { 8, 4, 13 },
                    { 9, 5, 14 },
                    { 10, 5, 15 },
                    { 11, 6, 12 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "abcdefgh-0829-4ac5-a3ed-180f5e916a5f", "2013iqkp-0829-4ac5-a3ed-180f5e916a5f" },
                    { "abcdefgh-0829-4ac5-a3ed-180f5e916a5f", "5678efgh-0829-4ac5-a3ed-180f5e916a5f" },
                    { "abcdefgh-0829-4ac5-a3ed-180f5e916a5f", "9012ijkl-0829-4ac5-a3ed-180f5e916a5f" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "Email", "Employee", "FullName", "IdentityUserId", "UserName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "admina@strator.comx", true, "Admina Strator", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Administrator" },
                    { 2, "5165 Crosswood dr.", "rachelmdominie@example.com", false, "Rachel Dominie", "5678efgh-0829-4ac5-a3ed-180f5e916a5f", "RachelD" },
                    { 3, "456 Main Street", "elizabethspencer@example.com", false, "Elizabeth Spencer", "9012ijkl-0829-4ac5-a3ed-180f5e916a5f", "ElizabethS" },
                    { 4, "456 Main Street", "mattspencer@example.com", false, "Matt Spencer", "2013iqkp-0829-4ac5-a3ed-180f5e916a5f", "MattS" }
                });

            migrationBuilder.InsertData(
                table: "Adoptions",
                columns: new[] { "Id", "AnimalId", "Foster", "TimeOfAdoption", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 3, false, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 5, false, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 6, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 8, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 13, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 16, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 17, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, 20, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, 23, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, 30, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, 9, false, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 13, 11, false, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, 15, false, new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, 29, false, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_AnimalId",
                table: "Adoptions",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_UserProfileId",
                table: "Adoptions",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalBreeds_AnimalId",
                table: "AnimalBreeds",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalBreeds_BreedId",
                table: "AnimalBreeds",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "AnimalBreeds");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
