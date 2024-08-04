using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeEmployee.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    logo = table.Column<byte[]>(type: "BLOB", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    employee_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    cafe_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    start_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_dete = table.Column<DateTime>(type: "TEXT", nullable: true),
                    is_active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCafe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email_address = table.Column<string>(type: "TEXT", nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: false),
                    cafe = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Cafes",
                columns: new[] { "id", "description", "location", "logo", "name" },
                values: new object[,]
                {
                    { new Guid("1fbd93e9-883e-4aab-ade6-682d9b45eb43"), "Cafe for QA Team", "North", new byte[0], "QA Team" },
                    { new Guid("4617d555-2f2f-4fa2-9f2a-b821da7f4d8a"), "Cafe for DevOps Team", "South", new byte[0], "DevOps Team" },
                    { new Guid("7c190a48-c154-42ab-be72-a4a78dedb4a6"), "Cafe for HR Team", "West", new byte[0], "HR Team" },
                    { new Guid("9958fcd1-ed81-4425-bb89-c83db3371dd0"), "Cafe for Finance Team", "East", new byte[0], "Finance Team" },
                    { new Guid("9e9730fd-1f32-442e-99ee-915fdaea7179"), "Cafe for DEV Team", "North East", new byte[0], "Dev Team" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeCafe",
                columns: new[] { "id", "cafe_id", "employee_id", "end_dete", "is_active", "start_date" },
                values: new object[,]
                {
                    { new Guid("0de6a327-2706-4906-a526-31387099c292"), new Guid("7c190a48-c154-42ab-be72-a4a78dedb4a6"), new Guid("e8935789-f212-4a15-96dd-76dc41efb738"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9826) },
                    { new Guid("0fde1d4f-340f-435c-bd8e-fdef622f5a5d"), new Guid("4617d555-2f2f-4fa2-9f2a-b821da7f4d8a"), new Guid("f857e21a-154f-4c40-bb3d-caa7ef2ae28c"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9835) },
                    { new Guid("153c908a-4d03-4f33-9fff-5d382e8275a4"), new Guid("1fbd93e9-883e-4aab-ade6-682d9b45eb43"), new Guid("db2810e4-98f4-4cfc-a841-55a8c9cf2a49"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9837) },
                    { new Guid("4c644b56-0244-4a9f-8450-dd3da56b3381"), new Guid("9958fcd1-ed81-4425-bb89-c83db3371dd0"), new Guid("36b0a6a8-8896-4919-ac75-9f16c1ccf2b9"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9820) },
                    { new Guid("64603032-044c-42fa-8a47-9bcc356cbfb8"), new Guid("4617d555-2f2f-4fa2-9f2a-b821da7f4d8a"), new Guid("85f57fd4-1b22-4b3e-9428-18846e3182fb"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9829) },
                    { new Guid("86aca5d4-e468-40d4-bb60-d4e53298a28f"), new Guid("9e9730fd-1f32-442e-99ee-915fdaea7179"), new Guid("937b8c00-34d7-445d-8cd5-21b185463e90"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9843) },
                    { new Guid("8a6de27d-64df-4566-b754-c4a6f6b47941"), new Guid("7c190a48-c154-42ab-be72-a4a78dedb4a6"), new Guid("618b1ec6-a019-4ad7-922f-61f0085ed677"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9823) },
                    { new Guid("d4181e6e-c0d6-4d5c-8522-0ea64bd34f37"), new Guid("9e9730fd-1f32-442e-99ee-915fdaea7179"), new Guid("b4cd3931-080d-4626-bbc6-0592652fc8c4"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9847) },
                    { new Guid("f8a26cfd-8821-49ef-b60d-3c3499603dfe"), new Guid("1fbd93e9-883e-4aab-ade6-682d9b45eb43"), new Guid("d4766448-2c1c-4a47-8344-d0119f109fcb"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9840) },
                    { new Guid("f8f5687e-7baa-440b-a867-59e7fae41f48"), new Guid("9958fcd1-ed81-4425-bb89-c83db3371dd0"), new Guid("78499d51-01df-4798-94e8-66462112ebcd"), null, true, new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9797) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "cafe", "email_address", "gender", "name", "phone_number" },
                values: new object[,]
                {
                    { new Guid("36b0a6a8-8896-4919-ac75-9f16c1ccf2b9"), "", "lakshmanan@gmail.com", "Male", "Pangaraj", "6786862" },
                    { new Guid("618b1ec6-a019-4ad7-922f-61f0085ed677"), "", "Smith@gmail.com", "Male", "Smith", "6786863" },
                    { new Guid("78499d51-01df-4798-94e8-66462112ebcd"), "", "lakshmanan@gmail.com", "Male", "Lakshmanan", "6786861" },
                    { new Guid("85f57fd4-1b22-4b3e-9428-18846e3182fb"), "", "raja@gmail.com", "Male", "Raja", "6786865" },
                    { new Guid("937b8c00-34d7-445d-8cd5-21b185463e90"), "", "rani@gmail.com", "Female", "Arul Mahi", "6786869" },
                    { new Guid("b4cd3931-080d-4626-bbc6-0592652fc8c4"), "", "durai@gmail.com", "Male", "Durai", "6786860" },
                    { new Guid("d4766448-2c1c-4a47-8344-d0119f109fcb"), "", "rani@gmail.com", "Female", "Agnes Mary", "6786868" },
                    { new Guid("db2810e4-98f4-4cfc-a841-55a8c9cf2a49"), "", "rani@gmail.com", "Female", "Mahima", "6786867" },
                    { new Guid("e8935789-f212-4a15-96dd-76dc41efb738"), "", "stella@gmail.com", "Female", "stella", "6786864" },
                    { new Guid("f857e21a-154f-4c40-bb3d-caa7ef2ae28c"), "", "rani@gmail.com", "Female", "Rani", "6786866" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropTable(
                name: "EmployeeCafe");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
