using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistBooking.Data.Migrations
{
    public partial class v1 : Migration
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
                    DiscountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { 1, "TestAddress1", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(3078), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(3468), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", "TestClinic1", 868644651, 0, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(3262), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51") },
                    { 2, "TestAddress2", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(4354), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(4360), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", "TestClinic2", 868644651, 0, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(4359), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52") },
                    { 3, "TestAddress3", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7211), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7216), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", "TestClinic3", 868644651, 0, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7215), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53") },
                    { 4, "TestAddress4", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7241), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7243), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", "TestClinic4", 868644651, 0, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7242), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54") },
                    { 5, "TestAddress5", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7276), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7279), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", "TestClinic5", 868644651, 0, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(7278), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55") }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "ApplyForAll", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "Description", "EndDate", "Percent", "StartDate", "Title", "Updated_at", "Updated_by", "status" },
                values: new object[,]
                {
                    { 1, 10m, true, new DateTime(2022, 7, 17, 15, 32, 56, 480, DateTimeKind.Local).AddTicks(2334), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 7, 17, 15, 32, 56, 480, DateTimeKind.Local).AddTicks(2937), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", new DateTime(2022, 7, 17, 15, 32, 56, 480, DateTimeKind.Local).AddTicks(757), 5f, new DateTime(2022, 7, 17, 15, 32, 56, 479, DateTimeKind.Local).AddTicks(5552), "TestTitle1", new DateTime(2022, 7, 17, 15, 32, 56, 480, DateTimeKind.Local).AddTicks(2544), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), 0 },
                    { 2, 10m, true, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1730), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1732), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1726), 5f, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1719), "TestTitle2", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1731), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), 0 },
                    { 3, 10m, true, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1824), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1826), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1823), 5f, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1821), "TestTitle3", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1825), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), 0 },
                    { 4, 10m, true, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1861), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1862), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1859), 5f, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1858), "TestTitle4", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1861), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), 0 },
                    { 5, 10m, true, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1889), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1891), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1887), 5f, new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1886), "TestTitle5", new DateTime(2022, 7, 17, 15, 32, 56, 481, DateTimeKind.Local).AddTicks(1890), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), "f5a86499-8082-466f-8b05-5f948ea9cc6d", "Admin", "Admin", "ADMIN" },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), "cfb401cb-521c-43c5-b0c5-85201b387b6d", "User", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DiscountId", "Name", "Price", "Procedure", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3180), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3182), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), null, "testService@gmail.com5", 5m, "testProcedure5", 0, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3181), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5") },
                    { 4, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3154), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3156), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), null, "testService@gmail.com4", 4m, "testProcedure4", 0, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3155), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4") },
                    { 1, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(1862), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(2240), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), null, "testService@gmail.com1", 1m, "testProcedure1", 0, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(2054), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1") },
                    { 2, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3092), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3097), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), null, "testService@gmail.com2", 2m, "testProcedure2", 0, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3096), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2") },
                    { 3, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3127), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3129), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), null, "testService@gmail.com3", 3m, "testProcedure3", 0, new DateTime(2022, 7, 17, 15, 32, 56, 482, DateTimeKind.Local).AddTicks(3128), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3") }
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
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371") },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624") },
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
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, "0de9df6b-00fd-49ce-89fb-6ca86ac73060", new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7521), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7523), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEHb7N2lhUwnshFWOB7SRGBgZVANXKB4Mp/LtIRp/qnlTlzHPYsQSv2haUjXAD+p4Pw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7522), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, "25e8c10e-708e-4026-8aa4-91cb5cdfe8ef", new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6049), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6050), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEHKc6J94tW0cMh1BE6cVh5x2bsQhwPCKQHxoF458sM05QisDXCcBuJ39fARcudVekA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6050), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, "fb1a314c-40cd-4305-b8fe-97f18e2981ed", new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4200), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4201), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEwDbbwK5Cd+Pw+2YAmO29TL795svnh74hHtvJXUQvjQzSa4mQCzwCs0/tYGukQsEg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4200), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, "c99e0c70-9455-4d29-aab7-100762359b0f", new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2291), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPtiAX49huLBGko3OwyOMTNk7iH8ZeE7+rMI0Yfkhop+OsZP8iYb9C6dEYX/2P2mwQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, "a64e3043-111c-414e-a69e-15d07c19df72", new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(464), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(465), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEL9sofQE53LZ4fjAnKtzY7ZQyCco4RhttJ+sy+Xp0xMnOmN97Qv547r2dlISQfIG3A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(465), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, "d7d1db2d-3ad8-47f4-b8dd-8263b9c8ea21", new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7380), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7382), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEL4lv+p4jDTWnH5Y8dOP9tqMzps1psG6+3uyJacIFzqMe0IA8iW5oVT7p7l55LPE/A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7381), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, "644091db-184e-41c9-a6c1-3bae4e17bec5", new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5702), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5704), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEH1ih9mZ/Aw9aZKQg3+n3TFTuScbBnbGa+cCZeUcsuGbFP/7qNn9eBZCcYpzZ4DQKQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5703), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, "66b2aaa4-8542-4315-bdfc-dad06cdc6783", new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3759), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3760), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEJ+XmKrRNrl3SmW7nP8w/zXhrlAfhd0oMLGs0NDc7jjJpyD+nr7KuIIiqdmg3YYXFQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3760), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, "71d6998e-0a47-4e22-8750-9953f82110e9", new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1855), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEFGSUwfbzacFn3xF/zQFyTrOIGOgdvx3v6A6GIOTx8gJkXfOYaHrLvoYPRniewNSHg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1855), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, "fc980223-e67f-4a90-a672-90d880ddcee8", new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9955), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9956), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELfpWU21qCCX9mBMAfXmIwANBIAqGZmOfm2UX6GqRbyw98TGHlSJDI5Wxr/oMKjhLQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9956), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, "c3d3d55f-2121-459e-8ef3-14facde158f4", new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8317), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEF9P0OO7lo7HbOW2GCN2EyRdUIFDJ/W10VLYRhKotkds8yUP9334MwuecYKsuh9IzQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8319), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, "7b415859-7718-41b7-a22e-eea14f2b7109", new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(1789), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(2167), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAENO4TIdPpEkopjmIDFXqNjbbcSBopT9QNiybSdVInYyNbnlSussFyfA/HgkqF2HyJg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(1960), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, "27af0373-8b2e-4adc-8e22-ce801c582d98", new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9131), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9133), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEkyX2Xy+Zxqil5ZDSCoQO6DOajT7ZvwwEx5p2XEXVG9wSu0kN0TmRD8xegCFGA4Nw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9132), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, "5437563c-fdd7-4130-99f5-536ff2044a30", new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9628), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9632), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELAsRFmAm77hSCerTircEPq8ZUY9mT7GDTwNsVOyeeUoSazq0YslGf8JGyK9HNPL0g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9631), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, "5b490079-469f-4309-9e07-46f27e3faee0", new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5091), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELMBkZhLDBROC95z07eBZRGHZplBbBgQrQtYVkyNEom9Gv+FZvwQumDiUN+g1x/JcQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5090), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, "af19aac9-272e-4d5a-9bdd-e728b49ae829", new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3319), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3325), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECewvmFm5PHMANM0mtrQHDDFh6OkHC289dSJ1kfQldGAFmuzmdBdsuqGlF+icJqlcw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3324), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, "cf244d16-3e56-4db3-9bb2-3cee9a8a8ad8", new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6869), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEIG/XraaYwNwD1GYZR1minwg62tzINskSrKEfnssS4XycJi2iYJEJi2BnuG4M6tmzg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, "a2d3ad1d-74bd-4ea8-af16-cb675ea469ff", new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8447), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8448), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEOqg78gTW+/ZBi8kHGQs8qy/Uaz6vYgcLjLBSyWNvPysGajcUIEtt4jap3EjgOKheA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8448), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, "28a541b6-9aa0-4d20-8529-61526ee0bc62", new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1520), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1522), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEXpYNce3GikG3J8Zks80q2Uh5bPFt1NuMVzJzKr6/XIWmtLQV63gumz7ii5hCM5TQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1521), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, "d5fb193b-2c59-48fc-aabb-e0c0df7462f5", new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3292), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3294), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEMdS9SHVTfbd47GhSaAS6L+zyk5tCcKRXmB3s9p3Jbl8c6wEVnXwzUm38QWxtwGp4w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3293), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, "5070dca8-6c86-4435-b198-a46c355dbd05", new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4883), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4885), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEhWTiMVl+x6HueMYjAuGj6lXGC9S76myHhY97Fdd6I3A+RWCimmpAz7Gl4zkxmt/A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4884), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, "bf1c11ac-d25e-4ccc-b0e5-9f853972bb45", new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6504), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6506), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEOcRa3F09kQRCAbBZwrU+ZP97ITLq42qIS3j8MO0Rzlj9W5n1Do77btdHUWzHiXGSA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, "cef32ecd-f1ab-4ba0-b66c-c0db0c93f630", new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8539), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8541), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELNhl4raPJwFnWHA/50v3wQHHghAvUrQtmGbkqWc2gEEybP5rcbzxXLoHqLbKgG/IA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8540), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, "29633b95-88ca-4d9e-a7b7-5ecee4c69b8b", new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(721), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(724), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEN2wcWAXQ9ZeBuei01Pa6kvzDttynU9P86xvY+zi4eIUtqk/8J/RfyiNBn2Hansx0Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(723), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, "b04283bd-d3a6-41b4-96c5-f3b5bc73de26", new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2439), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2444), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGJKFxQI83PVt/jSidguh2vzndDhP3j6ZZXAo517Tk1R+Vrc/MJOQU4BfyJdpYf0oA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2442), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, "93b97ead-33a6-480a-9045-309afd7712b9", new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4261), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4262), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEBjv6Z/Tno75eOhEg+FYAkuqdq6GHvqVoqLcmE8MKAC7tcf2L0aljNPepXuSnokQoQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4261), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, "b1dd872e-736c-4757-8037-646e90205801", new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5816), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5817), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEBL057UkPueQk5ClwXWZpyzqmThIs8KMX4OeRlcTSTN4dx8YiSvCGZnrzv3xXPfbiw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5816), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, "0eb64864-68f0-4a67-9654-c67c58646590", new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7515), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7517), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEErPYyXiOaRLvWoYWMXVwXzXV7P6RtER/qEqL7Skc6cTaz2aXUPQ0w3VRxSHlIncJA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7516), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, "4c2c1758-1259-49c3-ad7c-7194b93d5926", new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9186), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9188), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEH+OfX43aPdtLC4JLksovUNCbZ3q2PzyKE8sOYpgoVVf0OgUzo9rvIsprwOId1s7fg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9187), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, "fbd5c184-67fa-4dde-ab81-247d92ec9bf8", new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1220), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1222), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEK/q9KikH/Rto3sGXDL4syKgvifFKrFcMUhcKx1qKAqqrmVP63UWxV3Ok/mD3YPeWw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1221), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, "aa29194f-de86-441e-ba4e-5c73fff6507a", new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9880), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9882), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEOB/PYJLrHwr3MQfZYdSzbLEyq75jynExA4r2JV89qo6v2ZPaqahckdXzs1Ga9KMNw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9881), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9212), new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9211), new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9213), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 521, DateTimeKind.Utc).AddTicks(9213), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650") },
                    { 1, new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(4404), new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(3893), new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(4741), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 486, DateTimeKind.Utc).AddTicks(4562), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620") },
                    { 2, new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8360), new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8359), new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8362), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 487, DateTimeKind.Utc).AddTicks(8361), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621") },
                    { 3, new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9985), new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9984), new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9987), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 488, DateTimeKind.Utc).AddTicks(9986), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622") },
                    { 4, new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1882), new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1881), new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1884), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 490, DateTimeKind.Utc).AddTicks(1883), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623") },
                    { 5, new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3791), new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3790), new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3792), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 491, DateTimeKind.Utc).AddTicks(3791), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624") },
                    { 6, new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5753), new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5752), new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5755), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 492, DateTimeKind.Utc).AddTicks(5754), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625") },
                    { 7, new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7409), new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7408), new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7410), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 493, DateTimeKind.Utc).AddTicks(7409), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626") },
                    { 9, new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(492), new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(491), new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(494), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 496, DateTimeKind.Utc).AddTicks(493), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628") },
                    { 10, new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2330), new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2328), new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2331), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 497, DateTimeKind.Utc).AddTicks(2331), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629") },
                    { 11, new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4227), new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4226), new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4229), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 498, DateTimeKind.Utc).AddTicks(4228), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630") },
                    { 12, new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6080), new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6079), new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6081), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 499, DateTimeKind.Utc).AddTicks(6080), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631") },
                    { 13, new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7548), new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7547), new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 500, DateTimeKind.Utc).AddTicks(7549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632") },
                    { 14, new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9813), new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9811), new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9815), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 501, DateTimeKind.Utc).AddTicks(9814), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633") },
                    { 15, new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1253), new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1252), new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1254), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 503, DateTimeKind.Utc).AddTicks(1253), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634") },
                    { 8, new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9157), new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9156), new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9159), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 494, DateTimeKind.Utc).AddTicks(9158), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627") },
                    { 17, new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5151), new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5150), new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5153), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 505, DateTimeKind.Utc).AddTicks(5152), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636") },
                    { 16, new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3450), new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3447), new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3452), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 504, DateTimeKind.Utc).AddTicks(3451), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635") },
                    { 29, new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5842), new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5841), new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5843), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 519, DateTimeKind.Utc).AddTicks(5842), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648") },
                    { 28, new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4289), new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4288), new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4291), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 518, DateTimeKind.Utc).AddTicks(4290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647") },
                    { 27, new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2771), new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2770), new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2773), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 517, DateTimeKind.Utc).AddTicks(2772), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646") },
                    { 26, new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(767), new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(766), new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(769), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 516, DateTimeKind.Utc).AddTicks(768), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645") },
                    { 25, new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8569), new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8568), new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 514, DateTimeKind.Utc).AddTicks(8570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644") },
                    { 24, new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6530), new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6529), new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6532), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 513, DateTimeKind.Utc).AddTicks(6531), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643") },
                    { 30, new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7547), new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7546), new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 520, DateTimeKind.Utc).AddTicks(7548), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649") },
                    { 22, new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3319), new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3318), new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3321), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 511, DateTimeKind.Utc).AddTicks(3320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641") },
                    { 21, new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1546), new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1545), new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1547), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 510, DateTimeKind.Utc).AddTicks(1546), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640") },
                    { 20, new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9906), new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9905), new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9908), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 508, DateTimeKind.Utc).AddTicks(9907), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639") },
                    { 19, new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8509), new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8508), new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8511), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 507, DateTimeKind.Utc).AddTicks(8510), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638") },
                    { 18, new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6902), new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6901), new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6903), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 506, DateTimeKind.Utc).AddTicks(6902), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637") },
                    { 23, new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4910), new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4909), new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4912), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, 100m, new DateTime(2022, 7, 17, 8, 32, 56, 512, DateTimeKind.Utc).AddTicks(4911), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642") }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "Id", "ClinicId", "Description", "Position" },
                values: new object[,]
                {
                    { 57, 1, "TestDescirption57", 0 },
                    { 58, 1, "TestDescirption58", 0 },
                    { 59, 1, "TestDescirption59", 0 },
                    { 60, 1, "TestDescirption60", 0 },
                    { 61, 1, "TestDescirption61", 0 },
                    { 62, 1, "TestDescirption62", 0 },
                    { 63, 1, "TestDescirption63", 0 },
                    { 66, 1, "TestDescirption66", 0 },
                    { 65, 1, "TestDescirption65", 0 },
                    { 67, 1, "TestDescirption67", 0 },
                    { 68, 1, "TestDescirption68", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "Id", "ClinicId", "Description", "Position" },
                values: new object[,]
                {
                    { 69, 1, "TestDescirption69", 0 },
                    { 70, 1, "TestDescirption70", 0 },
                    { 64, 1, "TestDescirption64", 0 },
                    { 71, 1, "TestDescirption71", 0 },
                    { 56, 1, "TestDescirption56", 0 },
                    { 54, 1, "TestDescirption54", 0 },
                    { 29, 1, "TestDescirption29", 0 },
                    { 28, 1, "TestDescirption28", 0 },
                    { 27, 1, "TestDescirption27", 0 },
                    { 26, 1, "TestDescirption26", 0 },
                    { 25, 1, "TestDescirption25", 0 },
                    { 24, 1, "TestDescirption24", 0 },
                    { 23, 1, "TestDescirption23", 0 },
                    { 22, 1, "TestDescirption22", 0 },
                    { 21, 1, "TestDescirption21", 0 },
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
                    { 30, 1, "TestDescirption30", 0 },
                    { 31, 1, "TestDescirption31", 0 },
                    { 32, 1, "TestDescirption32", 0 },
                    { 33, 1, "TestDescirption33", 0 },
                    { 53, 1, "TestDescirption53", 0 },
                    { 52, 1, "TestDescirption52", 0 },
                    { 51, 1, "TestDescirption51", 0 },
                    { 50, 1, "TestDescirption50", 0 },
                    { 49, 1, "TestDescirption49", 0 },
                    { 48, 1, "TestDescirption48", 0 },
                    { 47, 1, "TestDescirption47", 0 },
                    { 46, 1, "TestDescirption46", 0 },
                    { 45, 1, "TestDescirption45", 0 },
                    { 55, 1, "TestDescirption55", 0 },
                    { 44, 1, "TestDescirption44", 0 },
                    { 42, 1, "TestDescirption42", 0 },
                    { 41, 1, "TestDescirption41", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "Id", "ClinicId", "Description", "Position" },
                values: new object[,]
                {
                    { 40, 1, "TestDescirption40", 0 },
                    { 39, 1, "TestDescirption39", 0 },
                    { 38, 1, "TestDescirption38", 0 },
                    { 37, 1, "TestDescirption37", 0 },
                    { 36, 1, "TestDescirption36", 0 },
                    { 35, 1, "TestDescirption35", 0 },
                    { 34, 1, "TestDescirption34", 0 },
                    { 43, 1, "TestDescirption43", 0 },
                    { 10, 1, "TestDescirption10", 0 }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 11, 4, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2884), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2885), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2885), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 34, 12, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3533), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3535), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3534), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 35, 12, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3558), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3560), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3559), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 36, 12, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3582), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3584), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3583), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 37, 13, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3663), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3665), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3664), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 38, 13, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3689), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3690), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3689), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 39, 13, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3713), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3715), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3714), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 40, 14, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3738), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3739), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3738), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 33, 11, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3508), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3510), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3509), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 41, 14, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3762), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 43, 15, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3810), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3812), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3811), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 44, 15, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3834), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3836), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3835), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 45, 15, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3858), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3860), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3859), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 46, 16, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3944), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3945), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3944), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 47, 16, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3969), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3970), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3970), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 48, 16, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3993), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3995), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3994), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 49, 17, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4018), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4019), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4019), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 42, 14, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3788), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3787), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 32, 11, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3484), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3485), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3484), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 31, 11, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3460), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3461), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3460), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 30, 10, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3435), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3437), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3436), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 13, 5, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2966), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2968), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2967), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 14, 5, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2991), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2992), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2992), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 15, 5, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3015), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3017), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3016), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 16, 6, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3040), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 17, 6, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3064), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3065), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 18, 6, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3091), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3090), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 19, 7, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3114), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3116), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3115), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 20, 7, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3164), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3165), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3164), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 21, 7, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3189), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3191), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3190), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 22, 8, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3214), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3215), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3214), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 23, 8, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3238), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3240), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3239), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 24, 8, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3262), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3264), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3263), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 25, 9, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3286), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3288), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3287), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 26, 9, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3310), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3312), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3311), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 27, 9, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3335), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3336), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3335), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 28, 10, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3359), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3360), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3360), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 29, 10, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3410), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3411), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(3411), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 50, 17, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4042), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4044), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4043), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 51, 17, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4068), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4067), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 52, 18, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4090), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4092), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4091), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 53, 18, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4114), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4116), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4115), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 75, 25, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5064), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5065), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 76, 26, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5088), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5090), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 77, 26, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5112), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5114), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5113), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 78, 26, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5136), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5138), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5137), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 79, 27, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5161), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5162), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5161), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 80, 27, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5211), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5213), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5212), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 81, 27, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5236), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5238), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5237), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 82, 28, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5260), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5262), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5261), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 83, 28, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5285), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5286), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5285), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 84, 28, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5309), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5310), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5310), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 85, 29, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5333), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5335), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5334), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 86, 29, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5357), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5359), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5358), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 87, 29, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5381), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5383), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5382), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 88, 30, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5405), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5407), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5406), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 89, 30, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5451), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5453), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5452), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 90, 30, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5476), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5477), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5476), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 91, 31, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5500), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5501), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5501), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 74, 25, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5040), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5041), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5040), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 12, 4, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2942), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2943), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2942), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 73, 25, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5015), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5017), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5016), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 71, 24, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4885), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4893), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4892), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 54, 18, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4138), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4140), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4139), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 55, 19, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4205), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4204), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 56, 19, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4228), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4230), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4229), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 57, 19, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4252), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4254), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4253), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 58, 20, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4277), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4278), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4277), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 59, 20, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4301), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4302), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4302), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 60, 20, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4325), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4327), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4326), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 61, 21, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4349), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4351), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4350), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 62, 21, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4373), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4375), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4374), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 63, 21, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4397), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4399), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4398), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 64, 22, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4466), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4467), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4466), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 65, 22, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4490), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4492), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4491), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 66, 22, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4516), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4517), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4516), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 67, 23, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4540), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4542), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4541), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 68, 23, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4564), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4566), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4565), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 69, 23, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4589), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4590), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4589), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 70, 24, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4613), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4615), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4614), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 72, 24, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4990), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4992), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(4991), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 92, 31, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5524), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5526), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5525), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 93, 31, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 9, 3, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2834), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2836), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2835), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 8, 3, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2810), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2811), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2810), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 7, 3, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2785), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 6, 2, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2760), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2762), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2761), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 5, 2, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 4, 2, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 3, 1, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2678), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2679), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 2, 1, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2601), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2600), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 1, 1, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(898), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(1330), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(1085), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 10, 4, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2859), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2861), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(2860), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") }
                });

            migrationBuilder.InsertData(
                table: "ServiceDentists",
                columns: new[] { "DentistId", "ServiceId" },
                values: new object[,]
                {
                    { 39, 2 },
                    { 40, 2 },
                    { 41, 3 },
                    { 42, 3 },
                    { 43, 3 },
                    { 44, 3 },
                    { 49, 3 },
                    { 46, 3 },
                    { 47, 3 },
                    { 48, 3 },
                    { 38, 2 },
                    { 50, 3 },
                    { 51, 4 },
                    { 45, 3 },
                    { 37, 2 },
                    { 33, 2 },
                    { 35, 2 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 36, 2 },
                    { 27, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 2 },
                    { 32, 2 },
                    { 52, 4 },
                    { 34, 2 },
                    { 28, 1 },
                    { 53, 4 }
                });

            migrationBuilder.InsertData(
                table: "ServiceDentists",
                columns: new[] { "DentistId", "ServiceId" },
                values: new object[,]
                {
                    { 20, 1 },
                    { 59, 4 },
                    { 64, 5 },
                    { 63, 5 },
                    { 54, 4 },
                    { 62, 5 },
                    { 67, 5 },
                    { 61, 5 },
                    { 60, 4 },
                    { 68, 5 },
                    { 66, 5 },
                    { 65, 5 },
                    { 58, 4 },
                    { 69, 5 },
                    { 57, 4 },
                    { 56, 4 },
                    { 70, 5 },
                    { 55, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, "62fad07b-4f73-42cf-a5fc-4c73145c8c66", new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(568), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(570), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 67, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKJ3dK3qNfEpCxYaoHGJOWysr4mY3L2i62Do45SZ2d0px64+1osAZgpHNNQaOTXp3A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(569), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, "3bf6db00-7479-423e-a024-2426acc0d295", new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4202), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4204), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 69, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEPQhi0x53Uc5KXnhV2bSElQ/GtIQRM4bXpgF9vnKhyNChsPf9IIA5QB2iz5FinEsDQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, "8255b647-f2d2-4709-9778-8687d592f071", new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6211), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6212), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 70, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEEBgNdy+4V+Amg3hMtU6mISIxot3iPPMWy06rxY4VeQd4uznQvpocd9XVKcd1SK55g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6211), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, "a9da3217-ba8f-4348-89cd-d9fe3b9b8a63", new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8686), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8687), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 66, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEJEl+dGajz+kc8c5EMnkrLMesKXQrDLmKHwIua/kmyuyvN7rQjnWUroEcOH93MCEMw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8687), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, "01b5c930-117f-4712-af76-755540806e43", new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7709), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7710), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 71, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEIR8xEfKOA1kCVKDsSnXyTZTAKb3sBiiNM55LxI2A7RkdcR91C6vh+I4rBnyv/e8KA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7710), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, "5e274675-6c78-4649-896f-bab2bb369675", new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2215), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2216), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 68, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEOt2ijcN02XRe0qPyglaBAf8exIYDq4rl1J/9qGPzl0YDdtUyI+dOPKWqlpEnpVxFA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2216), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, "8e37d92f-106d-4040-9dfd-353954980f36", new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5891), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5892), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEARtlNlYXjT8mCoBzYNKn4Z76390MQa7KOxicPLGfYMch+RqzEU03Qhs/yHya2gFYQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5892), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, "80d2bb9e-a492-48a0-8f12-fb4fb222710b", new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2666), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2668), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 62, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEMJpAaq2s7fW1AX5ia2pJZzK+KnjxsVWPU4k5JFRNYuqe8LtCMcQAAxYhdTyCX1G2g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2667), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, "ba5a6d19-0b3e-40e8-a5be-bd0dadbee5d1", new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5757), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5759), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 64, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAECAHBdRlYor+SF40HbToHk7RtgVJRbwnjomJgpyEzhpXTaFFJxxRSrNCXzU1RbiJtQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5758), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, "6502444a-f4e3-4f4e-8b3a-3bc85e1b1d00", new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4426), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4428), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 63, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAECpZnpkQtlu47EE+pCCVVuNXDdWrAazWh+Ox4ivX+5waR8skiaLKlvhjrRNH0YB85A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4427), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, "8cf59135-dc2f-4318-9604-971584407d39", new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1015), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1016), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 61, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAECYqYGujYuDA+Y142WUXUCqiVNEmlQ77dzNQr/tsqETKOyBYTVOx6gfx9r7fBD7Lug==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1016), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, "1df4b7d1-61c4-4ee4-a19f-55e76c8b79fd", new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9288), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9290), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHeVXflWYLXv3b/c/3XiFjCVT2NgdBSQGj7qtkuTCs4Bz2X+gmiWc3TiEqFP1dNRbw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9289), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, "5b18a2ea-ef98-4ca0-ba11-fc099a3361e5", new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7636), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7638), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEOeT2DILLRA02y0DIozidIUrWkgx7yZKuPejf3JlmvAiYOY2cGxfN/fbBe64XrZ36Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7637), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, "0c8ed7f2-0549-4f1c-ac5c-6097b274dc99", new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5703), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEI6/fUJ85OrVozq3W/kcv2hWUup+GD/eRSXBuq7Gwl85Cm5dLVhsmLvAdhjvoxJ24A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5701), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, "761b7a1f-eaf0-4e7f-a7b6-7974ba0903cb", new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3701), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3703), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHf4ovkOmcb+d8WIjc3eJLUcCivOrSFoXFBUF+DNS5mwFj3j0AM7jj+OQBUnpf/uIQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3702), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, "22c6ee54-ddaa-4dad-8c71-26865fef3797", new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1568), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1569), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHKR5mFITz4eoljgH+O4hi3Y8oxqjLZz1y2vPDDJ1JyflCaukVkEA7R2D2cPaRZSYg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1569), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, "3bf1e48e-cfea-4c01-98ab-33ff2f0db096", new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(915), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEMdpkdr4gfheFTe7lrGz0JktzNL/RGotaZLaS7B5hUJyhpAcK1Hq2aRTub9hSX1w1w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, "d3f2e9f7-a6a9-45b9-add9-744054ae61fe", new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4028), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4029), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEPrBHaXTeIZ+zHGG28/EouQKBpdlOesDezJ8ty8+14hIZ9rzf9tOxGJZMR0vWSzJCg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4028), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, "0faaef13-bd90-4291-8581-ae58ec158546", new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8077), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8082), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEGCT0SvfnIfSaxYplSuRGlcAbiOSw3EopL8md7OpxMefi8kHKdeVRpsMb97ur3472g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8081), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, "2f33ef32-56ef-4558-87f4-60bb635cdd0c", new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7083), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7085), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 65, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEA9MOYqthgv7tFu4xuhvSo0JjbAxWMv7lUNUS601Cby0OO6x5Ooc8TvkeoveYHzCAA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7084), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, "87d8ee8a-865e-4c94-b9b0-004eb9f918f1", new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9732), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9733), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEL9rE6JkVyB77j0PqDEPLQqQkjlnKiucDbkHCbXqlPRbw1fOddb0gmsoUXTOvucr1A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9732), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 32, new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(1989), new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(1987), new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(1991), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 523, DateTimeKind.Utc).AddTicks(1990), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 50, new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4230), new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4229), new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 544, DateTimeKind.Utc).AddTicks(4231), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369") },
                    { 49, new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2241), new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2240), new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2243), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 543, DateTimeKind.Utc).AddTicks(2242), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368") },
                    { 48, new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(595), new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(594), new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 542, DateTimeKind.Utc).AddTicks(596), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367") },
                    { 47, new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8713), new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8712), new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8715), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 540, DateTimeKind.Utc).AddTicks(8714), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366") },
                    { 46, new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7113), new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7112), new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7114), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 539, DateTimeKind.Utc).AddTicks(7113), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365") },
                    { 45, new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5840), new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5838), new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5841), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 538, DateTimeKind.Utc).AddTicks(5841), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364") },
                    { 44, new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4452), new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4451), new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4454), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 537, DateTimeKind.Utc).AddTicks(4453), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363") },
                    { 43, new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2699), new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2698), new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2701), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 536, DateTimeKind.Utc).AddTicks(2700), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362") },
                    { 51, new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6237), new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6237), new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6239), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 545, DateTimeKind.Utc).AddTicks(6238), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370") },
                    { 42, new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1042), new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1041), new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1043), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 535, DateTimeKind.Utc).AddTicks(1042), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361") },
                    { 40, new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7673), new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7672), new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7675), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 532, DateTimeKind.Utc).AddTicks(7674), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 39, new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5840), new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5838), new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5843), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 531, DateTimeKind.Utc).AddTicks(5841), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 38, new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3727), new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3727), new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3729), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 530, DateTimeKind.Utc).AddTicks(3728), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 37, new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1597), new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1596), new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 529, DateTimeKind.Utc).AddTicks(1598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 36, new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9758), new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9757), new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9759), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 527, DateTimeKind.Utc).AddTicks(9758), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 35, new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8135), new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8134), new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8136), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 526, DateTimeKind.Utc).AddTicks(8136), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 34, new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5918), new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5917), new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5920), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 525, DateTimeKind.Utc).AddTicks(5919), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 33, new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4065), new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4064), new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4067), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 524, DateTimeKind.Utc).AddTicks(4066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 41, new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9319), new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9318), new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9321), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 533, DateTimeKind.Utc).AddTicks(9320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 52, new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7735), new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7734), new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7736), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, 200m, new DateTime(2022, 7, 17, 8, 32, 56, 546, DateTimeKind.Utc).AddTicks(7735), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 94, 32, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5573), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5574), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5574), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 126, 42, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6464), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6465), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6464), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 127, 43, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6488), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6490), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6489), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 128, 43, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6512), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6514), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6513), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 129, 43, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6536), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6538), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6537), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 130, 44, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6563), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6564), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6564), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 131, 44, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6610), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6611), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6611), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 132, 44, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6634), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6636), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6635), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 133, 45, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6659), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6660), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6660), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 134, 45, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6683), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6685), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6684), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 135, 45, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6709), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6708), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 136, 46, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6733), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6732), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 137, 46, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6755), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6757), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6756), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 125, 42, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6439), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6441), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6440), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 138, 46, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6781), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6780), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 140, 47, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6849), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6851), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6850), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 141, 47, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6873), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6875), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6874), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 142, 48, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6898), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6899), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6898), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 143, 48, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6922), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6923), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6923), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 144, 48, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6946), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6948), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6947), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 145, 49, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6971), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6972), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6971), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 146, 49, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6995), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6996), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6995), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 147, 49, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7018), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7020), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7019), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 148, 50, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7068), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7067), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 149, 50, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7092), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7093), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7092), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 150, 50, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7116), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7117), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7117), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 151, 51, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7141), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7142), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7141), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 139, 47, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6824), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6826), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6825), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 124, 42, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6414), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6415), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6415), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 123, 41, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6367), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6369), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6368), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 122, 41, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6343), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6345), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6344), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 95, 32, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 96, 32, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5622), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5623), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5622), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 97, 33, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5647), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 98, 33, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5694), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5696), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5695), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 99, 33, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5719), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5721), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5720), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 100, 34, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5744), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5745), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5745), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 101, 34, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5768), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5770), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5769), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 102, 34, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5793), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5794), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5794), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 103, 35, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5817), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5819), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5818), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 104, 35, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5841), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5843), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5842), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 105, 35, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5865), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5867), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5866), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 106, 36, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5889), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5891), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5890), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 107, 36, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 108, 36, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5976), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(5977), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 109, 37, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6001), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6002), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6002), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 110, 37, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6025), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6027), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6026), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 111, 37, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6049), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6051), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6050), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 112, 38, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6073), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6075), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6074), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 113, 38, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6097), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6099), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6098), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 114, 38, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6121), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6123), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6122), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 115, 39, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6172), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6174), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6173), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 116, 39, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6198), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6199), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6198), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 117, 39, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6222), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6223), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6223), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 118, 40, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6246), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6248), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6247), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 119, 40, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6271), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6272), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6272), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 120, 40, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6295), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6296), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6296), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 121, 41, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6319), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(6320), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 152, 51, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7165), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7166), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7166), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 153, 51, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7189), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7190), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 7, 17, 8, 32, 56, 547, DateTimeKind.Utc).AddTicks(7190), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") }
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
