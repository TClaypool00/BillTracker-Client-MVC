﻿// <auto-generated />
using System;
using BillTrackerClient.App.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BillTrackerClient.App.Migrations
{
    [DbContext(typeof(BillTrackerContext))]
    [Migration("20230923050217_AddedCompanyIdToBills")]
    partial class AddedCompanyIdToBills
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BillName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.PaymentHistory", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int?>("BillId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DateDue")
                        .HasColumnType("datetime(6)")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("DatePaid")
                        .HasColumnType("datetime(6)")
                        .HasColumnOrder(4);

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnOrder(2);

                    b.HasKey("HistoryId");

                    b.HasIndex("BillId");

                    b.ToTable("PaymentHistories");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Bill", b =>
                {
                    b.HasOne("BillTrackerClient.App.DataModels.Company", "Company")
                        .WithMany("Bills")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillTrackerClient.App.DataModels.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Company", b =>
                {
                    b.HasOne("BillTrackerClient.App.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.PaymentHistory", b =>
                {
                    b.HasOne("BillTrackerClient.App.DataModels.Bill", "Bill")
                        .WithMany("PaymentHistories")
                        .HasForeignKey("BillId");

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.UserRole", b =>
                {
                    b.HasOne("BillTrackerClient.App.DataModels.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillTrackerClient.App.DataModels.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Bill", b =>
                {
                    b.Navigation("PaymentHistories");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Company", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BillTrackerClient.App.DataModels.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
