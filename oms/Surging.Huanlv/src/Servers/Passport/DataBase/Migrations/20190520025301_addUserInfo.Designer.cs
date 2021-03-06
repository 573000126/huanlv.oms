﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBase.Migrations
{
    [DbContext(typeof(MysqlDbContext))]
    [Migration("20190520025301_addUserInfo")]
    partial class addUserInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataBase.Models.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Psw");

                    b.HasKey("Id");

                    b.ToTable("TestData");
                });

            modelBuilder.Entity("DataBase.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cellphone");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<int>("OemId");

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegisterTime");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataBase.Models.UserWxInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HeadImage")
                        .HasMaxLength(500);

                    b.Property<string>("NickName")
                        .HasMaxLength(100);

                    b.Property<string>("OpenId")
                        .HasMaxLength(100);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserWxInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
