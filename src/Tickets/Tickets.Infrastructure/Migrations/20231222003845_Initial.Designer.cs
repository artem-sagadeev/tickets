﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tickets.Infrastructure;

#nullable disable

namespace Tickets.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231222003845_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tickets.Domain.Entities.TicketType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid")
                        .HasColumnName("event_id");

                    b.Property<int>("MaxCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_count");

                    b.Property<DateTime>("SalesEndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sales_end_date");

                    b.Property<DateTime>("SalesStartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sales_start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_ticket_types");

                    b.ToTable("ticket_types", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
