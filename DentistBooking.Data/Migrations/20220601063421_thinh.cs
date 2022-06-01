using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistBooking.Data.Migrations
{
    public partial class thinh : Migration
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
                    { 1, "TestAddress1", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(9372), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(9782), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", "TestClinic1", 868644651, 0, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(9566), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51") },
                    { 2, "TestAddress2", new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(707), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(713), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", "TestClinic2", 868644651, 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(711), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52") },
                    { 3, "TestAddress3", new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(741), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(744), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", "TestClinic3", 868644651, 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(743), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53") },
                    { 4, "TestAddress4", new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(768), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(771), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", "TestClinic4", 868644651, 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(770), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54") },
                    { 5, "TestAddress5", new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(803), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(805), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", "TestClinic5", 868644651, 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(804), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55") }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "ApplyForAll", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "Description", "EndDate", "Percent", "StartDate", "Title", "Updated_at", "Updated_by", "status" },
                values: new object[,]
                {
                    { 4, 10m, true, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8020), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8022), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8018), 5f, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8017), "TestTitle4", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8021), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), 0 },
                    { 3, 10m, true, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7932), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7934), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7930), 5f, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7929), "TestTitle3", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7933), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), 0 },
                    { 5, 10m, true, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8049), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8051), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8047), 5f, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8046), "TestTitle5", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(8050), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), 0 },
                    { 1, 10m, true, new DateTime(2022, 6, 1, 13, 34, 20, 993, DateTimeKind.Local).AddTicks(7997), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 6, 1, 13, 34, 20, 993, DateTimeKind.Local).AddTicks(8598), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", new DateTime(2022, 6, 1, 13, 34, 20, 993, DateTimeKind.Local).AddTicks(3697), 5f, new DateTime(2022, 6, 1, 13, 34, 20, 992, DateTimeKind.Local).AddTicks(6666), "TestTitle1", new DateTime(2022, 6, 1, 13, 34, 20, 993, DateTimeKind.Local).AddTicks(8185), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), 0 },
                    { 2, 10m, true, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7834), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7836), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7829), 5f, new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7822), "TestTitle2", new DateTime(2022, 6, 1, 13, 34, 20, 994, DateTimeKind.Local).AddTicks(7835), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), "318df0e8-ad47-403a-9b07-3d646725453a", "Admin", "Admin", "ADMIN" },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), "dcdc8cc1-34a9-4c23-8bd2-239915cc7e10", "User", "User", "USER" }
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
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, "b523e516-48c6-4a40-ae78-409cceac9bc5", new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(617), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEM/8XHTvf3af45d5VtfCC4AVz3R1QsI75oqrqc1zsRQYx+UXb+xvL1E2oJvcJv0LXA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(612), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, "c7753eb5-5d92-49f2-b638-db022123a174", new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6167), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6169), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECMBixQO2IuKHWv4mK1z+ePDHxKy5zlf99qmtq2gPreMZhQzV7SVxUGjEXwRgOVYoA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6168), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, "dfe7eb00-5cd7-47e9-aa07-ddd3107357ee", new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3691), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3693), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPP+uWU9oJABGJgpK9rM0hEhwqP4oPOS90V+DuOR5Zh2j0xhokGYcWZZKkByIeOr6A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3692), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, "83ded773-63de-4118-9904-78ea6cebe84a", new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(695), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEBm2WsuNQM4zbeafVoQusB9g0b4/ChQ4DV3xbRzubP8nPE3cR6PqlZgfLFK899kqiA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(703), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, "f8f4c253-ca57-4ccf-a126-a9b46d0d31f3", new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5258), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5260), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPgfvWtKlK5r31eD5TyMG50bWVgnp75Ci7BYRMx6u9YqCIc0SImFZWHb7HMZKKfE7Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5259), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, "75c4bfd1-326a-498d-a334-f17af9692be8", new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4507), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4510), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGPV29Iz2KHAMjTwwjLRoVQNhhx+z/lsh/t+p9/5EmOvlDlQxZwTMZbctzBYnPBhdQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4509), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, "79d26c97-3392-4b0d-b2fb-73a9c6d55a28", new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9324), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9326), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEMpmwBgBX9N+QOIqka1ib9C8NO+1kikmEOdLYKLd2Y69balecbGgF3IlXXzg4PWfeA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9325), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, "66624191-e944-4034-880f-2b92b7594465", new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4313), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4316), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEKcpSgJxbfXuY5pTm+A3zwPb4aCQjDzS+oEUm/qYbqeE0mTiphbm0b1zNEJ3k5Wqfg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4314), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, "69acbac8-1e3e-40a9-a9cf-b643feb7b362", new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9399), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9402), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPK0G4iUswy6I+JgllhPEOL6zrcP72hHdr+v04iStLgP2euf0Ib/P5rz4a1s5BuxUw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, "9f8dd629-80ee-4e07-94f6-87f2985bbb00", new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4298), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4301), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAENcyzmgoUMA4D8ZfTpbFGHskq/37bAxpGy9/5i82LWnGeTZGpLQOpcRX2EhSZPwDRg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4300), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, "7769696c-6d01-4f6a-99f1-17597e5ad2ab", new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9019), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9028), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPkd5EWNTYKakpGl+oqqr10+YA7DSJQaLAt3q8UN8mR4/scttH+r570FtMEANa8QCw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9026), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, "ce10b102-2843-489a-84c3-54093ab06426", new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(407), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(800), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEzq5OhJg/nte0b9YoU2vH+en6WoyFVWZFDLxqxe2P2YiXK4O7+bP75tmwxo6IRuGg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(583), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, "76553eec-6dba-45e1-915e-43e81bd3ecc8", new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9889), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9891), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAED3+M1Sk1q0NUDzYxvaCWrnmqBXJdfojoxq70bpKFTgq8x9jo+nD2UK7loMdfkJCIg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9890), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, "1a8a582d-dc66-4706-b951-27c0262545ca", new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3765), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGhLoPX4XNpfeA/7FfYPZO/YY6QeDxyQmuUommt7YeVvhpkIYlemfxoPC85TBEsumw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, "70bf091a-bc7d-4a92-8cab-83c9a7837ae0", new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(77), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(79), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELuMwDMiwIsoqP3xW6MIM7K+0lUrODLuwyUhnCMQF3jBUeo8Ok0GWuZPaviqLB+53g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(78), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, "d5b00d3b-0e33-4a2a-9037-ba7bacb85c2f", new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8061), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8063), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECDRy8DgaBbxFWr8NAaR4LmWZQo6sd1uyI/UQETsfEad7ySK0A2RRSBx13bXJDHbnQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8062), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, "c61c9b28-a37e-41a6-b708-a3b2ac0af36f", new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2280), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2281), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECsa9S5lCmIaddnbmJmPMoUZ//7D2Juvrs856qAuxlx12P/sHzwASHO+tVKSSj0pQw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2281), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, "541a5bc5-8aac-4640-9360-963e684cfbb3", new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4403), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEA1c+/xsGVFruGAGNN65l/5NgGg2352DgsAvzAXqC5SrqeMylk/qM52Wu9P8jUzyDA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4402), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, "d3d700ac-91f1-4d1d-a323-b08d8b00276e", new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8502), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8503), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPC/V/pFSM70ErvbqDqfNcoHkxIzMJmbD/98aJDwEIyABn0oMDbVVF0DBpICXhLnmQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8502), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, "5a1aeaa4-ea6a-44bc-9ccf-b877eb6101c8", new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(556), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEKb/5Q+HQxxH6WVqjXnuwWlMoOPgP9VWL+ae3Eid1UuIC0QAPOHEqxoqWS+cadl8GQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, "749850fd-0853-48d6-933d-9ece2a6a9a9c", new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2635), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2637), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEUlssY8BILHMe943YTaZ9CXRZTzs0sbYaVbGkVsJKBrdRrXZjoi/qDI0TzaZxkOUQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2636), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, "edd680d3-732f-4b76-bb72-3cdfdf6719ee", new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4811), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4813), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEDcGmZrte0t5Dai+jnMFqu48yHQSPvpgODDHyVe2O4Rs3eS7MqoZi6C/kbqP3Nr2HA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4813), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, "3f2b3278-227f-4a01-b291-e6e4949a3e59", new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9315), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9330), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEB3Sqrao7cXa4mP+CNDEHp/nlc4iqMEnhL6UP38fKQzcW9e9Jy5tPCxmOfbGKv1Fag==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9326), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, "6ee18aa5-3c62-4a19-aef6-54bd1e8d3c28", new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8611), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8614), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEH9F2O8ancn712C5j4mEj9oPUsAkmEcrlh3sDNrbQ+7vis0+lKdZ6pjrHKmCwwzALQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8613), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, "d2695068-e9ef-4bb2-b23d-a542095752f4", new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(664), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(665), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGXvAhDEXSD6WdouFxzPs/YQAuhYpRWrTrOWJpK2vTrFb/UsT/ae/5Vn+Y/FH4MgyA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(665), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, "432dd7db-b8ff-4dfe-981e-62bcbeaa3746", new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2754), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2756), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEH5/cUZhg9rsXQRwImlvleysHoXvltxNxx3/zsSzZ2hI5qRUa1VdmMuXALMpzjP7wA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2755), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, "52aabfda-e2dc-4391-aeb0-3a45178c1602", new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4851), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4853), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEFavLa6KRTQ1o9Q/XdgtpU14pHaTqaGXA1BchUJ2MikNmMB+IB2t35+1Y3FqHr7qlg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4852), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, "41316c81-d24e-42b6-a8fa-7975aac7f5d6", new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(6972), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(6974), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEDEy7CijxTO1e9j6zKf2dErE+mNI0gzGVenyvZECfGOup1KvFPbxUO3dXl4UuhW0Pw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(6973), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, "82496c40-6c8d-436d-ae03-530664b98390", new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9143), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9145), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELA0oGKg22Ie/rQzbZM9J7pa5udU7M3h+5/P7l/OaQN6Y/DClF2l0hExRWQvB6r9PA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9144), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, "e13a520d-0f5b-4cf2-91d4-7ab9b6636f24", new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5872), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5874), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEISKxbkIvkJw7IG8/P4XklRDOU8FWLCpi681Gc+RgD2jBxxeANFNKGt6wEdb7YvbGA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5873), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, "a2d280e8-80e5-47cc-88fd-dbad8b3e8a6a", new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6438), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6439), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPyPP7cs/KK7hIA4Gr9J+v8Kxnpd0J+U6U3/AOK9hu5pYrX+qjHQyTDGnd3s/o4WEg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6438), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9202), new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9201), new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 41, DateTimeKind.Utc).AddTicks(9203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650") },
                    { 30, new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(7005), new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(7004), new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(7006), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 40, DateTimeKind.Utc).AddTicks(7006), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649") },
                    { 1, new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(3067), new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(2527), new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(3549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 1, DateTimeKind.Utc).AddTicks(3332), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620") },
                    { 2, new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9252), new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9249), new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9255), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 2, DateTimeKind.Utc).AddTicks(9253), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621") },
                    { 3, new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4353), new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4352), new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4355), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 4, DateTimeKind.Utc).AddTicks(4354), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622") },
                    { 4, new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9451), new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9450), new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9453), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 5, DateTimeKind.Utc).AddTicks(9452), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623") },
                    { 5, new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4403), new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4402), new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4405), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 7, DateTimeKind.Utc).AddTicks(4404), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624") },
                    { 6, new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9366), new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9365), new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9368), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 8, DateTimeKind.Utc).AddTicks(9367), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625") },
                    { 7, new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4556), new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4555), new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4559), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 10, DateTimeKind.Utc).AddTicks(4557), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626") },
                    { 9, new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5304), new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5303), new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5306), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 13, DateTimeKind.Utc).AddTicks(5305), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628") },
                    { 10, new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(1050), new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(1047), new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(1052), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 15, DateTimeKind.Utc).AddTicks(1051), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629") },
                    { 11, new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3730), new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3729), new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 16, DateTimeKind.Utc).AddTicks(3730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630") },
                    { 12, new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6201), new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6200), new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 17, DateTimeKind.Utc).AddTicks(6202), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631") },
                    { 13, new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(1114), new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(1109), new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(1119), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 19, DateTimeKind.Utc).AddTicks(1116), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632") },
                    { 14, new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3823), new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3822), new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3825), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 20, DateTimeKind.Utc).AddTicks(3824), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633") },
                    { 8, new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9933), new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9932), new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9935), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 11, DateTimeKind.Utc).AddTicks(9934), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627") },
                    { 16, new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8094), new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8093), new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8096), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 22, DateTimeKind.Utc).AddTicks(8095), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635") },
                    { 15, new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5908), new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5907), new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5909), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 21, DateTimeKind.Utc).AddTicks(5908), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634") },
                    { 28, new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2788), new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2787), new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2790), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 38, DateTimeKind.Utc).AddTicks(2789), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647") },
                    { 27, new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(698), new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(697), new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(700), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 37, DateTimeKind.Utc).AddTicks(699), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646") },
                    { 26, new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8666), new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8664), new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8667), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 35, DateTimeKind.Utc).AddTicks(8666), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645") },
                    { 24, new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4846), new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4845), new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4848), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 32, DateTimeKind.Utc).AddTicks(4847), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643") },
                    { 23, new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2668), new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2668), new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2670), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 31, DateTimeKind.Utc).AddTicks(2669), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642") },
                    { 25, new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9702), new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9696), new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9708), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 33, DateTimeKind.Utc).AddTicks(9705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644") },
                    { 29, new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4887), new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4886), new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 39, DateTimeKind.Utc).AddTicks(4888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648") },
                    { 21, new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8537), new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8536), new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8539), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 28, DateTimeKind.Utc).AddTicks(8538), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640") },
                    { 20, new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6479), new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6477), new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6480), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 27, DateTimeKind.Utc).AddTicks(6479), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639") },
                    { 19, new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4436), new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4435), new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4437), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 26, DateTimeKind.Utc).AddTicks(4436), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638") },
                    { 18, new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2315), new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2314), new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2317), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 25, DateTimeKind.Utc).AddTicks(2316), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637") },
                    { 17, new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(120), new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(119), new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(122), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 24, DateTimeKind.Utc).AddTicks(121), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636") },
                    { 22, new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(590), new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(589), new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(591), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, 100m, new DateTime(2022, 6, 1, 6, 34, 21, 30, DateTimeKind.Utc).AddTicks(590), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641") }
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
                    { 1, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(4265), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(4633), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), 1, "testService@gmail.com1", 1m, "testProcedure1", 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(4443), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1") },
                    { 2, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5712), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5718), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), 2, "testService@gmail.com2", 2m, "testProcedure2", 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5716), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2") },
                    { 3, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5782), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5784), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), 3, "testService@gmail.com3", 3m, "testProcedure3", 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5783), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3") },
                    { 4, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5812), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5814), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), 4, "testService@gmail.com4", 4m, "testProcedure4", 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5813), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4") },
                    { 5, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5839), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5842), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), 5, "testService@gmail.com5", 5m, "testProcedure5", 0, new DateTime(2022, 6, 1, 13, 34, 20, 995, DateTimeKind.Local).AddTicks(5841), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 11, 4, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6788), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6787), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 34, 12, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7446), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7448), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7447), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 35, 12, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7471), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7473), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7472), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 36, 12, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7496), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7498), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7497), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 37, 13, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7522), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7523), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7522), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 38, 13, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7547), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7548), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7547), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 39, 13, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7572), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7573), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7572), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 40, 14, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 33, 11, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7394), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7395), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7394), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 41, 14, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7622), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7623), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7622), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 43, 15, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 44, 15, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7722), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7724), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7723), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 45, 15, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7747), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7749), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7748), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 46, 16, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7773), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7774), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7773), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 47, 16, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7798), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7800), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7799), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 48, 16, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7823), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7825), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7824), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 49, 17, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7848), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7850), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7849), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 42, 14, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7671), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7672), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7672), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 32, 11, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7368), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7370), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7369), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 31, 11, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7343), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7345), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7344), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 30, 10, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7318), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7319), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 13, 5, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6837), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6838), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6838), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 14, 5, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6862), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6864), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6863), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 15, 5, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6889), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 16, 6, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6913), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 17, 6, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6963), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6965), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6964), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 18, 6, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6989), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6991), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6990), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 19, 7, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7015), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7017), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7016), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 20, 7, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7042), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 21, 7, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7068), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7067), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 22, 8, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7091), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7093), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7092), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 23, 8, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7116), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7118), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7117), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 24, 8, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7141), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7143), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7142), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 25, 9, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7191), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7192), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7192), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 26, 9, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7217), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7218), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7218), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 27, 9, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7242), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7244), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7243), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 28, 10, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7268), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7269), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7268), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 29, 10, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7293), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7295), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7294), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 50, 17, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7873), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7875), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7874), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 51, 17, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7926), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7927), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7927), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 52, 18, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7951), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 53, 18, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7976), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(7977), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 75, 25, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8600), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 76, 26, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8654), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8655), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8654), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 77, 26, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8681), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 78, 26, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 79, 27, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8732), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 80, 27, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8756), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8757), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8757), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 81, 27, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8781), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8782), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8781), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 82, 28, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8806), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8807), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8806), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 83, 28, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8831), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8832), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8832), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 84, 28, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8857), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 85, 29, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8902), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8904), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8903), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 86, 29, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8927), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8929), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8928), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 87, 29, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8954), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 88, 30, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8979), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 89, 30, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9003), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9004), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9004), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 90, 30, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9028), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9030), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9029), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 91, 31, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9053), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9055), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9054), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 74, 25, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8573), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8575), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8574), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 12, 4, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6811), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6813), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6812), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 73, 25, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8548), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 71, 24, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8499), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8500), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8499), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 54, 18, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8001), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8002), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8002), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 55, 19, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8026), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8028), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8027), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 56, 19, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8051), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8053), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8052), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 57, 19, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8076), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8078), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8077), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 58, 20, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8101), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8103), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8102), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 59, 20, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8126), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8128), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8127), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 60, 20, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8198), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8200), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8199), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 61, 21, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8224), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8225), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8224), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 62, 21, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8249), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8251), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8250), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 63, 21, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8274), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8276), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8275), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 64, 22, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8299), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8301), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8300), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 65, 22, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8324), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8326), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8325), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 66, 22, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8351), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8352), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8352), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 67, 23, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8397), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8399), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8398), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 68, 23, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8423), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8425), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8424), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 69, 23, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8448), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8450), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8449), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 70, 24, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8474), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8475), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8475), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 72, 24, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8524), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8525), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(8524), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 92, 31, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9078), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9080), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9079), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 93, 31, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9103), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9104), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9103), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 9, 3, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6734), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6735), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6734), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 8, 3, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6709), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6708), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 7, 3, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6616), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6617), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6617), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 6, 2, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6590), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6591), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6591), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 5, 2, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6560), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6561), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6560), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 4, 2, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6534), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6535), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6534), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 3, 1, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6507), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6509), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6508), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 2, 1, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6474), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6477), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6476), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 1, 1, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(5030), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(5424), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(5205), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 10, 4, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6760), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6762), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(6761), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") }
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
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, "04bc6a35-fb35-41e6-8a08-1ed3b192524f", new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6025), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6028), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEB45iEtUbPP49XjXaCCZ2VDj5s6uxrqWkrkRD9OuyJXxSS39ePt+Yq4IZwS5sQphdA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6027), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, "4c2c9641-0eb1-4434-939d-6ea9a3868923", new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4864), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4868), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEEwywAmNlgELLdj1N10mlelwy7h1neiDzhC+d+fyEK21/MFFLiz9Sa0QbmHlJ65NsA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4867), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, "0a26d862-ade2-4967-ad9e-fef91d6332cc", new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7143), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7145), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEMvOWKHhl9SGJtUIusyZ4DqLoTq9hZ2uoAb6hWehkjdafn2bps09kwfRgApJ9L3l3A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7144), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, "9052b84b-8b8d-45fe-ac38-fc089bb764d0", new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9231), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEOTzeTaa7dzpvvtrhFtVgvjJ4Rixt0NAFaa1fxlWwBbTVu5tN0E2THf/xHzrdIXuDQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, "2365e410-b494-401b-bfcc-e52b89c8d4b6", new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4288), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4301), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKj3CPUwFJwoZCYowzornmgZ67qGVA/qIRJeackWSRpBMBNQq8LPciAiNjLknumsLg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4298), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, "ff5f4e85-2ef2-4b94-b61a-2be9c60093ef", new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9696), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHEomOTOqAzRIMBFSKMOXefy520eHED3SH/G5uuPqj5nB19SIk/FeUsT6/PLElRYbQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, "17dd6c77-2414-4218-b887-bf58e6a6932f", new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4502), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKa5Op6OdjFPE+R1pRKt2u4nr8N4xtCH0SxUKQ7ajAhg2GdlHf3osOchrIRtZTMgMw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4504), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, "43f4e54c-6455-4db9-838e-0063640485b4", new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(883), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(891), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEPu3M/Ks38S/4oWPX1wdD7FXtgUs3NE/E4Gh9TufR8bmIBAUA/wUJr6kcywyKcGvDA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(889), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, "387a4186-237b-43d9-b74d-e57862da1b3d", new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(900), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(902), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHe+oyYBhmEq3pBJrQhp8GcloFEql8Lho/V1fUVixHmfADsGQF5qh0QohN/mopTnUA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(901), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, "992ac935-4c2d-48b0-b98d-062d70558ebb", new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(660), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(662), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 66, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAENQmIqMQpl5Tj5IXyQs/5RW7at6bhLyIFKqgA7Ncr88sDQ8lvB2jqe2VBCd8szjzEA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(661), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, "bc7669b9-d8fb-4a4f-b67b-4f7d24ecc203", new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1035), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1038), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 62, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEFuN69WSjxCGHGwqzQxpuSTwwOCwNZ11vzGTnbMANU5L8s/OsM8CwgLi/rWtr/UODQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1037), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, "93875373-746c-4183-944d-df89199bc671", new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6040), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6043), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 63, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAELXdkL3wcsXNpgFvS/L6FpS62Z/p5R8/NwO4X5m0nEJLIUtAT5MOr4p6bm+YNHNn/Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, "a78b0dbb-7a3c-4c75-83d0-0d8fd07c17d2", new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(908), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(910), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 64, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEAyelNmE8gKaFQR8h6XvolWjb9ByXhPR78+NetfGCk7OJOrec5xpFhfvjbzjKgTsNg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(909), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, "c2d950b6-2d94-449c-9f25-e703bf290670", new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5806), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5809), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 65, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEJQAbgMBlBMqgeQga2/IV/7HdmGzwEQtSvLNfc0NK1d+cwoF+5/Xf8LFiOFQHTf5DA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5807), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, "6c86bfaa-71ee-47ce-b8e3-78b9222dbf9a", new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5805), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5808), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 67, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEJ+NVwd51zlMSc0CIDtjaTAa8tkY1UuCPzFGiAhTaqyxILKg6olYPwu5E9lkz18yEQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5807), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, "1bee8d1f-32b9-4c5c-9405-36de69db5e0a", new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(639), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(642), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 68, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEEpD/u4Sf3MhVnHWDN/UNg0bj1WEhDWarebwSJJj4B7rSOqRMpUJ48fU50fpE5LuSA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(641), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, "4924e197-1aa7-4e54-8e1b-035cb03b72ed", new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8667), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8673), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 69, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEAP/RpWmrP0tGUHMawNw3dj9fhU0LPYZUfgKsy75TCYWD2q8+ThkQICDvnVQI/e+aQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8672), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, "b417ce12-f5ef-4af1-b70d-640f68651a88", new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(576), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(578), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 70, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEDZ+afcKu7ndNIeaucugxyPrS6edB/NPHexJaYTkoFnQFVTwqNix06n2lVAMPcTsow==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(577), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, "717d6247-a1b8-40f9-a8a5-1ab7cafee161", new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2449), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2451), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 71, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAELMbMAEikNPsFjkTWTpFSKlt46ofIwV4/FOMe+/cU9+66lK/LadrqACs/FWAcOdoEA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2450), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, "42538993-1512-4247-b077-b24ad9f40f37", new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5879), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5882), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 61, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEJoijYjRP5B/cw2LfoCZfZyOCyXNqtlk1pwYyzG0MZCbZcUrCxVjbNCqnHQCdH30Gg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5881), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, "f59b8bc2-13b4-4b10-a2fd-52be50a0fb32", new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(1470), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(1472), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEISbwFhXEfeEkosJYBiRcDV+MGvBg9egLtoDbATkhVOhkGM//qBwesNxW4yNc62n2g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(1471), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 32, new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(2615), new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(2612), new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(2617), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 43, DateTimeKind.Utc).AddTicks(2616), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 50, new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8822), new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8820), new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8825), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 69, DateTimeKind.Utc).AddTicks(8823), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369") },
                    { 49, new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(685), new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(684), new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(688), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 68, DateTimeKind.Utc).AddTicks(687), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368") },
                    { 48, new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5862), new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5861), new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5864), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 66, DateTimeKind.Utc).AddTicks(5863), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367") },
                    { 47, new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(707), new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(706), new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(710), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 65, DateTimeKind.Utc).AddTicks(709), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366") },
                    { 46, new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5852), new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5851), new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5854), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 63, DateTimeKind.Utc).AddTicks(5853), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365") },
                    { 45, new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(953), new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(951), new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(955), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 62, DateTimeKind.Utc).AddTicks(954), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364") },
                    { 44, new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6142), new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6140), new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6144), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 60, DateTimeKind.Utc).AddTicks(6142), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363") },
                    { 43, new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1109), new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1108), new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1111), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 59, DateTimeKind.Utc).AddTicks(1110), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362") },
                    { 51, new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(606), new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(605), new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(608), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 71, DateTimeKind.Utc).AddTicks(607), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370") },
                    { 42, new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5927), new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5925), new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5929), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 57, DateTimeKind.Utc).AddTicks(5928), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361") },
                    { 40, new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6078), new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6077), new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6081), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 54, DateTimeKind.Utc).AddTicks(6079), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 39, new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(1080), new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(1078), new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(1083), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 53, DateTimeKind.Utc).AddTicks(1081), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 38, new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4558), new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4557), new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4560), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 51, DateTimeKind.Utc).AddTicks(4559), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 37, new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9744), new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9743), new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9747), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 49, DateTimeKind.Utc).AddTicks(9745), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 36, new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4778), new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4775), new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4781), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 48, DateTimeKind.Utc).AddTicks(4780), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 35, new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9265), new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9264), new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9266), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 46, DateTimeKind.Utc).AddTicks(9266), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 34, new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7179), new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7178), new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7181), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 45, DateTimeKind.Utc).AddTicks(7180), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 33, new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4983), new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4981), new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4985), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 44, DateTimeKind.Utc).AddTicks(4984), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 41, new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(948), new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(945), new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(950), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 56, DateTimeKind.Utc).AddTicks(949), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 52, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2524), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2523), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2526), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, 200m, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(2525), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 94, 32, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9150), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9152), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9151), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 126, 42, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(38), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(40), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(39), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 127, 43, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(63), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(65), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(64), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 128, 43, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(88), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(90), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(89), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 129, 43, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(137), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(138), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(137), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 130, 44, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(164), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(165), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(164), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 131, 44, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(189), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(190), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(190), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 132, 44, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(214), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(216), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(215), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 133, 45, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(241), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 134, 45, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(265), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(266), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(265), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 135, 45, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(289), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(291), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 136, 46, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(342), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(343), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(343), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 137, 46, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(367), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(369), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(368), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 125, 42, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(13), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(15), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(14), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 138, 46, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(392), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(394), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(393), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 140, 47, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(442), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(444), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(443), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 141, 47, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(467), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(469), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(468), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 142, 48, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(492), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(493), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(493), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 143, 48, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(517), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(518), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(517), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 144, 48, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(571), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(571), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 145, 49, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(596), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(596), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 146, 49, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(621), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(622), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(621), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 147, 49, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(648), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(647), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 148, 50, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(671), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(673), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(672), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 149, 50, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(697), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 150, 50, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(721), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(723), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(722), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 151, 51, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(746), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(748), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(747), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 139, 47, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(417), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(418), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(418), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 124, 42, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9988), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9989), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9989), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 123, 41, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9962), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9964), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9963), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 122, 41, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9937), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9939), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9938), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 95, 32, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9176), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9177), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9176), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 96, 32, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9201), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9202), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 97, 33, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9227), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9228), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9227), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 98, 33, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9252), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9254), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9253), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 99, 33, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9277), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9278), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9278), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 100, 34, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9302), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9303), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9303), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 101, 34, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9327), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9328), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9327), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 102, 34, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9352), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9353), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9352), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 103, 35, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9404), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9405), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9404), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 104, 35, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9429), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9430), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9430), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 105, 35, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9454), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9456), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9455), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 106, 36, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9480), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9481), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9480), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 107, 36, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9506), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 108, 36, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9530), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9531), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9530), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 109, 37, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9554), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9556), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9555), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 110, 37, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9579), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9581), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9580), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 111, 37, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9626), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9627), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9627), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 112, 38, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9651), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9653), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9652), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 113, 38, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9677), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9678), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9678), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 114, 38, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9702), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9703), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9702), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 115, 39, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9727), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9729), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9728), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 116, 39, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9753), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9754), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9753), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 117, 39, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9778), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 118, 40, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9803), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9805), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9804), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 119, 40, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9828), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9829), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9829), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 120, 40, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9886), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9887), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 121, 41, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9912), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 72, DateTimeKind.Utc).AddTicks(9913), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 152, 51, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(771), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(773), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(772), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 153, 51, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(822), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(824), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 1, 6, 34, 21, 73, DateTimeKind.Utc).AddTicks(823), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") }
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
