﻿// <auto-generated />
using Buy_And_Sell_House_Core_Webapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Buy_And_Sell_House_Core_Webapp.Migrations
{
    //Responsible for creating the databse schema and populating any seed data.
    [DbContext(typeof(Buy_And_Sell_House_Core_WebappContext))]
    [Migration("20191007112229_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Buy_And_Sell_House_Core_Webapp.Business.Buyer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuyerName");

                    b.Property<string>("BuyerPhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Buyer");
                });

            modelBuilder.Entity("Buy_And_Sell_House_Core_Webapp.Business.House", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HouseAddress");

                    b.Property<int>("HousePrice");

                    b.HasKey("Id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("Buy_And_Sell_House_Core_Webapp.Business.Seller", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HouseId");

                    b.Property<string>("SellerName");

                    b.Property<string>("SellerPhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("Buy_And_Sell_House_Core_Webapp.Business.Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuyerId");

                    b.Property<string>("HouseId");

                    b.HasKey("TransactionId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("HouseId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Buy_And_Sell_House_Core_Webapp.Business.Seller", b =>
                {
                    b.HasOne("Buy_And_Sell_House_Core_Webapp.Business.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId");
                });

            modelBuilder.Entity("Buy_And_Sell_House_Core_Webapp.Business.Transaction", b =>
                {
                    b.HasOne("Buy_And_Sell_House_Core_Webapp.Business.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("Buy_And_Sell_House_Core_Webapp.Business.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
