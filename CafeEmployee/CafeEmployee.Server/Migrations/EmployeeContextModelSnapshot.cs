﻿// <auto-generated />
using System;
using CafeEmployee.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeEmployee.Server.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("CafeEmployee.Server.Models.Cafe", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("logo")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Cafes");

                    b.HasData(
                        new
                        {
                            id = new Guid("9958fcd1-ed81-4425-bb89-c83db3371dd0"),
                            description = "Cafe for Finance Team",
                            location = "East",
                            logo = new byte[0],
                            name = "Finance Team"
                        },
                        new
                        {
                            id = new Guid("7c190a48-c154-42ab-be72-a4a78dedb4a6"),
                            description = "Cafe for HR Team",
                            location = "West",
                            logo = new byte[0],
                            name = "HR Team"
                        },
                        new
                        {
                            id = new Guid("4617d555-2f2f-4fa2-9f2a-b821da7f4d8a"),
                            description = "Cafe for DevOps Team",
                            location = "South",
                            logo = new byte[0],
                            name = "DevOps Team"
                        },
                        new
                        {
                            id = new Guid("1fbd93e9-883e-4aab-ade6-682d9b45eb43"),
                            description = "Cafe for QA Team",
                            location = "North",
                            logo = new byte[0],
                            name = "QA Team"
                        },
                        new
                        {
                            id = new Guid("9e9730fd-1f32-442e-99ee-915fdaea7179"),
                            description = "Cafe for DEV Team",
                            location = "North East",
                            logo = new byte[0],
                            name = "Dev Team"
                        });
                });

            modelBuilder.Entity("CafeEmployee.Server.Models.Employee", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("cafe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            id = new Guid("78499d51-01df-4798-94e8-66462112ebcd"),
                            cafe = "",
                            email_address = "lakshmanan@gmail.com",
                            gender = "Male",
                            name = "Lakshmanan",
                            phone_number = "6786861"
                        },
                        new
                        {
                            id = new Guid("36b0a6a8-8896-4919-ac75-9f16c1ccf2b9"),
                            cafe = "",
                            email_address = "lakshmanan@gmail.com",
                            gender = "Male",
                            name = "Pangaraj",
                            phone_number = "6786862"
                        },
                        new
                        {
                            id = new Guid("618b1ec6-a019-4ad7-922f-61f0085ed677"),
                            cafe = "",
                            email_address = "Smith@gmail.com",
                            gender = "Male",
                            name = "Smith",
                            phone_number = "6786863"
                        },
                        new
                        {
                            id = new Guid("e8935789-f212-4a15-96dd-76dc41efb738"),
                            cafe = "",
                            email_address = "stella@gmail.com",
                            gender = "Female",
                            name = "stella",
                            phone_number = "6786864"
                        },
                        new
                        {
                            id = new Guid("85f57fd4-1b22-4b3e-9428-18846e3182fb"),
                            cafe = "",
                            email_address = "raja@gmail.com",
                            gender = "Male",
                            name = "Raja",
                            phone_number = "6786865"
                        },
                        new
                        {
                            id = new Guid("f857e21a-154f-4c40-bb3d-caa7ef2ae28c"),
                            cafe = "",
                            email_address = "rani@gmail.com",
                            gender = "Female",
                            name = "Rani",
                            phone_number = "6786866"
                        },
                        new
                        {
                            id = new Guid("db2810e4-98f4-4cfc-a841-55a8c9cf2a49"),
                            cafe = "",
                            email_address = "rani@gmail.com",
                            gender = "Female",
                            name = "Mahima",
                            phone_number = "6786867"
                        },
                        new
                        {
                            id = new Guid("d4766448-2c1c-4a47-8344-d0119f109fcb"),
                            cafe = "",
                            email_address = "rani@gmail.com",
                            gender = "Female",
                            name = "Agnes Mary",
                            phone_number = "6786868"
                        },
                        new
                        {
                            id = new Guid("937b8c00-34d7-445d-8cd5-21b185463e90"),
                            cafe = "",
                            email_address = "rani@gmail.com",
                            gender = "Female",
                            name = "Arul Mahi",
                            phone_number = "6786869"
                        },
                        new
                        {
                            id = new Guid("b4cd3931-080d-4626-bbc6-0592652fc8c4"),
                            cafe = "",
                            email_address = "durai@gmail.com",
                            gender = "Male",
                            name = "Durai",
                            phone_number = "6786860"
                        });
                });

            modelBuilder.Entity("CafeEmployee.Server.Models.EmployeeCafe", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("cafe_id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("employee_id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("end_dete")
                        .HasColumnType("TEXT");

                    b.Property<bool>("is_active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("EmployeeCafe");

                    b.HasData(
                        new
                        {
                            id = new Guid("f8f5687e-7baa-440b-a867-59e7fae41f48"),
                            cafe_id = new Guid("9958fcd1-ed81-4425-bb89-c83db3371dd0"),
                            employee_id = new Guid("78499d51-01df-4798-94e8-66462112ebcd"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9797)
                        },
                        new
                        {
                            id = new Guid("4c644b56-0244-4a9f-8450-dd3da56b3381"),
                            cafe_id = new Guid("9958fcd1-ed81-4425-bb89-c83db3371dd0"),
                            employee_id = new Guid("36b0a6a8-8896-4919-ac75-9f16c1ccf2b9"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9820)
                        },
                        new
                        {
                            id = new Guid("8a6de27d-64df-4566-b754-c4a6f6b47941"),
                            cafe_id = new Guid("7c190a48-c154-42ab-be72-a4a78dedb4a6"),
                            employee_id = new Guid("618b1ec6-a019-4ad7-922f-61f0085ed677"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9823)
                        },
                        new
                        {
                            id = new Guid("0de6a327-2706-4906-a526-31387099c292"),
                            cafe_id = new Guid("7c190a48-c154-42ab-be72-a4a78dedb4a6"),
                            employee_id = new Guid("e8935789-f212-4a15-96dd-76dc41efb738"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9826)
                        },
                        new
                        {
                            id = new Guid("64603032-044c-42fa-8a47-9bcc356cbfb8"),
                            cafe_id = new Guid("4617d555-2f2f-4fa2-9f2a-b821da7f4d8a"),
                            employee_id = new Guid("85f57fd4-1b22-4b3e-9428-18846e3182fb"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9829)
                        },
                        new
                        {
                            id = new Guid("0fde1d4f-340f-435c-bd8e-fdef622f5a5d"),
                            cafe_id = new Guid("4617d555-2f2f-4fa2-9f2a-b821da7f4d8a"),
                            employee_id = new Guid("f857e21a-154f-4c40-bb3d-caa7ef2ae28c"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9835)
                        },
                        new
                        {
                            id = new Guid("153c908a-4d03-4f33-9fff-5d382e8275a4"),
                            cafe_id = new Guid("1fbd93e9-883e-4aab-ade6-682d9b45eb43"),
                            employee_id = new Guid("db2810e4-98f4-4cfc-a841-55a8c9cf2a49"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9837)
                        },
                        new
                        {
                            id = new Guid("f8a26cfd-8821-49ef-b60d-3c3499603dfe"),
                            cafe_id = new Guid("1fbd93e9-883e-4aab-ade6-682d9b45eb43"),
                            employee_id = new Guid("d4766448-2c1c-4a47-8344-d0119f109fcb"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9840)
                        },
                        new
                        {
                            id = new Guid("86aca5d4-e468-40d4-bb60-d4e53298a28f"),
                            cafe_id = new Guid("9e9730fd-1f32-442e-99ee-915fdaea7179"),
                            employee_id = new Guid("937b8c00-34d7-445d-8cd5-21b185463e90"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9843)
                        },
                        new
                        {
                            id = new Guid("d4181e6e-c0d6-4d5c-8522-0ea64bd34f37"),
                            cafe_id = new Guid("9e9730fd-1f32-442e-99ee-915fdaea7179"),
                            employee_id = new Guid("b4cd3931-080d-4626-bbc6-0592652fc8c4"),
                            is_active = true,
                            start_date = new DateTime(2023, 8, 1, 0, 35, 6, 301, DateTimeKind.Local).AddTicks(9847)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
