﻿// <auto-generated />
using System;
using GatewaysManager.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GatewaysManager.Migrations
{
    [DbContext(typeof(GatewaysManagerContext))]
    [Migration("20200610074821_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GatewaysManager.Models.Database.Gateway", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IPv4");

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.ToTable("Gateways");
                });

            modelBuilder.Entity("GatewaysManager.Models.Database.Peripheral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateCreated");

                    b.Property<Guid>("GatewayId");

                    b.Property<int>("Status");

                    b.Property<int>("UID");

                    b.Property<string>("Vendor");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId");

                    b.ToTable("Peripherals");
                });

            modelBuilder.Entity("GatewaysManager.Models.Database.Peripheral", b =>
                {
                    b.HasOne("GatewaysManager.Models.Database.Gateway", "Gateway")
                        .WithMany("Peripherals")
                        .HasForeignKey("GatewayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}