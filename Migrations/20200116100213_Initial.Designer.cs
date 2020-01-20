﻿// <auto-generated />
using System;
using BillBucket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillBucket.Migrations
{
    [DbContext(typeof(BillBucketContext))]
    [Migration("20200116100213_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BillBucket.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoSiret")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("NoTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c47638a4-4647-4128-a4bc-cfba3d9e9998"),
                            Adresse = "265 RUE PIERRE JEAN-BAPTISTE 59002 Lille",
                            Mail = "societeproxiad@proxiad.fr",
                            NoSiret = "A127EBHYULIDU1",
                            NoTel = "0322387458",
                            Nom = "Proxiad"
                        });
                });

            modelBuilder.Entity("BillBucket.Models.Facture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReglement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<Guid>("IdClient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NoFacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.ToTable("Factures");

                    b.HasData(
                        new
                        {
                            Id = new Guid("25ea78f2-54ad-4291-b302-2be6bc1ee824"),
                            DateEmission = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000),
                            DateReglement = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007),
                            Description = "Achat de deux esclaves chez IB Formation",
                            IdClient = new Guid("c47638a4-4647-4128-a4bc-cfba3d9e9998"),
                            NoFacture = 1
                        });
                });

            modelBuilder.Entity("BillBucket.Models.Prestation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdFacture")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdFacture");

                    b.ToTable("Prestations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("746667bd-097a-4ff1-8a3b-b5d43445453f"),
                            Description = "Nous dressons vos poulets d'entreprises. Ils ressortiront de chez nous en sachant abboyer, danser la polka et remplir vos fonctions de RH",
                            IdFacture = new Guid("25ea78f2-54ad-4291-b302-2be6bc1ee824"),
                            Montant = 2700.0,
                            Nom = "Dressage de poulet"
                        },
                        new
                        {
                            Id = new Guid("932cc920-e77e-4da8-989e-6ed0f900dfe2"),
                            Description = "Nous vous fournissons l'élite des tireurs pour éliminer les forces de recrutement concurrentes. Pas cher du tout pour la qualité de la prestation",
                            IdFacture = new Guid("25ea78f2-54ad-4291-b302-2be6bc1ee824"),
                            Montant = 50.0,
                            Nom = "Location de chasseurs de prime"
                        });
                });

            modelBuilder.Entity("BillBucket.Models.Facture", b =>
                {
                    b.HasOne("BillBucket.Models.Client", "Client")
                        .WithMany("Factures")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BillBucket.Models.Prestation", b =>
                {
                    b.HasOne("BillBucket.Models.Facture", "Facture")
                        .WithMany("Prestations")
                        .HasForeignKey("IdFacture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}