﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cic_subscriptions_backend.Context;

#nullable disable

namespace cic_subscription_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221024175733_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Building.Apartment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ApartmentName")
                        .HasColumnType("text");

                    b.Property<long>("StreetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Building.Floor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ApartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("FloorName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Floor");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RegionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.House.Flat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ApartmentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FloorId")
                        .HasColumnType("bigint");

                    b.Property<string>("HouseName")
                        .HasColumnType("text");

                    b.Property<long>("StreetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("FloorId");

                    b.HasIndex("StreetId");

                    b.ToTable("Flat");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Street", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("VillageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("VillageId");

                    b.ToTable("Street");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Village", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("VillageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Village");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<float>("Amount")
                        .HasPrecision(4, 2)
                        .HasColumnType("real");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("Date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.PhoneNumber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.SubscriptionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasPrecision(4, 2)
                        .HasColumnType("real");

                    b.Property<string>("SubName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionType");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ApartmentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<float>("Debt")
                        .HasPrecision(4, 2)
                        .HasColumnType("real");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("FlatId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FloorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StreetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SubscriptionDate")
                        .HasColumnType("Date");

                    b.Property<long?>("SubscriptionTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("VillageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("CityId");

                    b.HasIndex("FlatId");

                    b.HasIndex("FloorId");

                    b.HasIndex("RegionId");

                    b.HasIndex("StreetId");

                    b.HasIndex("SubscriptionTypeId");

                    b.HasIndex("VillageId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Building.Apartment", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.LocationModels.Street", "street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("street");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Building.Floor", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.LocationModels.Building.Apartment", "apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("apartment");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.City", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("region");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.House.Flat", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.LocationModels.Building.Apartment", "apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.Building.Floor", "floor")
                        .WithMany()
                        .HasForeignKey("FloorId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.Street", "street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("apartment");

                    b.Navigation("floor");

                    b.Navigation("street");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Street", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.LocationModels.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cic_subscription_backend.Models.LocationModels.Village", "village")
                        .WithMany()
                        .HasForeignKey("VillageId");

                    b.Navigation("city");

                    b.Navigation("village");
                });

            modelBuilder.Entity("cic_subscription_backend.Models.LocationModels.Village", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.LocationModels.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.Payment", b =>
                {
                    b.HasOne("cic_subscriptions_backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.PhoneNumber", b =>
                {
                    b.HasOne("cic_subscriptions_backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("cic_subscriptions_backend.Models.User", b =>
                {
                    b.HasOne("cic_subscription_backend.Models.LocationModels.Building.Apartment", "apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.House.Flat", "flat")
                        .WithMany()
                        .HasForeignKey("FlatId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.Building.Floor", "floor")
                        .WithMany()
                        .HasForeignKey("FloorId");

                    b.HasOne("cic_subscription_backend.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.Street", "street")
                        .WithMany()
                        .HasForeignKey("StreetId");

                    b.HasOne("cic_subscriptions_backend.Models.SubscriptionType", "subs")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId");

                    b.HasOne("cic_subscription_backend.Models.LocationModels.Village", "village")
                        .WithMany()
                        .HasForeignKey("VillageId");

                    b.Navigation("apartment");

                    b.Navigation("city");

                    b.Navigation("flat");

                    b.Navigation("floor");

                    b.Navigation("region");

                    b.Navigation("street");

                    b.Navigation("subs");

                    b.Navigation("village");
                });
#pragma warning restore 612, 618
        }
    }
}