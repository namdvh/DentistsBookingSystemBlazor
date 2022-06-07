using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistBooking.Data.Migrations
{
    public partial class ver40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Percent = table.Column<float>(type: "real", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApplyForAll = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Dentists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dentists_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Procedure = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DentistId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDentists",
                columns: table => new
                {
                    DentistId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDentists", x => new { x.ServiceId, x.DentistId });
                    table.ForeignKey(
                        name: "FK_ServiceDentists_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDentists_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyTime = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DentistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Details_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Details_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Details_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "Address", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "Description", "Name", "Phone", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 1, "TestAddress1", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(2253), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(2775), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", "TestClinic1", 868644651, 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(2501), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51") },
                    { 2, "TestAddress2", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3926), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3931), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", "TestClinic2", 868644651, 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3930), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52") },
                    { 3, "TestAddress3", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3961), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3962), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", "TestClinic3", 868644651, 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3962), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53") },
                    { 4, "TestAddress4", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3982), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3984), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", "TestClinic4", 868644651, 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(3983), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54") },
                    { 5, "TestAddress5", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(4010), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(4011), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", "TestClinic5", 868644651, 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(4010), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55") }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "ApplyForAll", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "Description", "EndDate", "Percent", "StartDate", "Title", "Updated_at", "Updated_by", "status" },
                values: new object[,]
                {
                    { 4, 10m, true, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(633), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(635), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(631), 5f, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(630), "TestTitle4", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(634), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), 0 },
                    { 3, 10m, true, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(603), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(605), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(600), 5f, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(599), "TestTitle3", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(603), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), 0 },
                    { 5, 10m, true, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(655), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(657), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(654), 5f, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(653), "TestTitle5", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(656), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), 0 },
                    { 1, 10m, true, new DateTime(2022, 6, 5, 22, 25, 30, 768, DateTimeKind.Local).AddTicks(341), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 6, 5, 22, 25, 30, 768, DateTimeKind.Local).AddTicks(1067), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", new DateTime(2022, 6, 5, 22, 25, 30, 767, DateTimeKind.Local).AddTicks(8298), 5f, new DateTime(2022, 6, 5, 22, 25, 30, 767, DateTimeKind.Local).AddTicks(2124), "TestTitle1", new DateTime(2022, 6, 5, 22, 25, 30, 768, DateTimeKind.Local).AddTicks(571), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), 0 },
                    { 2, 10m, true, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(498), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(500), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(495), 5f, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(489), "TestTitle2", new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(499), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), "894f7711-1950-4e03-b43b-a7855256e01b", "Admin", "Admin", "ADMIN" },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), "bd7e0f04-5d87-4f1d-ab64-7047c6989536", "User", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, "9f851e46-177d-4ab3-b5f2-195fb18647bf", new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3757), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3759), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECcRzkJ3YUc3D7N9DXHOX0B8N0JYrhJQz5sYxtH1uKa0ijH2wHzjeHowylkwTyA1Sw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3758), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, "eee7de88-3429-43fe-b0c2-87465aaec970", new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6523), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6527), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEAvpdiBgfqyNAwCZSHzrz/qu5f74DK78Skza4XYX9nShK6O/UmXm83mZACGg7IbRMQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6526), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, "0e977f97-3abf-463f-8bc5-9829cd436440", new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6564), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6566), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECKFTHAEXu4ZhatuMRYaInLO1QYGXl3MgYDmwO0m982nSpPTDd1SYUno+tVjX4LsaQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6565), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, "ed20f74a-a19e-4652-b865-82f59df01c1c", new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9281), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9285), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEuLNmL16rZyUqZS5qKQN7Oin6W37jQIgKOZB97YrnUEJOu0gGDr0WhUmhFu3cwxVw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9284), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, "3b33509d-26f2-440f-8a48-a780fb67235e", new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(106), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(108), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPptXW9gxH+WpqFl1KeiG63vFeIg+Hq+wIsLTjCHvgkkeqDLgvWmLmpsuY4ne7AnPw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(107), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, "9f675ff2-10b2-44c7-80f0-6826bfe769ab", new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4609), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4613), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEH8rNXTOce3sDhRBxEKLhw5aFfqeaGxK+HCW239aiijo9a/cSEDuxkpykluSZiZgYg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4612), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, "2e88d230-1ca0-4367-a907-97fa986c42a8", new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6375), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6377), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEK3tmXhWsj+JJx1M+aso6NO3ADVkKfG+CkMKp7n5niH/N1vIVBW0gelpXuJcNiOh6g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6376), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, "1fd854f5-1f58-4f96-8c8f-a23edfe51505", new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8700), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8702), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELBdt4xBG13uA4jEG3twfkBPR2p62BjmiuU61JpB5C5vlsmtz0cT68ql8I86qkzlUg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8701), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, "71200cb0-0d13-4f94-8a1d-0ff865505b74", new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1480), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1484), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEHvBR9OElhnvxDD+kOsEgZOqG3H9qGREdiGbLcZ9+He/D4ekBS6KxjNvrLgw8UzK1A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1483), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, "45cf6df5-55e9-42fe-8836-2e62bb34ab18", new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2600), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEFP5JPm+bs0+iU4rbmSzVQfJsvKbBRkY8AX/IXTcwu1dVouIhTfdYJAaLTksSZRy/w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, "d2b60fc4-e899-423e-8e80-b38642f25e45", new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4672), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEJ07FMZGhxiL5OTwPLt2J0qQWg8OGZIUluqgL/61ikrqIm2qQp8nt1oVO6oQTmK9Cg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4678), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, "46fac6f6-0d28-4070-bafc-47fac69cf361", new DateTime(2022, 6, 5, 15, 25, 30, 780, DateTimeKind.Utc).AddTicks(8804), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 780, DateTimeKind.Utc).AddTicks(9325), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEOK9OEHNSILv1nHfcTdhe7Od/zGxowLsB8ZrFBiHhXgTcP4Ovdl3VEfBEES7JPLM+A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 780, DateTimeKind.Utc).AddTicks(9043), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, "fef10731-5b10-4b0a-a790-79202b87ffb9", new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1918), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1920), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELZCPv/U1J2ucd4OTVE96FpTAiyfVJDqufzhaAN13/cEAEwgOtoU6k+SS3aqgbkt8A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1919), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, "fbc73e15-4ecb-49c0-960d-ce5c937c9836", new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(902), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(904), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEN5IGwRusXIH0kD0nnh5hxm/aZMNdVOKEb7DD3pJ7e67FQiytgWvA0XVgcRLxLJ6hw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(903), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, "bfd5fdfa-581c-46b5-81d1-e421a8b7959f", new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(4987), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(4989), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEA5RTvt/I8dj1jcgxaxHtv6B2Kjn/irOZyIOVuJtPkBOr+wVUN15yRM9vo1VzafamQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(4988), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, "e85343d7-6376-4b29-9c2f-efdd87cefab4", new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7083), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7086), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEBZoW6G2bQ7Zqx456jTFWuE8rfQXgs2vDp3KAXcL8mWGwXgU2PFQQeFda0lyiWVAJg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7085), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, "aaca485d-561e-4268-8786-f3f33bc710f6", new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(3978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(3982), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPZeUKhZnlADC+1BJoSdCxMQJtUW7A4hnHF6auANy4hTEuNeg2vR6BseuZgp2p+Bug==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(3981), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, "63869c1d-0274-48f8-b275-89fe67ffacf0", new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1381), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1383), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEF1gsa1MdlLnGHfZBrMMdoKFQozBfXjH9/I3lj3tLlwc3fUBdW5ph5RUeUDmhsqAPA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1382), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, "f2933988-c5da-4793-9a4f-d4b20e068de8", new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8613), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8615), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEHPrXEIyeSKjMBrfH0w55D66/I9NlN+tX+ZFj+SUXiE3D7LnCrGGmLGXnwxumldDow==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8614), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, "4fc67d61-ebda-4299-bd4b-3d0a2486af98", new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6329), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6331), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEP7ML7rp3STbArLiWisO/Slc6juzuJJDankYTBl2xN+9F9O5VeYip/bDM36UJBUZ4w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6330), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, "44960615-c012-42b2-823f-136d81d0d7f4", new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4577), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4582), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECsutRBJgZLy25h7RwxAt6Z5MQ3C4Bei3wpA4toqIFzoPc47OW5N4wwWpjCh6T/oKQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4580), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, "b88ca64d-c2bf-4bac-b7fa-147bcc21a28e", new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1872), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1874), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGx5+lTgqU+NLiBxKn9JhK6qGZuktnobAidhRndjJ+k7XpMNoMCjzoBi2rBfXJpvAw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1873), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, "b6394346-dfc2-432a-a609-83a6df2feb0b", new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1515), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1517), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECsMPq3EDRKDqYI82WTbEVU4THrHBtdC7ahFJr/Git4nWS0X5dtHqEoMYa0x+1ynkQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1516), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, "60330388-ac0d-4c24-8641-8149793e6346", new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(124), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(128), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEF8U913xKZUXj909Qycc0yFMXcQ0Mqurs0w1H2nXngk9qRWKLLc/u9IQXTK5hkMOMw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(127), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, "c9f6ce37-559a-40fe-a8f2-fe8e108219e3", new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8264), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8266), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEL2FcBMNLEZ08keHADqHfihmcHrapn3ddwfLm4jWmTZ8Ve6vEwgThCavIe5Ca5jcOQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8265), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, "aac87643-2d75-4021-8b72-586cf678695b", new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6464), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6467), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEI72wLFKUoH+968AQtlTRbcJeoyxQYg2ff1PdVoxB0SSqaJpWP4bdnJWAaKG93Ty+g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6466), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, "f26b7f56-8664-423e-b7b8-c19a42c0dc4d", new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8092), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8096), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEG/optcxx/7xkQu6rI1vdCA2AdiIx/9OfipBFtDmuUVBwVvy4UTRhWuWWpujucFEAA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8094), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, "353b8a23-7ec8-47f5-abc8-d609066d5351", new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6775), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGkDuPuiye1dJoopHdrCw8Cwnz0nSpJoZ+/p+3enB27IRGtjmey8hJI460sj3zxAZQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6783), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, "c9d02bf8-9447-4e76-88a7-fb7cfb4a3e37", new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7250), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7260), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECOZYEvKp8N3C4/cpvxVaFkf3btnMzivlHAjposJBF0D+KzXvAQ9S+Jgtf0z1gP9SA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7259), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, "ed01670a-c626-4f85-bb95-22b075ca1d6d", new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9756), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9760), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEB66cTS0lYIUKm6aZUD0bnzU4TpJWF5bB3GizUS9plb0ENYeVE+nLFB/jMvxFORlMA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9759), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, "6c9cb462-3fc4-4b63-984f-06536108f45f", new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1289), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1294), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGD0h4zp4yvHQHDsCJS4Hyvp/H0twWdTTliEiz7I2nHQAPBq/85/ufl+gzTC+LV3dQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1292), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7530), new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7529), new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7533), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 956, DateTimeKind.Utc).AddTicks(7531), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650") },
                    { 30, new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6905), new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6902), new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6908), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 950, DateTimeKind.Utc).AddTicks(6906), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649") },
                    { 1, new DateTime(2022, 6, 5, 15, 25, 30, 781, DateTimeKind.Utc).AddTicks(1984), new DateTime(2022, 6, 5, 15, 25, 30, 781, DateTimeKind.Utc).AddTicks(1290), new DateTime(2022, 6, 5, 15, 25, 30, 781, DateTimeKind.Utc).AddTicks(2445), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 781, DateTimeKind.Utc).AddTicks(2206), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620") },
                    { 2, new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4817), new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4815), new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4818), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 787, DateTimeKind.Utc).AddTicks(4817), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621") },
                    { 3, new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2705), new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2704), new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 793, DateTimeKind.Utc).AddTicks(2706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622") },
                    { 4, new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1569), new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1567), new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1571), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 799, DateTimeKind.Utc).AddTicks(1570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623") },
                    { 5, new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8736), new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8735), new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8737), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 804, DateTimeKind.Utc).AddTicks(8737), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624") },
                    { 6, new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6406), new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6405), new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6408), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 810, DateTimeKind.Utc).AddTicks(6407), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625") },
                    { 7, new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4760), new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4758), new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4762), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 816, DateTimeKind.Utc).AddTicks(4761), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626") },
                    { 9, new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(139), new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(137), new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(140), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 828, DateTimeKind.Utc).AddTicks(139), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628") },
                    { 10, new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9384), new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9383), new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9386), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 833, DateTimeKind.Utc).AddTicks(9385), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629") },
                    { 11, new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6599), new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6598), new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6600), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 839, DateTimeKind.Utc).AddTicks(6599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630") },
                    { 12, new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6629), new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6628), new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6631), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 845, DateTimeKind.Utc).AddTicks(6630), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631") },
                    { 13, new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3788), new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3787), new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3790), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 851, DateTimeKind.Utc).AddTicks(3789), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632") },
                    { 14, new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(932), new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(931), new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(934), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 857, DateTimeKind.Utc).AddTicks(933), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633") },
                    { 8, new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1952), new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1950), new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 822, DateTimeKind.Utc).AddTicks(1952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627") },
                    { 16, new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7170), new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7169), new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7172), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 868, DateTimeKind.Utc).AddTicks(7171), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635") },
                    { 15, new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9874), new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9872), new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9876), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 862, DateTimeKind.Utc).AddTicks(9875), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634") },
                    { 28, new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6557), new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6555), new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6558), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 938, DateTimeKind.Utc).AddTicks(6557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647") },
                    { 27, new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8299), new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8298), new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8301), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 932, DateTimeKind.Utc).AddTicks(8300), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646") },
                    { 26, new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(226), new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(224), new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(228), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 927, DateTimeKind.Utc).AddTicks(227), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645") },
                    { 24, new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1958), new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1957), new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1960), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 915, DateTimeKind.Utc).AddTicks(1959), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643") },
                    { 23, new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4694), new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4693), new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4696), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 909, DateTimeKind.Utc).AddTicks(4695), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642") },
                    { 25, new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1556), new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1555), new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1558), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 921, DateTimeKind.Utc).AddTicks(1557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644") },
                    { 29, new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8232), new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8225), new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8234), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 944, DateTimeKind.Utc).AddTicks(8232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648") },
                    { 21, new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8644), new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8643), new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 897, DateTimeKind.Utc).AddTicks(8645), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640") },
                    { 20, new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1430), new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1428), new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1432), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 892, DateTimeKind.Utc).AddTicks(1431), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639") },
                    { 19, new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1427), new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1425), new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1428), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 886, DateTimeKind.Utc).AddTicks(1428), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638") },
                    { 18, new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(4104), new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(4103), new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(4106), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 880, DateTimeKind.Utc).AddTicks(4105), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637") },
                    { 17, new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(5031), new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(5030), new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(5033), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 874, DateTimeKind.Utc).AddTicks(5032), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636") },
                    { 22, new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6370), new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6368), new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6371), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, 100m, new DateTime(2022, 6, 5, 15, 25, 30, 903, DateTimeKind.Utc).AddTicks(6370), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641") }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "Id", "ClinicId", "Description", "Position" },
                values: new object[,]
                {
                    { 63, 1, "TestDescirption63", 0 },
                    { 59, 1, "TestDescirption59", 0 },
                    { 60, 1, "TestDescirption60", 0 },
                    { 61, 1, "TestDescirption61", 0 },
                    { 62, 1, "TestDescirption62", 0 },
                    { 64, 1, "TestDescirption64", 0 },
                    { 71, 1, "TestDescirption71", 0 },
                    { 66, 1, "TestDescirption66", 0 },
                    { 67, 1, "TestDescirption67", 0 },
                    { 68, 1, "TestDescirption68", 0 },
                    { 69, 1, "TestDescirption69", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "Id", "ClinicId", "Description", "Position" },
                values: new object[,]
                {
                    { 70, 1, "TestDescirption70", 0 },
                    { 57, 1, "TestDescirption57", 0 },
                    { 65, 1, "TestDescirption65", 0 },
                    { 56, 1, "TestDescirption56", 0 },
                    { 58, 1, "TestDescirption58", 0 },
                    { 54, 1, "TestDescirption54", 0 },
                    { 32, 1, "TestDescirption32", 0 },
                    { 31, 1, "TestDescirption31", 0 },
                    { 30, 1, "TestDescirption30", 0 },
                    { 29, 1, "TestDescirption29", 0 },
                    { 28, 1, "TestDescirption28", 0 },
                    { 27, 1, "TestDescirption27", 0 },
                    { 26, 1, "TestDescirption26", 0 },
                    { 25, 1, "TestDescirption25", 0 },
                    { 24, 1, "TestDescirption24", 0 },
                    { 23, 1, "TestDescirption23", 0 },
                    { 33, 1, "TestDescirption33", 0 },
                    { 22, 1, "TestDescirption22", 0 },
                    { 20, 1, "TestDescirption20", 0 },
                    { 19, 1, "TestDescirption19", 0 },
                    { 18, 1, "TestDescirption18", 0 },
                    { 17, 1, "TestDescirption17", 0 },
                    { 16, 1, "TestDescirption16", 0 },
                    { 15, 1, "TestDescirption15", 0 },
                    { 14, 1, "TestDescirption14", 0 },
                    { 13, 1, "TestDescirption13", 0 },
                    { 12, 1, "TestDescirption12", 0 },
                    { 11, 1, "TestDescirption11", 0 },
                    { 21, 1, "TestDescirption21", 0 },
                    { 55, 1, "TestDescirption55", 0 },
                    { 34, 1, "TestDescirption34", 0 },
                    { 36, 1, "TestDescirption36", 0 },
                    { 53, 1, "TestDescirption53", 0 },
                    { 52, 1, "TestDescirption52", 0 },
                    { 51, 1, "TestDescirption51", 0 },
                    { 50, 1, "TestDescirption50", 0 },
                    { 49, 1, "TestDescirption49", 0 },
                    { 48, 1, "TestDescirption48", 0 },
                    { 47, 1, "TestDescirption47", 0 },
                    { 46, 1, "TestDescirption46", 0 },
                    { 45, 1, "TestDescirption45", 0 },
                    { 44, 1, "TestDescirption44", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "Id", "ClinicId", "Description", "Position" },
                values: new object[,]
                {
                    { 35, 1, "TestDescirption35", 0 },
                    { 43, 1, "TestDescirption43", 0 },
                    { 41, 1, "TestDescirption41", 0 },
                    { 40, 1, "TestDescirption40", 0 },
                    { 39, 1, "TestDescirption39", 0 },
                    { 38, 1, "TestDescirption38", 0 },
                    { 37, 1, "TestDescirption37", 0 },
                    { 42, 1, "TestDescirption42", 0 },
                    { 10, 1, "TestDescirption10", 0 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DiscountId", "Name", "Price", "Procedure", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(7500), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(7977), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), 1, "testService@gmail.com1", 1m, "testProcedure1", 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(7731), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1") },
                    { 2, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9304), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9309), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), 2, "testService@gmail.com2", 2m, "testProcedure2", 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9308), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2") },
                    { 3, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9340), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9342), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), 3, "testService@gmail.com3", 3m, "testProcedure3", 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9341), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3") },
                    { 4, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9363), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9365), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), 4, "testService@gmail.com4", 4m, "testProcedure4", 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9364), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4") },
                    { 5, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9425), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9427), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), 5, "testService@gmail.com5", 5m, "testProcedure5", 0, new DateTime(2022, 6, 5, 22, 25, 30, 769, DateTimeKind.Local).AddTicks(9426), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 11, 4, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5870), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5872), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 34, 12, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6322), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6323), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6322), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 35, 12, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6338), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6340), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6339), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 36, 12, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6422), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6423), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6423), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 37, 13, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6439), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6440), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6440), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 38, 13, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6456), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6458), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6457), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 39, 13, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6473), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6474), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6473), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 40, 14, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6490), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6491), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6490), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 33, 11, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6304), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6305), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6305), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 41, 14, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6506), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6507), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6507), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 43, 15, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6539), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6541), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6540), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 44, 15, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6556), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 45, 15, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6605), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6607), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6606), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 46, 16, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6623), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6624), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6623), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 47, 16, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6639), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6641), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6640), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 48, 16, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6656), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6657), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6657), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 49, 17, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6673), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6674), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6673), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 42, 14, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6522), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6524), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6523), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 32, 11, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6288), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6289), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 31, 11, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6272), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6273), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6272), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 30, 10, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6256), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6257), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6256), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 13, 5, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5903), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5905), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5904), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 14, 5, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5920), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5921), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5921), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 15, 5, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5937), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5938), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5937), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 16, 6, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5954), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5954), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 17, 6, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5969), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5970), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5970), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 18, 6, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5987), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5988), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5987), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 19, 7, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6039), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6040), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6039), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 20, 7, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6056), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6057), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6057), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 21, 7, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6072), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6074), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6073), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 22, 8, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6090), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 23, 8, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6105), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6107), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6106), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 24, 8, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6122), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6123), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6123), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 25, 9, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6138), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6139), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6139), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 26, 9, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6155), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6156), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6155), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 27, 9, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6171), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6172), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6171), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 28, 10, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6222), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6224), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6223), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 29, 10, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6239), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 50, 17, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6689), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6690), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6690), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 51, 17, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 52, 18, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6722), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6723), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6722), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 53, 18, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6770), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6772), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6771), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 75, 25, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7201), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7202), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7201), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 76, 26, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7217), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7218), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7218), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 77, 26, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7233), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7235), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7234), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 78, 26, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7250), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7251), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7251), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 79, 27, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7301), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7303), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7302), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 80, 27, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7318), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7319), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 81, 27, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7335), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7336), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7335), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 82, 28, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7351), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7353), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7352), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 83, 28, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7367), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7369), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7368), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 84, 28, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7384), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7385), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7384), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 85, 29, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7400), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 86, 29, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7416), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7417), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7417), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 87, 29, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7432), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7434), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7433), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 88, 30, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7483), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7485), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7484), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 89, 30, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7500), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7502), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7501), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 90, 30, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7517), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7518), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7518), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 91, 31, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7533), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7535), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7534), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 74, 25, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7184), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7186), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7185), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 12, 4, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5887), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 73, 25, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7168), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7169), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7169), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 71, 24, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7135), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7136), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7136), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 54, 18, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6790), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6791), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6790), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 55, 19, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6806), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6808), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6807), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 56, 19, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6823), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6824), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6823), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 57, 19, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6839), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6840), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6839), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 58, 20, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6855), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 59, 20, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6873), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6872), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 60, 20, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6889), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 61, 21, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6904), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6905), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6904), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 62, 21, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6949), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6951), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6950), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 63, 21, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6968), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6970), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6969), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 64, 22, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6985), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6986), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(6986), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 65, 22, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7001), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7003), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7002), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 66, 22, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7019), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7020), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7020), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 67, 23, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7036), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7037), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7036), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 68, 23, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7052), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7054), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7053), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 69, 23, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7069), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7070), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7070), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 70, 24, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7118), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7120), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7119), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 72, 24, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7152), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7153), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7152), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 92, 31, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7551), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7551), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 93, 31, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7566), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7567), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7567), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 9, 3, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5800), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5801), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5800), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 8, 3, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5783), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5785), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5784), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 7, 3, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5768), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5767), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 6, 2, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5749), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5750), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5749), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 5, 2, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5729), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 4, 2, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5712), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5714), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5713), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 3, 1, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5693), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5695), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5694), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 2, 1, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5659), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5663), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5661), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 1, 1, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(3844), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(4364), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(4086), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 10, 4, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5849), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5851), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(5851), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") }
                });

            migrationBuilder.InsertData(
                table: "ServiceDentists",
                columns: new[] { "DentistId", "ServiceId" },
                values: new object[,]
                {
                    { 34, 2 },
                    { 35, 2 },
                    { 36, 2 },
                    { 37, 2 },
                    { 42, 3 },
                    { 40, 2 },
                    { 41, 3 },
                    { 33, 2 },
                    { 38, 2 },
                    { 32, 2 },
                    { 27, 1 },
                    { 30, 1 },
                    { 29, 1 },
                    { 28, 1 },
                    { 43, 3 },
                    { 26, 1 },
                    { 25, 1 },
                    { 24, 1 },
                    { 23, 1 },
                    { 22, 1 },
                    { 21, 1 },
                    { 20, 1 },
                    { 31, 2 },
                    { 44, 3 },
                    { 39, 2 },
                    { 46, 3 },
                    { 70, 5 },
                    { 45, 3 },
                    { 68, 5 },
                    { 67, 5 },
                    { 66, 5 },
                    { 65, 5 },
                    { 64, 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceDentists",
                columns: new[] { "DentistId", "ServiceId" },
                values: new object[,]
                {
                    { 63, 5 },
                    { 62, 5 },
                    { 61, 5 },
                    { 60, 4 },
                    { 59, 4 },
                    { 69, 5 },
                    { 57, 4 },
                    { 58, 4 },
                    { 48, 3 },
                    { 49, 3 },
                    { 50, 3 },
                    { 51, 4 },
                    { 47, 3 },
                    { 53, 4 },
                    { 54, 4 },
                    { 55, 4 },
                    { 56, 4 },
                    { 52, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, "39afaab0-3809-41cd-86ae-3f05f3fc42de", new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7185), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7193), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEPWvP05DLs34136bULhoHW6nvkfify3s0CiEfjIV6tx/1sruxunbDSp13s3zn5hhTA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7192), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, "c3cb8a43-bc49-4612-a86e-0ae358f4a9b4", new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5579), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5588), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEG8KIuvwOXu8oHrtCJM+TW327VI2Vj57VKLXm+rcOUqBr09rNf1xifOeERHuU0+4mw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5587), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, "964f6e54-88cf-4d52-91c2-33198a8a34e1", new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4535), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4537), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAELgyU+lkqPB/ut3ht8HCERSlqmFpEkMZxlSieKGZKhrWfaGiX6KOYG8pD5loaMdoqg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4536), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, "d2e2c5d1-4b72-48b6-969a-055a487bbc49", new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1800), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1802), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEMLiihVqDOKvBX4HFjqGdmuy+s+DAIaASOyoMihKEkIuTxnqUxW8uSVqjJibtVlwOg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1801), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, "ee8f940e-e980-4dd1-8051-a954b3412b8e", new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2622), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2631), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKBfIfVaT6lf3M3TthOjVBP5dw+BAX2R6R4/qNzpwc8mvRtLJHl+ZDq6lnu37uMavw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2629), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, "2ca7005e-7ffc-4c97-82ae-fd60ea234953", new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(507), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(510), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEEb6twnmSAhWs+zcXdIL9UFQqF/M9TsdeKWef/cSnajjM9CcZ4oiwnPpsxRHIGsk5Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(508), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, "6d627f19-4931-4514-8387-423be46def64", new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(144), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(146), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEE3lCcZxwOSJ4DqGkHKy7d9w6rXlpB77MdUwlfJbUEFrdA74K0zQ2f025Blqi0lphA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(146), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, "874ca09c-d4cb-4df1-a6b9-85bcd64babd7", new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9156), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9162), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAECZHTi9B9MIBmCmN+ADG4yx0gWzuLV1GmbTzvCumV+azP7pvjpCSLcMzJwV1/8iRyQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9160), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, "faba21f8-4dc2-4894-a136-39c21741bac1", new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7010), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7013), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKLuoPvMddfyR8jewBLiXiIkrdsOh8IPSXAbh6/F82/Or8w8SCdOE4XGL6oL9JJSPA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7012), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, "0726a87f-ebda-4c37-98fd-5f7b863e2443", new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(101), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(103), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 66, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEFpbpywJtC2l+HAlQvMAR8rFGZaiU9MZBF+B70DB20r7pKMhwT6rTJwQ7dMKLms1yw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(102), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, "53a2fc8a-29ca-4f89-8bce-11adf13f71ac", new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3357), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3359), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 62, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEG+ehwU1Qt12/NguFC09EtVMSnrmpulQ9Pu9AFUM2UTVLnGp/oeug+uTSDbTkeRRyw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3358), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, "7b35d2ef-504c-4ec8-8d3f-e40f97b84c08", new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2748), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2754), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 63, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEG3QkwSvb3l9CFcuI/12ukYfgSPvWGTe8hFRSNCniAsXq95x6kNm5+D0tZhOp/nBzA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2753), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, "61cc36a4-df5e-4000-bf1c-54d1ff8d119f", new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1484), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1486), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 64, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEE9juKF9tr/LA6JE7EcWwG4FYZb8G+QOZn0qrLJLd9iMTbZwZRm8rtPYtv+k30STkw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1485), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, "1cccafc5-9490-4184-ab8d-f3f3844fe389", new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1491), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1494), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 65, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEOb94O+RipulhLSYXwMqhFsz14rE45Q7GksSp8JoSkDctvnwa2kxLJs0Ot9MxhTC4g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1493), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, "23c60dc0-04da-4879-82e0-bf3c9bb3a4c0", new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9221), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9223), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 67, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEGdiuTpzrzRgi6XFsjzzTEFNpTnYRGC11jp/bCmi3LsbHGeg0e2eAIGJUWdllbM/jw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9222), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, "2c0a729d-5725-4925-a180-8822b622da28", new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8529), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8536), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 68, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEABPDffrWCG0VEf892ZjOf6MVTRqys96xxpeWlIVqYdlrikkEXNy7KdrFHyW2ONK/A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8534), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, "8482e675-c251-4342-8d94-2b52bedc7bd6", new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7258), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7261), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 69, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAECSShjelM9lnM82vT47ZHD5oo4j4VG9t6TX+W0+Ii+X+iOowvtNg60bRRpwkfxMOfg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7260), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, "dab81444-10ca-4205-8dd0-7a89853575b1", new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4566), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4578), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 70, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEMusdBtiji7DPH0N8q5sDunhhfOVm9gyj7A4eNngz4ayIQEsrimImtZu2EjAzzo1Zw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4576), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, "d7594e9a-42d3-473d-a6ef-b6216cd6e593", new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1273), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1278), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 71, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEP5W/Du5gjRK9blP5nPaUgf3ptic9j1xhvWinFbZNu6hDFn0yKofmSXpm2t3DE4L5w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1276), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, "3a0a1094-f5e5-4c91-b82b-471c11ad9145", new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4592), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4594), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 61, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHmPRJcbgQC++WquHG/rtw8hLc9I+TNnlfDI/zyh4+Op1pBaFif7blikPhRjSXtoAQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4594), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, "69fb0d0c-e605-41f8-989e-9d80bfc1276e", new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(4728), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(4731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEBkVLq+x5AcUlWzd6pdLJvlMjNQ0II5K4Al0jOPGEHGjs66mCF9UrYMEd3Je+WqycA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(4729), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 32, new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(5761), new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(5759), new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(5763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 962, DateTimeKind.Utc).AddTicks(5761), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 50, new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7332), new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7331), new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7334), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 68, DateTimeKind.Utc).AddTicks(7333), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369") },
                    { 49, new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8729), new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8727), new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 62, DateTimeKind.Utc).AddTicks(8730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368") },
                    { 48, new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9257), new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9256), new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9259), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 56, DateTimeKind.Utc).AddTicks(9258), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367") },
                    { 47, new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(132), new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(131), new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(133), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 51, DateTimeKind.Utc).AddTicks(133), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366") },
                    { 46, new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1573), new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1571), new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1575), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 45, DateTimeKind.Utc).AddTicks(1574), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365") },
                    { 45, new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1527), new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1525), new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1528), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 39, DateTimeKind.Utc).AddTicks(1528), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364") },
                    { 44, new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2876), new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2874), new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2878), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 33, DateTimeKind.Utc).AddTicks(2877), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363") },
                    { 43, new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3399), new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3398), new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 27, DateTimeKind.Utc).AddTicks(3400), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362") },
                    { 51, new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4752), new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4751), new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4754), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 76, DateTimeKind.Utc).AddTicks(4753), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370") },
                    { 42, new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4701), new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4699), new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4702), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 21, DateTimeKind.Utc).AddTicks(4701), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361") },
                    { 40, new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7294), new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7293), new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7296), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 9, DateTimeKind.Utc).AddTicks(7295), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 39, new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9277), new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9276), new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9279), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 3, DateTimeKind.Utc).AddTicks(9278), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 38, new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(223), new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(222), new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(224), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 998, DateTimeKind.Utc).AddTicks(224), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 37, new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(711), new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(710), new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(713), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 992, DateTimeKind.Utc).AddTicks(712), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 36, new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2780), new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2779), new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2782), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 986, DateTimeKind.Utc).AddTicks(2781), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 35, new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1838), new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1837), new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1839), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 980, DateTimeKind.Utc).AddTicks(1839), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 34, new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4618), new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4617), new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4620), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 974, DateTimeKind.Utc).AddTicks(4619), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 33, new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5695), new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5694), new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 30, 968, DateTimeKind.Utc).AddTicks(5696), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 41, new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7099), new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7097), new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7100), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 15, DateTimeKind.Utc).AddTicks(7099), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 52, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1431), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1430), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1433), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, 200m, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(1432), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 94, 32, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7582), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7584), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7583), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 126, 42, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8255), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8257), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8256), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 127, 43, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8272), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8273), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8273), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 128, 43, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8288), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8289), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 129, 43, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8304), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8305), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8305), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 130, 44, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8355), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8356), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8356), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 131, 44, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8373), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8374), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8373), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 132, 44, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8389), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8391), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8390), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 133, 45, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8405), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8407), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8406), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 134, 45, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8422), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8424), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8423), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 135, 45, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8438), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8440), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8439), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 136, 46, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8455), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8456), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8456), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 137, 46, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8471), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8472), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8472), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 125, 42, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8239), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 138, 46, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8519), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8520), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8519), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 140, 47, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8553), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8554), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8554), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 141, 47, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8571), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 142, 48, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8586), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8588), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8587), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 143, 48, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8602), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8604), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8603), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 144, 48, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8618), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8620), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8619), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 145, 49, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8635), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8636), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8635), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 146, 49, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8651), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8652), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8652), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 147, 49, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8700), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8699), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 148, 50, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8716), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8717), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8716), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 149, 50, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8732), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8734), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8733), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 150, 50, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8749), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8750), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8750), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 151, 51, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8768), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8767), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 139, 47, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8537), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8538), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8538), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 124, 42, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8223), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8224), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8223), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 123, 41, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8206), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8207), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8206), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 122, 41, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8154), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8156), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8155), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 95, 32, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7600), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 96, 32, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7645), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 97, 33, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7664), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7665), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7664), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 98, 33, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7682), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7681), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 99, 33, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 100, 34, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7713), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7715), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7714), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 101, 34, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 102, 34, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7746), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7747), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7747), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 103, 35, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7762), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 104, 35, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7780), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 105, 35, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7841), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7843), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7842), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 106, 36, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7861), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7862), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7861), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 107, 36, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7878), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7879), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7879), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 108, 36, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7895), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7896), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7895), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 109, 37, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7911), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7912), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7912), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 110, 37, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7927), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7929), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7928), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 111, 37, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7943), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7945), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7944), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 112, 38, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7960), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7961), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7960), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 113, 38, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7975), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7977), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(7976), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 114, 38, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8023), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8025), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8024), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 115, 39, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8042), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 116, 39, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8057), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8059), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8058), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 117, 39, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8073), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8075), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8074), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 118, 40, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8090), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8091), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8091), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 119, 40, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8106), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8108), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8107), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 120, 40, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8122), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8124), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8123), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 121, 41, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8138), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8140), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8139), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 152, 51, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8782), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8784), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8783), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 153, 51, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8798), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8800), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 5, 15, 25, 31, 83, DateTimeKind.Utc).AddTicks(8799), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_BookingId",
                table: "Booking_Details",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_DentistId",
                table: "Booking_Details",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_ServiceId",
                table: "Booking_Details",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dentists_ClinicId",
                table: "Dentists",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDentists_DentistId",
                table: "ServiceDentists",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DiscountId",
                table: "Services",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DentistId",
                table: "Users",
                column: "DentistId",
                unique: true,
                filter: "[DentistId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Details");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ServiceDentists");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Dentists");

            migrationBuilder.DropTable(
                name: "Clinics");
        }
    }
}
