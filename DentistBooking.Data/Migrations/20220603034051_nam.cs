using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistBooking.Data.Migrations
{
    public partial class nam : Migration
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
                    { 1, "TestAddress1", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(2241), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(2847), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", "TestClinic1", 868644651, 0, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(2529), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51") },
                    { 2, "TestAddress2", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4165), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4170), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", "TestClinic2", 868644651, 0, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4168), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52") },
                    { 3, "TestAddress3", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4201), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4203), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", "TestClinic3", 868644651, 0, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4202), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53") },
                    { 4, "TestAddress4", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4225), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4227), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", "TestClinic4", 868644651, 0, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4226), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54") },
                    { 5, "TestAddress5", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4256), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4258), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", "TestClinic5", 868644651, 0, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(4257), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55") }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "ApplyForAll", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "Description", "EndDate", "Percent", "StartDate", "Title", "Updated_at", "Updated_by", "status" },
                values: new object[,]
                {
                    { 4, 10m, true, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(464), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(466), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), "TestDescirption4", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(462), 5f, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(461), "TestTitle4", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(465), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e54"), 0 },
                    { 3, 10m, true, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(426), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(428), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), "TestDescirption3", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(424), 5f, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(422), "TestTitle3", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(427), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e53"), 0 },
                    { 5, 10m, true, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(490), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(492), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), "TestDescirption5", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(488), 5f, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(487), "TestTitle5", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(491), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e55"), 0 },
                    { 1, 10m, true, new DateTime(2022, 6, 3, 10, 40, 50, 25, DateTimeKind.Local).AddTicks(228), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), new DateTime(2022, 6, 3, 10, 40, 50, 25, DateTimeKind.Local).AddTicks(1066), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), "TestDescirption1", new DateTime(2022, 6, 3, 10, 40, 50, 24, DateTimeKind.Local).AddTicks(7995), 5f, new DateTime(2022, 6, 3, 10, 40, 50, 24, DateTimeKind.Local).AddTicks(2823), "TestTitle1", new DateTime(2022, 6, 3, 10, 40, 50, 25, DateTimeKind.Local).AddTicks(502), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e51"), 0 },
                    { 2, 10m, true, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(309), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(311), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), "TestDescirption2", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(305), 5f, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(299), "TestTitle2", new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(310), new Guid("4bc632aa-7765-4040-9fbf-f2bb408d8e52"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056c"), "1b41e5b1-cf30-417f-a795-b3885c9ead1b", "Admin", "Admin", "ADMIN" },
                    { new Guid("20efd516-f16c-41b3-b11d-bc908cd2056b"), "24279fa8-86cd-4026-bd33-c203cc98252b", "User", "User", "USER" }
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
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, "6bf45b15-142c-438a-9692-b0249c93c5e3", new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5212), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5214), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELXcNIPdEImX5urGGsbfJqzzKqo4iLGb6FowJh6fh418KXrKIhVcHIdrVzgVLaGc0w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5213), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, "f216ed5c-0241-4ab2-8002-d403ae8a4b22", new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9769), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEFpovPnN8DGukjWbJAeg6Y2iF0HrtkVZ+cwdPDqkKGqx/dHJLuzomEFcLwTd+kXJAw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9768), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, "8d8b9d50-7dc1-4604-a911-8912b890c6ae", new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3769), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3771), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGnmwbew9GdLhuWpprs/9AAVGktsFankyVBoSs8whoHBWfDedbLc3j1POngE8M46aw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3770), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, "85225bce-0de6-428b-98a9-2adc3e62d89d", new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(6994), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(6996), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECe6hEpXOudUZhqVqi4bPZSNzmPyD//Vs4+IIdO7QceAWxe6vnTZv/AqJuz4MYFRzg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(6995), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, "584ff5f5-4746-44e2-9867-fc10d26bae9f", new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(111), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(114), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELQLg7P6oyVnNBii8HnPu1f7vXhut5eETLNhoFqBRDURt4JitOOscaFFXTfH3VJfkw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(113), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, "2a629801-af04-4533-aa7c-962f2e3ab179", new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6159), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6161), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEGrMpGb4DAS3mqNogJB6IxlUtlwBX6w6hQUvnk9CpDL8CwzwjsVm8GSAxfNrlnKV/Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6160), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, "5a1d35d8-1507-483d-ab8b-34f237b72c53", new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9300), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9304), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPJTnPVh9Mp1PQBWYQi4/jZVDsiI37iG+5+n9vY/IB9zOjrJuor90qUzPOtW4U/4Lw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9303), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, "666163fc-dd4c-41ca-a256-c6322e83fb34", new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2051), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2052), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEMVMfMbQxgIecoKvEgWdhQ+fo7jdCuymqeaglKgk1nyGftVILlJwDwQcwxf9Jacp9A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2052), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, "be001080-3484-4391-95ad-4510910f6d72", new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5264), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5265), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEJ24Vdet2KbeKOa6phTweTav+HlBKoT1b7bpDSoY19t2/ZKQMIp6olrt0/fBhC4aQw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5264), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, "cfdcc9e1-e25e-439d-ad4d-9298723c0097", new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8368), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8373), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAED93PSuAdgIX9rqFZxr4hF9/28t87QX7VqM+bjhYwQvcs36fOlp/VdwX6D6odgaGGQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8372), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, "a1655f9e-649d-42d5-82fe-c1447e4f86e5", new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1213), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1216), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAENF0GFO3pkhtKli7p4LS3S095Nu89qaPqPdw41RkQ+ABmVbno8GRCT/2yqghgf7o7Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1215), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, "038d356c-1af1-4962-93ec-1e82a35c2e4b", new DateTime(2022, 6, 3, 3, 40, 50, 53, DateTimeKind.Utc).AddTicks(8623), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 53, DateTimeKind.Utc).AddTicks(9246), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEAclXuF3bk5I9/7l8vAAiIiHe3l/HjuoNDkY95vXwEbilNyIzsRtsxGZJAXi9/mL0Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 53, DateTimeKind.Utc).AddTicks(8953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, "ef502ae1-6e1c-48d8-9cb8-b472d4fdaf6c", new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3111), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3113), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEPKDdveH4a/c97DvfASB53OuqeeGyR9qafDC3+pckm86OjiadVK3QBKfNtVay7MiRw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3112), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, "4d3341e1-8167-46bb-8da9-3a3be3923481", new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(699), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEFGTFUyxBul3ZcHy7uP+by7NoWmN+bVugMgjQFy6LalB8Z6nygXe5BiLR1/3mEUAYQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(698), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, "f0649dd3-c326-41b7-9dd5-30e3508177c1", new DateTime(2022, 6, 3, 3, 40, 50, 144, DateTimeKind.Utc).AddTicks(9961), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 144, DateTimeKind.Utc).AddTicks(9962), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEP3YZQZkmoKJS7HdksoceaP6Alv7iv0zxPypY2OiIIqn9vpITerxJUJDtityXNAQaQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 144, DateTimeKind.Utc).AddTicks(9962), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, "1a36dbbc-085d-4499-9957-204887c7a133", new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4234), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEAd0T0Yw8zvKt6s2eq96VBwVKIvda+oaoQBGQB3j0aq19XDu547hxnmR4PQXmL5lSw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4233), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, "f2448742-b760-4ee0-8ea9-51b9e4d5d1a0", new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6093), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6096), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEOVdf7aD5eldOlX/JE588ZrdstsfkeDDHmqv78mnTvOWpMhTDBJVrys78hIyO7fhHA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6095), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, "42cfa997-f3bf-438b-a5b2-83c050186920", new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(1962), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(1964), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEOpeCqZMVkLN9u8NT4atCdb1f2HqPD7SzBg/jD+3Swtx9qoemtoPmMj0ewcwOJEOMA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(1963), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, "fa8f0fb3-023a-4e8c-a1e2-7611f5f6b2a9", new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5930), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5932), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEJ5zF8lW2dptAT36kwUqCCBt4yMQNduOS6PpqwBJ5/PxfzjQ4QUhiANoKxXILKcaJw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5931), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, "64bb723d-582e-410b-bf0e-f1cfb6b4c649", new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1241), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1243), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEEg/VqIEoI5XA6a8bz07+6i9AvkW18YbzbeUnMIbRSz2LgUKhDvPCwyfBMauvcN+ew==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1242), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_at", "Created_by", "DOB", "Deleted_at", "Deleted_by", "DentistId", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "Token", "TwoFactorEnabled", "Updated_at", "Updated_by", "UserName" },
                values: new object[,]
                {
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, "b8e456af-d49e-4c57-a155-6cf88670f7ee", new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3491), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3498), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEBuMDXd2tSfHIxp7u5HAHTMP/uPbT4bQFesnkRKGB41R+lO8DV+FNqwb7m1qbtoAxQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3495), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, "6b4a8e73-29a7-4153-af8e-59a74118cbbb", new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8533), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8539), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEERgZ2lSu8s1F/SMZiVgKr+G1FofXBbgNjzneg6ZuTOuiGyTX6ZvBnVY1e8cqh0mug==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8537), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, "ca18ea44-85a4-470e-bf3f-2c6da60bda5b", new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(495), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEKS1fqtq3st4TmDxKqHAx5MHdO2fvCzyrt2qTHkDQYBFRoLcwNq6TLtncOVevnF4qg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(502), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, "a79b4c3e-86cf-4429-9e53-a6722ee207af", new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5281), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5291), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAENBdfugCZNS3LV1no9HHQh7w8uoQVb/BgpwuOIuR1MSwtGyFoHH1wLZTGB9zV3ahAA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5287), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, "e4ab09d8-af9a-4a08-acec-d04b380c726e", new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3710), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3720), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELxYYYOaYlKXrs6XNK6pqFaTOXem+YKUIDiV7JPhzWyi2rZoxFX0u988clhbyMyo2g==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3718), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, "48a5a4e8-5f24-4ad5-820d-f6f9748bdd23", new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1087), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEDULdwDtI9tHe1KXc4Dh8+6eLmagphARVjJw+tpkxVFd2jvhtFSFNxLAItY7KCsHfA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1088), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, "faedcc02-16e7-4433-8245-aca9d4dede2b", new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(8914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(8925), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEAgc355EFXcVkBFfRVzca5umA/DWGHi6NzOAOZaGMyaBRow8ilkIdt88/0cGXs1Wcw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(8923), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, "2447be5e-3e20-43ee-8e45-47005f3c1ee8", new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6950), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAELXiBhjn2dTk+h/XMCf+47ghfeH3Sa9hE5XGd1KLf5fFv2HaevR4g1IAjt+XxxMVIg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6951), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, "2046a5d2-218f-41bb-a4f5-822580c3045e", new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5230), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5234), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEHXy5DCNiQ4kddCJ2DgRyFrcu4MT9uTIQp+pLmcYAWq427LTSAynfseP2QtDxwD1Ww==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, "775c9f35-8160-467c-ada9-c7578bfad8ef", new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8759), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAECTz0wSz76mL2b1Wg+Gya6Nd+zbrwSuB5zJnpfi5IRXpeY7U5gKeeXgFBnZpzVwnWg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8762), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, "4a74d87d-4c49-450d-9628-24bc40f2bc4e", new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(337), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(340), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null, "anhkhoahuynh90@gmail.com", false, "Huynh", 0, "Anh Khoa", false, null, null, null, "AQAAAAEAACcQAAAAEKocfALtdvLO8ieJapPS3SyZOBzolEnC0fj7M+BoS/YszbBDZgPrjgfKYewcBx4Anw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(339), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5338), new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5336), new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5341), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 237, DateTimeKind.Utc).AddTicks(5339), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2650") },
                    { 30, new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6990), new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6989), new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6992), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 231, DateTimeKind.Utc).AddTicks(6991), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2649") },
                    { 1, new DateTime(2022, 6, 3, 3, 40, 50, 54, DateTimeKind.Utc).AddTicks(1874), new DateTime(2022, 6, 3, 3, 40, 50, 54, DateTimeKind.Utc).AddTicks(1178), new DateTime(2022, 6, 3, 3, 40, 50, 54, DateTimeKind.Utc).AddTicks(2338), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 54, DateTimeKind.Utc).AddTicks(2095), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2620") },
                    { 2, new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1269), new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1268), new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1271), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 60, DateTimeKind.Utc).AddTicks(1270), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2621") },
                    { 3, new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8483), new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8482), new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8485), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 65, DateTimeKind.Utc).AddTicks(8484), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2622") },
                    { 4, new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5297), new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5296), new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5298), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 71, DateTimeKind.Utc).AddTicks(5297), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2623") },
                    { 5, new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2091), new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2090), new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2093), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 77, DateTimeKind.Utc).AddTicks(2092), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2624") },
                    { 6, new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9422), new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9420), new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9424), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 82, DateTimeKind.Utc).AddTicks(9423), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2625") },
                    { 7, new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6248), new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6247), new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6250), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 88, DateTimeKind.Utc).AddTicks(6249), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2626") },
                    { 9, new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(207), new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(206), new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(208), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 100, DateTimeKind.Utc).AddTicks(208), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2628") },
                    { 10, new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(7033), new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(7032), new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(7034), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 105, DateTimeKind.Utc).AddTicks(7033), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2629") },
                    { 11, new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3803), new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3802), new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3805), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 111, DateTimeKind.Utc).AddTicks(3804), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2630") },
                    { 12, new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9858), new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9856), new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9859), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 116, DateTimeKind.Utc).AddTicks(9858), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2631") },
                    { 13, new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5247), new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5246), new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5248), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 122, DateTimeKind.Utc).AddTicks(5248), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2632") },
                    { 14, new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(739), new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(738), new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(740), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 128, DateTimeKind.Utc).AddTicks(739), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2633") },
                    { 8, new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3155), new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3154), new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3156), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 94, DateTimeKind.Utc).AddTicks(3155), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2627") },
                    { 16, new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4279), new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4278), new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4280), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 139, DateTimeKind.Utc).AddTicks(4280), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2635") },
                    { 15, new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8864), new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8862), new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8865), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 133, DateTimeKind.Utc).AddTicks(8865), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2634") },
                    { 28, new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1186), new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1184), new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1187), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 220, DateTimeKind.Utc).AddTicks(1186), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2647") },
                    { 27, new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3968), new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3967), new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3969), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 214, DateTimeKind.Utc).AddTicks(3969), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2646") },
                    { 26, new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5713), new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5709), new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5715), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 208, DateTimeKind.Utc).AddTicks(5714), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2645") },
                    { 24, new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8825), new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8821), new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8827), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 189, DateTimeKind.Utc).AddTicks(8826), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2643") },
                    { 23, new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3665), new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3663), new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3667), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 180, DateTimeKind.Utc).AddTicks(3666), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2642") },
                    { 25, new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(861), new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(857), new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(863), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 200, DateTimeKind.Utc).AddTicks(862), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2644") },
                    { 29, new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(9073), new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(9072), new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(9075), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 225, DateTimeKind.Utc).AddTicks(9074), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2648") },
                    { 21, new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5964), new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5963), new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5965), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 167, DateTimeKind.Utc).AddTicks(5964), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2640") },
                    { 20, new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(532), new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(531), new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(534), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 162, DateTimeKind.Utc).AddTicks(533), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2639") },
                    { 19, new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(2003), new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(2002), new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(2005), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 156, DateTimeKind.Utc).AddTicks(2004), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2638") },
                    { 18, new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6205), new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6203), new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6207), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 150, DateTimeKind.Utc).AddTicks(6206), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2637") },
                    { 17, new DateTime(2022, 6, 3, 3, 40, 50, 145, DateTimeKind.Utc).AddTicks(8), new DateTime(2022, 6, 3, 3, 40, 50, 145, DateTimeKind.Utc).AddTicks(7), new DateTime(2022, 6, 3, 3, 40, 50, 145, DateTimeKind.Utc).AddTicks(10), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 145, DateTimeKind.Utc).AddTicks(9), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2636") },
                    { 22, new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1270), new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1269), new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1272), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), 0, 100m, new DateTime(2022, 6, 3, 3, 40, 50, 173, DateTimeKind.Utc).AddTicks(1271), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae2641") }
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
                    { 1, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(8122), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(8707), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1"), 1, "testService@gmail.com1", 1m, "testProcedure1", 0, new DateTime(2022, 6, 3, 10, 40, 50, 26, DateTimeKind.Local).AddTicks(8422), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a1") },
                    { 2, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(236), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(241), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2"), 2, "testService@gmail.com2", 2m, "testProcedure2", 0, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(240), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a2") },
                    { 3, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(275), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(277), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3"), 3, "testService@gmail.com3", 3m, "testProcedure3", 0, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(276), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a3") },
                    { 4, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(299), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(301), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4"), 4, "testService@gmail.com4", 4m, "testProcedure4", 0, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(300), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a4") },
                    { 5, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(323), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(325), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5"), 5, "testService@gmail.com5", 5m, "testProcedure5", 0, new DateTime(2022, 6, 3, 10, 40, 50, 27, DateTimeKind.Local).AddTicks(324), new Guid("74965f04-3baa-44ef-878a-50862a6fe9a5") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 11, 4, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7679), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7681), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 34, 12, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8094), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8095), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8094), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 35, 12, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8106), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8108), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8107), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 36, 12, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8119), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8120), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321"), 21, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8120), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3321") },
                    { 37, 13, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8131), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8133), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8132), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 38, 13, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8144), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8145), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8144), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 39, 13, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8156), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8157), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322"), 22, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8157), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3322") },
                    { 40, 14, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8202), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8204), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8203), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 33, 11, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8079), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8081), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8080), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 41, 14, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8217), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8218), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8217), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 43, 15, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8242), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8243), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8243), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 44, 15, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8254), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8255), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8255), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 45, 15, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8266), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8267), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324"), 24, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8267), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3324") },
                    { 46, 16, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8278), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8280), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8279), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 47, 16, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8291), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8292), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8291), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 48, 16, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8303), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8304), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325"), 25, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8303), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3325") },
                    { 49, 17, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8344), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8346), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8345), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 42, 14, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8229), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8231), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323"), 23, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8230), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3323") },
                    { 32, 11, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8065), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8066), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 31, 11, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8000), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8001), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320"), 20, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8000), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3320") },
                    { 30, 10, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7988), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7989), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7988), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 13, 5, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 14, 5, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7717), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7719), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7718), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 15, 5, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7765), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314"), 14, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7765), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3314") },
                    { 16, 6, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7780), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7780), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 17, 6, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7792), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7793), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7792), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 18, 6, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7806), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7807), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315"), 15, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7807), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3315") },
                    { 19, 7, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7819), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7820), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7820), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 20, 7, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7831), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7833), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7832), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 21, 7, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7844), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7845), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316"), 16, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7844), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3316") },
                    { 22, 8, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7857), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7857), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 23, 8, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7899), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7900), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7899), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 24, 8, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7913), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7914), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317"), 17, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7913), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3317") },
                    { 25, 9, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7925), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7926), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7926), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 26, 9, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7938), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7939), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7938), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 27, 9, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7950), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7951), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318"), 18, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7951), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3318") },
                    { 28, 10, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7963), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7964), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7963), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 29, 10, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7975), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7977), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319"), 19, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7976), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3319") },
                    { 50, 17, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8358), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8360), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8359), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 51, 17, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8371), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8372), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326"), 26, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8371), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3326") },
                    { 52, 18, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8383), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8385), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8384), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 53, 18, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8395), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8397), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8396), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 75, 25, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8763), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8764), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8764), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 76, 26, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8776), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8777), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8776), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 77, 26, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8788), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8790), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8789), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 78, 26, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8801), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8802), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335"), 35, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8801), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3335") },
                    { 79, 27, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8813), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8815), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8814), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 80, 27, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8825), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8827), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8826), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 81, 27, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8838), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8839), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336"), 36, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8838), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3336") },
                    { 82, 28, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8850), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8851), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8850), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 83, 28, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8892), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8893), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8893), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 84, 28, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8906), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8907), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337"), 37, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8907), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3337") },
                    { 85, 29, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8919), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8920), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8920), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 86, 29, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8932), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8933), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8932), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 87, 29, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8945), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8946), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338"), 38, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8945), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3338") },
                    { 88, 30, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8957), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8958), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8958), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 89, 30, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8969), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8971), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8970), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 90, 30, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8981), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8983), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339"), 39, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8982), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3339") },
                    { 91, 31, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8994), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8995), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8995), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 74, 25, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8749), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8751), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8750), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 12, 4, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7692), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7693), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7693), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") },
                    { 73, 25, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8708), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334"), 34, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3334") },
                    { 71, 24, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8682), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8683), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8683), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 54, 18, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8408), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8409), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327"), 27, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8409), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3327") },
                    { 55, 19, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8420), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8421), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8421), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 56, 19, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8433), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8434), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8433), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 57, 19, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8445), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8446), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328"), 28, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8445), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3328") },
                    { 58, 20, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8487), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8489), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8488), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 59, 20, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8500), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8501), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8501), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 60, 20, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8513), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8514), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329"), 29, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8513), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3329") },
                    { 61, 21, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8525), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8527), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8526), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 62, 21, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8538), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8539), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8539), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 63, 21, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8551), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330"), 30, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8551), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3330") },
                    { 64, 22, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8563), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8564), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8563), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 65, 22, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8575), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8576), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8575), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 66, 22, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8619), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8621), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331"), 31, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8620), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3331") },
                    { 67, 23, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8632), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8633), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8633), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 68, 23, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8644), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8646), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8645), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 69, 23, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8657), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8658), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332"), 32, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8658), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3332") },
                    { 70, 24, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8670), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8671), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8670), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 72, 24, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8694), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8695), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333"), 33, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(8695), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3333") },
                    { 92, 31, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9036), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9038), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9037), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 93, 31, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9050), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9051), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340"), 40, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9051), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3340") },
                    { 9, 3, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7653), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7654), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7654), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 8, 3, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7640), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7641), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7641), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 7, 3, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7628), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7629), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312"), 12, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7628), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3312") },
                    { 6, 2, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7612), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7614), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7613), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 5, 2, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7555), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7556), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7555), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 4, 2, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7542), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7544), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311"), 11, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7543), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3311") },
                    { 3, 1, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7528), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7529), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7528), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 2, 1, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7507), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7506), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 1, 1, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(5711), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(6238), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310"), 10, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(5952), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3310") },
                    { 10, 4, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7666), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7668), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313"), 13, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(7667), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3313") }
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
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, "1ed5f246-d747-4181-b8e4-06b4bc5b755b", new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8311), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8318), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEIlWxrYpE6boolzCX8HxQAd1DRgiyi9M8Vt9OC2EetFjVWTt6/zCvya10s098Kepeg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8317), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, "700ef4e7-2ce9-4b46-b300-5b0d1378acf0", new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1844), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1846), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKHe6fO8KWWFz5Ra0Bzf/JdqbIGh4PPgzTFWJJEIgfnJJvSDttCmKlg87EJHv7Rs6A==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1845), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, "df42d824-e475-46b9-ac5f-bdf166d800ee", new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9776), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9780), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEGccZM/Rt3dex0VIeQ7PGaXmTVfAlWnTKRdvvUhGY9EZjq5dnuGpNkOp1A0Rkt10aQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9779), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, "de09a3d0-2963-4d27-b32d-229ecc6e957e", new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7388), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7391), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEIjOg4pAinY3AUjEVTwxjkO2T0Nua/4wh/oEknKpHg4r24A5FcXvhKU1WZiJCHOhwQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7390), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, "fa306bee-305b-4d55-b15c-b9678c7cff34", new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(4912), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(4913), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKuG84u514wx2QdvjiYhJZkBmNpYwGYH3K4SbB74IWXltGoyTIrX1Ul4zcKd9OowpA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(4912), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, "d06c7331-c4e0-40a0-8298-c70454b1a41f", new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2652), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2656), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEJv7Woyt0TZmAmI4wQ7qteLkMCaCGlNVHYhwTtmPkPv5ebGUAGP1nbW/eYdo1RF7Ow==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2655), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, "6669b44f-f405-4add-a964-79b1a5ca2a1b", new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9854), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9856), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEBlbuXGpxUlxK+m/kMNq2sRxPo36iwkDnTaAMDLZNm78DzgjUxdgexBKHEPSmkND/Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9855), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, "778be2ac-e9a2-4405-97ff-5b8afe1d7b3b", new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7339), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7340), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEOh/7RAYfzcE1vEBgBr+Ft/BAkS3sbIsMHoaVMWoLHMlpiuAzZ9WA9rybc9TnclNYw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7339), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, "04e39fdf-0a70-43e4-8031-c9e688ccc542", new DateTime(2022, 6, 3, 3, 40, 50, 296, DateTimeKind.Utc).AddTicks(9847), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 296, DateTimeKind.Utc).AddTicks(9852), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEAHeTHlsPnoWpYK4oiZL33f8ZGFNUB7bT39k3DLPvQxxRRnNMFJwYg3WxgZeneaG7Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 296, DateTimeKind.Utc).AddTicks(9851), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, "fb28c120-4879-4406-a02e-f9620cf8e651", new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2553), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2555), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 66, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEItDIRUy4u6PlXT+mcMcHjb8kk2rNGtLmJvNj4Z7nwNjyaH39xGim5LaaMq2kjYbvg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2555), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, "6716cab0-80a6-4bae-a569-c7d2a2bce311", new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4741), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4742), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 62, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHavxaxzYpI1o+D2N5TbkGAG/Fhlwad4leGArdxkBRJ2WsCrBK8SmllArHaiFgVINw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4742), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, "548fd716-b71a-44bd-a490-c58bb1f744de", new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1486), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1488), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 63, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEIAnpguOJV/yrFZ37Tr4UsMu9D8bHb5e2iybEvxOD3/W4mWzepvpTLb+jL9/CLZGRA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1487), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, "30cf9c79-33a5-41e4-abc4-9cb919fc093c", new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(8968), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(8972), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 64, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEHIY4eaunzUejrn8djHn8ka7VA9Ls/ZDOJDlXK1pv6L6F77dkzNJ4PrUpZ7w1K37/Q==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(8971), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, "fd71a72d-e4a9-4768-b235-d016786146e1", new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5793), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5795), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 65, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEDSjLY3C2vC1zl1WDubcDvb4r3H0CK+Eio+Vb05U8OpBVc/Qf2TEcm8TLne2+f97aA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5794), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, "8df22428-92ab-42c0-b9ba-cbbd8465b4f7", new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(528), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(531), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 67, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEPvZfzLYO7rB3iYIxB2HJzt8VXmcgsM3UjnpDPywTZUNNEU7dbOHjBdZjTWT7dqzEA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(530), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, "c8065cce-07fb-491e-adde-c08419b981e4", new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7315), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7316), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 68, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKwKd6mHlLAo6sAkNmV7miKMTPLqshZaYY0/VClfwIc2+t0YDPuApKzzR4219c53LQ==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7316), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, "21f4d264-99c6-46ed-ab6c-8be5a16651c4", new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(3992), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(3994), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 69, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEC4Ii3kurytqf2v76kHsrbP0w72T9cGKXNQwC6VJrORlq3zzkH6omVTD1HKgEmi6mA==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(3993), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, "6bf5e30d-5b36-4084-b491-cc6d89965460", new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(5999), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(6002), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 70, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEN3ttSY+l/+Wd5OmpZAQ6ByyvRnMwu7pzLfSjSmBR+m2lyEmojwKxQxvqQG7zO+e+w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(6001), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, "e7ec3241-6367-44cf-aaca-12b6e6086717", new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2886), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 71, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEKF22EDjlPiOLHfDIFHSoFyy1dNAVNheEXWyTxARRwQEpNejlBHj3J4jt9W+cNV8pw==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2888), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, "bf96abd6-ebaf-4c56-9a8d-8c716b564374", new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(7897), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(7902), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 61, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEEgDfikMXq1bktnscHUSYAg76bDFqi1txIuBa16GGn9Fh/qaAETafPa4uvSP7xEmAg==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(7901), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), null },
                    { new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, "8dca1fd3-327a-49fb-8df7-0c459e272e6e", new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(3712), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(3720), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, "ducsama90@gmail.com", false, "Nguyen", 1, "Duong Minh Duc", false, null, null, null, "AQAAAAEAACcQAAAAEP6xoJR6C0PLp6QhZyigqOLDFdYgKtCSlOTTLvzKpz2jh2d3F2Kn/XToMAINkMjr2w==", "0868644651", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, "xxx", false, new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(3719), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Created_at", "Date", "Deleted_at", "Deleted_by", "Status", "Total", "Updated_at", "Updated_by", "UserId" },
                values: new object[,]
                {
                    { 32, new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(4475), new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(4471), new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(4477), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 243, DateTimeKind.Utc).AddTicks(4475), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 50, new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(4017), new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(4016), new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(4019), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 348, DateTimeKind.Utc).AddTicks(4018), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3369") },
                    { 49, new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7340), new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7339), new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7342), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 342, DateTimeKind.Utc).AddTicks(7341), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3368") },
                    { 48, new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(596), new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(594), new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 337, DateTimeKind.Utc).AddTicks(596), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3367") },
                    { 47, new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2584), new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2583), new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2586), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 331, DateTimeKind.Utc).AddTicks(2585), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3366") },
                    { 46, new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5869), new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5868), new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 325, DateTimeKind.Utc).AddTicks(5870), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3365") },
                    { 45, new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(9044), new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(9042), new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(9046), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 319, DateTimeKind.Utc).AddTicks(9045), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3364") },
                    { 44, new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1505), new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1504), new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1506), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 314, DateTimeKind.Utc).AddTicks(1505), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3363") },
                    { 43, new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4764), new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4763), new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4766), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 308, DateTimeKind.Utc).AddTicks(4765), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3362") },
                    { 51, new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(6053), new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(6052), new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(6055), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 354, DateTimeKind.Utc).AddTicks(6054), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3370") },
                    { 42, new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(8053), new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(8050), new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(8055), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 302, DateTimeKind.Utc).AddTicks(8054), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3361") },
                    { 40, new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8488), new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8485), new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8490), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 289, DateTimeKind.Utc).AddTicks(8489), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 39, new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7365), new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7365), new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7367), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 283, DateTimeKind.Utc).AddTicks(7366), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 38, new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9923), new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9922), new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9925), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 277, DateTimeKind.Utc).AddTicks(9924), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 37, new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2738), new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2736), new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2739), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 272, DateTimeKind.Utc).AddTicks(2739), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 36, new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(5048), new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(5047), new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(5049), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 266, DateTimeKind.Utc).AddTicks(5048), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 35, new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7421), new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7420), new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7422), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 260, DateTimeKind.Utc).AddTicks(7422), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 34, new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9891), new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9890), new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9893), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 254, DateTimeKind.Utc).AddTicks(9892), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 33, new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1945), new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1944), new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1946), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 249, DateTimeKind.Utc).AddTicks(1946), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 41, new DateTime(2022, 6, 3, 3, 40, 50, 297, DateTimeKind.Utc).AddTicks(59), new DateTime(2022, 6, 3, 3, 40, 50, 297, DateTimeKind.Utc).AddTicks(58), new DateTime(2022, 6, 3, 3, 40, 50, 297, DateTimeKind.Utc).AddTicks(61), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 297, DateTimeKind.Utc).AddTicks(60), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 52, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2915), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2911), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2917), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), 0, 200m, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(2916), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371"), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3371") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 94, 32, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9063), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9064), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9063), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 126, 42, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9609), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9610), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9610), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 127, 43, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9651), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9653), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9652), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 128, 43, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9665), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9667), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9666), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 129, 43, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9678), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9680), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352"), 52, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9679), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3352") },
                    { 130, 44, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9693), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9694), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9694), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 131, 44, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9705), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9707), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9706), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 132, 44, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9717), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9718), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353"), 53, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9718), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3353") },
                    { 133, 45, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9731), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9730), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 134, 45, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9773), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9775), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9774), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 135, 45, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9787), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354"), 54, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9786), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3354") },
                    { 136, 46, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9798), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9799), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9799), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 137, 46, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9810), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9812), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9811), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 125, 42, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9597), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9599), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9598), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 138, 46, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9822), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9824), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355"), 55, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9823), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3355") },
                    { 140, 47, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9846), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9848), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9847), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 141, 47, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9858), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9860), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9859), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 142, 48, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9870), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9871), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 143, 48, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9917), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9918), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9917), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 144, 48, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9929), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9930), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357"), 57, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9930), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3357") },
                    { 145, 49, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9941), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9943), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9942), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 146, 49, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9953), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9955), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9954), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 147, 49, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9965), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9967), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358"), 58, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9966), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3358") },
                    { 148, 50, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9979), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9978), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 149, 50, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9990), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9991), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9990), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 150, 50, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(2), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(3), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359"), 59, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(2), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3359") },
                    { 151, 51, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(46), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(48), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(47), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 139, 47, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9834), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9836), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356"), 56, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9835), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3356") },
                    { 124, 42, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9585), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9586), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351"), 51, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9586), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3351") },
                    { 123, 41, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9573), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9574), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9574), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 122, 41, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9561), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9562), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9562), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 95, 32, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9076), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9077), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9076), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 96, 32, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9088), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341"), 41, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9089), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3341") },
                    { 97, 33, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9101), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9102), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9101), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 98, 33, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9113), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9114), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9113), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 99, 33, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9125), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9126), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342"), 42, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9126), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3342") },
                    { 100, 34, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9137), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9139), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9138), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 101, 34, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9193), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9195), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9194), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 102, 34, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9206), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9207), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343"), 43, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9207), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3343") },
                    { 103, 35, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9219), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9220), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9220), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 104, 35, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9231), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9233), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9232), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") },
                    { 105, 35, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9244), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9245), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344"), 44, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9244), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3344") }
                });

            migrationBuilder.InsertData(
                table: "Booking_Details",
                columns: new[] { "Id", "BookingId", "Created_at", "Created_by", "Deleted_at", "Deleted_by", "DentistId", "KeyTime", "Note", "ServiceId", "Status", "Updated_at", "Updated_by" },
                values: new object[,]
                {
                    { 106, 36, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9256), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9257), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9257), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 107, 36, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9268), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9270), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9269), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 108, 36, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9281), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9282), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345"), 45, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9281), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3345") },
                    { 109, 37, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9293), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9294), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9294), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 110, 37, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9337), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9338), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9338), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 111, 37, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9350), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9351), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346"), 46, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9351), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3346") },
                    { 112, 38, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9362), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9364), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9363), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 113, 38, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9375), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9376), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9376), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 114, 38, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9388), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9389), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347"), 47, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9388), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3347") },
                    { 115, 39, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9400), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9401), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 116, 39, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9412), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9413), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9413), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 117, 39, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9427), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9429), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348"), 48, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9428), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3348") },
                    { 118, 40, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9447), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9450), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9449), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 119, 40, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9523), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9525), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9524), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 120, 40, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9536), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9538), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349"), 49, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9537), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3349") },
                    { 121, 41, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9549), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350"), 50, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 360, DateTimeKind.Utc).AddTicks(9550), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3350") },
                    { 152, 51, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(60), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(62), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(61), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") },
                    { 153, 51, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(73), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(74), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360"), 60, 0, "nhe nhang thoi nha bac si", 1, 0, new DateTime(2022, 6, 3, 3, 40, 50, 361, DateTimeKind.Utc).AddTicks(73), new Guid("d5a918c6-5ed4-43eb-bcdf-042594ae3360") }
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
