﻿// <auto-generated />
using System;
using L00177784_CA2_GolfApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace L00177784_CA2_GolfApp.Migrations
{
    [DbContext(typeof(GolfAppDBContext))]
    [Migration("20230308130253_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("L00177784_CA2_GolfApp.Data.GolfMember", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Handicap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.HasKey("MemberID");

                    b.ToTable("GolfMembers");
                });

            modelBuilder.Entity("L00177784_CA2_GolfApp.Data.TeeTime", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Player1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Player2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Player3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Player4Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RoundDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoundHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundMinute")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("Player3Id");

                    b.HasIndex("Player4Id");

                    b.ToTable("TeeTimes");
                });

            modelBuilder.Entity("L00177784_CA2_GolfApp.Data.TeeTime", b =>
                {
                    b.HasOne("L00177784_CA2_GolfApp.Data.GolfMember", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("L00177784_CA2_GolfApp.Data.GolfMember", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("L00177784_CA2_GolfApp.Data.GolfMember", "Player3")
                        .WithMany()
                        .HasForeignKey("Player3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("L00177784_CA2_GolfApp.Data.GolfMember", "Player4")
                        .WithMany()
                        .HasForeignKey("Player4Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player1");

                    b.Navigation("Player2");

                    b.Navigation("Player3");

                    b.Navigation("Player4");
                });
#pragma warning restore 612, 618
        }
    }
}
