﻿// <auto-generated />
using System;
using BusBookingApp.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusBookingApp.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusBookingApp.bus.BusDetail", b =>
                {
                    b.Property<int>("serialNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("serialNo"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("droptime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("pickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("pickuptime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registrationNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serialNo");

                    b.ToTable("busDetails");
                });

            modelBuilder.Entity("BusBookingApp.bus.Login", b =>
                {
                    b.Property<int>("serialNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("serialNo"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serialNo");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("BusBookingApp.bus.Ratting", b =>
                {
                    b.Property<int>("sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sno"));

                    b.Property<string>("busname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("command")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rattings")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("sno");

                    b.ToTable("busRatting");
                });

            modelBuilder.Entity("BusName", b =>
                {
                    b.Property<int>("serialno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("serialno"));

                    b.Property<string>("_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_17")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_18")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_19")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_21")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_22")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_23")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_24")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_25")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_26")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_27")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_28")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_29")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_30")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_31")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_32")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_33")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_34")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_35")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_36")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_37")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_38")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_39")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_40")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_41")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_42")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_43")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_44")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("busName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("busNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dropplace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("droptime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("pickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("pickupplace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pickuptime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serialno");

                    b.ToTable("busNames");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("sno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sno"));

                    b.Property<string>("busname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("droptime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("pickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("pickuptime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registrationno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seatno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("sno");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}