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
                    Name = table.Column<string>(type: "text", nullable: false)
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
                    { 5, 2, false, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Elena", "https://i.pinimg.com/736x/39/55/fb/3955fb5e4a3168fae68c51696ee94f1e.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abcdefgh-0829-4ac5-a3ed-180f5e916a5f", null, "User", "user" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5678efgh-0829-4ac5-a3ed-180f5e916a5f", 0, "9b3d04ab-7378-49d2-8845-8b29095b918f", "rachelmdominie@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKoYWM39to9b2DSPWEQegaLtH0qRR762OD9OrMxZFZKwHD5eCELZNI2NCC4hnwQbqg==", null, false, "81dd0aa2-4f99-4703-9968-805a62e356df", false, "RachelD" },
                    { "9012ijkl-0829-4ac5-a3ed-180f5e916a5f", 0, "04e7f8c0-728e-4051-ab2e-eb8581465429", "elizabethspencer@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIAKIyEKfA/CR9VUe9lUVa+8edFXTnUBIGqt+KLEu3huDRmnZJEcuedIFxs9WscemA==", null, false, "aa045d92-fb13-4990-9b23-4f46c10e45f6", false, "ElizabethS" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "369dd695-1e0a-4633-96bd-5134abcfa31f", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEIcJ6ymtdSxX0RG6QkL6qc+lHG4pQbIx4RgCO0KYzn1gcmMsSAo3C9URaVtfsOua9Q==", null, false, "e4ec9083-e574-438f-9865-6f30ddf94539", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "English BullDog" },
                    { 2, "Labrador Retriever" },
                    { 3, "Golden Retriever" },
                    { 4, "Bulldog" },
                    { 5, "Beagle" },
                    { 6, "Rottweiler" },
                    { 7, "Shih Tzu" },
                    { 8, "Yorkshire Terrier" },
                    { 9, "Boxer" },
                    { 10, "Border Collie" },
                    { 11, "Siberian Husky" },
                    { 12, "Persian Cat" },
                    { 13, "Siamese Cat" },
                    { 14, "Maine Coon" },
                    { 15, "Abyssinian Cat" },
                    { 16, "Bengal Cat" },
                    { 17, "Bombay Cat" },
                    { 18, "Cornish Rex Cat" },
                    { 19, "Egyptian Mau Cat" },
                    { 20, "Exotic Shorthair Cat" },
                    { 21, "Havana Brown Cat" },
                    { 22, "Scottish Fold Cat" },
                    { 23, "Sphynx Cat" }
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
                    { 10, 5, 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
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
                    { 3, "456 Main Street", "elizabethspencer@example.com", false, "Elizabeth Spencer", "9012ijkl-0829-4ac5-a3ed-180f5e916a5f", "ElizabethS" }
                });

            migrationBuilder.InsertData(
                table: "Adoptions",
                columns: new[] { "Id", "AnimalId", "Foster", "TimeOfAdoption", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 3, false, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 5, false, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
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
