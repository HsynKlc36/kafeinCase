using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NETDeveloperCaseStudy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.UniqueConstraint("AK_Categories_Name", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    IdentityId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.UniqueConstraint("AK_Markets_Name", x => x.Name);
                    table.UniqueConstraint("AK_Markets_PhoneNumber", x => x.PhoneNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TokenBlackLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenBlackLists", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Barcode = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarketId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductMarkets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CurrencyUnit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarketId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMarkets", x => x.Id);
                    table.UniqueConstraint("AK_ProductMarkets_ProductId_MarketId", x => new { x.ProductId, x.MarketId });
                    table.ForeignKey(
                        name: "FK_ProductMarkets_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMarkets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.UniqueConstraint("AK_OrderDetails_OrderId_ProductId", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a904221-6086-469f-99e1-0e6ece5c66e5", null, "Client", "CLIENT" },
                    { "44373552-14c7-43ca-92bd-1691176fd2ae", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("40e576f2-63c3-45eb-827f-389113dcdfd4"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 694, DateTimeKind.Local).AddTicks(3797), null, null, null, null, null, "Alt Giyim", (byte)4 },
                    { new Guid("47f0cacd-7e44-4989-8eee-2ba09e470abd"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 694, DateTimeKind.Local).AddTicks(3793), null, null, null, null, null, "Dış Giyim", (byte)4 },
                    { new Guid("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 694, DateTimeKind.Local).AddTicks(3775), null, null, null, null, null, "Üst Giyim", (byte)4 }
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("266acab2-0fac-49e8-99e0-86da42d6cdc7"), "İSTANBUL/Bostancı", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 694, DateTimeKind.Local).AddTicks(9841), null, null, null, null, null, "A", "05555555555", (byte)4 },
                    { new Guid("d3c7760f-6166-4058-a343-9c6870ac391d"), "İSTANBUL/Suadiye", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 694, DateTimeKind.Local).AddTicks(9848), null, null, null, null, null, "B", "05555555554", (byte)4 },
                    { new Guid("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), "İSTANBUL/Etiler", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 694, DateTimeKind.Local).AddTicks(9852), null, null, null, null, null, "C", "05555555553", (byte)4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Brand", "CategoryId", "Color", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "Size", "Status" },
                values: new object[,]
                {
                    { new Guid("085aeff8-9d2a-49f5-bc7d-1d4efa55a16f"), "49018237451028", "U.S. Polo Assn", new Guid("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), "White", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1607), null, null, null, null, null, "Gömlek", "XL", (byte)4 },
                    { new Guid("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"), "45123984756234", "Zara", new Guid("47f0cacd-7e44-4989-8eee-2ba09e470abd"), "Brown", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1570), null, null, null, null, null, "Kaban", "XL", (byte)4 },
                    { new Guid("532d0f81-9385-4cef-9a6a-46fc3c9fb65b"), "92837461029834", "Calvin Klein", new Guid("40e576f2-63c3-45eb-827f-389113dcdfd4"), "Khaki", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1595), null, null, null, null, null, "Kumaş Pantolon", "36", (byte)4 },
                    { new Guid("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"), "48590123764580", "Boyner", new Guid("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), "White", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1590), null, null, null, null, null, "Tişört", "2XL", (byte)4 },
                    { new Guid("74b1fa9a-79bb-4b75-9c53-eee57c75e257"), "34028571903428", "H&M", new Guid("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), "Beige", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1593), null, null, null, null, null, "Bluz", "S", (byte)4 },
                    { new Guid("9ff60759-1df3-4762-833f-9c039ce3dd3c"), "23894571028356", "Vakko", new Guid("47f0cacd-7e44-4989-8eee-2ba09e470abd"), "Black", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1586), null, null, null, null, null, "Ceket", "L", (byte)4 },
                    { new Guid("a1e205d0-20ee-40e5-8e4c-e1164cca866e"), "71234569018237", "Nike", new Guid("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), "Blue", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1598), null, null, null, null, null, "Tişört", "2XL", (byte)4 },
                    { new Guid("bd60de37-ebd9-4174-a085-6c29c2991643"), "16734029856127", "Lacoste", new Guid("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), "Pink", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1582), null, null, null, null, null, "Kazak", "XS", (byte)4 },
                    { new Guid("e8e6c63e-5054-4d9b-8f40-7d39865c81f5"), "56348091283749", "Adidas", new Guid("40e576f2-63c3-45eb-827f-389113dcdfd4"), "Red", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1601), null, null, null, null, null, "Şort", "40", (byte)4 },
                    { new Guid("efa0763a-de8e-44f2-a42b-d14727974b7d"), "89347210957368", "Mavi", new Guid("40e576f2-63c3-45eb-827f-389113dcdfd4"), "Blue", "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(1578), null, null, null, null, null, "Kot Pantolon", "38", (byte)4 }
                });

            migrationBuilder.InsertData(
                table: "ProductMarkets",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CurrencyUnit", "DeletedBy", "DeletedDate", "MarketId", "ModifiedBy", "ModifiedDate", "Price", "ProductId", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("00889c8f-3a4d-443a-8886-d70cba842432"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6048), "TL", null, null, new Guid("266acab2-0fac-49e8-99e0-86da42d6cdc7"), null, null, 700.00m, new Guid("532d0f81-9385-4cef-9a6a-46fc3c9fb65b"), (byte)4, 2000 },
                    { new Guid("09051a37-5408-414d-8eb7-b814e02c77af"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6033), "TL", null, null, new Guid("266acab2-0fac-49e8-99e0-86da42d6cdc7"), null, null, 950.00m, new Guid("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"), (byte)4, 1000 },
                    { new Guid("18dcdd57-9952-4cb2-ac42-454221084102"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6054), "TL", null, null, new Guid("d3c7760f-6166-4058-a343-9c6870ac391d"), null, null, 980.00m, new Guid("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"), (byte)4, 1500 },
                    { new Guid("315e8b4b-f028-414a-8ca3-47c50462cc19"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6066), "TL", null, null, new Guid("d3c7760f-6166-4058-a343-9c6870ac391d"), null, null, 900.00m, new Guid("9ff60759-1df3-4762-833f-9c039ce3dd3c"), (byte)4, 1200 },
                    { new Guid("73ad54bc-4c4e-405b-9ee8-51f3b5563eb0"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6045), "TL", null, null, new Guid("266acab2-0fac-49e8-99e0-86da42d6cdc7"), null, null, 200.00m, new Guid("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"), (byte)4, 1400 },
                    { new Guid("781165ab-95dd-4fb7-a5b2-f90d573178f3"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6072), "TL", null, null, new Guid("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), null, null, 565.00m, new Guid("efa0763a-de8e-44f2-a42b-d14727974b7d"), (byte)4, 1350 },
                    { new Guid("7d3f26ba-bca4-46f0-80c9-c51636fe04c1"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6078), "TL", null, null, new Guid("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), null, null, 740.00m, new Guid("532d0f81-9385-4cef-9a6a-46fc3c9fb65b"), (byte)4, 2000 },
                    { new Guid("93845ffc-ef01-4ad1-b3af-009c32a729f5"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6057), "TL", null, null, new Guid("d3c7760f-6166-4058-a343-9c6870ac391d"), null, null, 580.00m, new Guid("efa0763a-de8e-44f2-a42b-d14727974b7d"), (byte)4, 1000 },
                    { new Guid("9f729c2e-be26-42a0-8c97-5586f7ccc48e"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6063), "TL", null, null, new Guid("d3c7760f-6166-4058-a343-9c6870ac391d"), null, null, 620.00m, new Guid("085aeff8-9d2a-49f5-bc7d-1d4efa55a16f"), (byte)4, 3000 },
                    { new Guid("b4df6955-efa5-4fc7-b13c-47011201bb20"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6081), "TL", null, null, new Guid("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), null, null, 590.00m, new Guid("085aeff8-9d2a-49f5-bc7d-1d4efa55a16f"), (byte)4, 2400 },
                    { new Guid("b7c5ffce-f424-461f-b19b-186b3a38d93d"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6060), "TL", null, null, new Guid("d3c7760f-6166-4058-a343-9c6870ac391d"), null, null, 220.00m, new Guid("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"), (byte)4, 1300 },
                    { new Guid("b982c629-7f10-4029-a3c0-ec7c6aadf1c8"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6075), "TL", null, null, new Guid("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), null, null, 190.00m, new Guid("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"), (byte)4, 1950 },
                    { new Guid("ba34a343-25eb-4132-8a6c-5d98ae6d9257"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6051), "TL", null, null, new Guid("266acab2-0fac-49e8-99e0-86da42d6cdc7"), null, null, 890.00m, new Guid("9ff60759-1df3-4762-833f-9c039ce3dd3c"), (byte)4, 1200 },
                    { new Guid("bbaf299a-8c38-4e85-950f-a999bcb48c00"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6069), "TL", null, null, new Guid("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), null, null, 990.00m, new Guid("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"), (byte)4, 800 },
                    { new Guid("d000e58c-ad7e-4569-a3c2-fda50d86a3ce"), "NotFound-User", new DateTime(2024, 5, 17, 14, 33, 14, 696, DateTimeKind.Local).AddTicks(6041), "TL", null, null, new Guid("266acab2-0fac-49e8-99e0-86da42d6cdc7"), null, null, 600.00m, new Guid("efa0763a-de8e-44f2-a42b-d14727974b7d"), (byte)4, 2800 }
                });

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
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MarketId",
                table: "Orders",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMarkets_MarketId",
                table: "ProductMarkets",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true,
                filter: "[BARCODE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductMarkets");

            migrationBuilder.DropTable(
                name: "TokenBlackLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
