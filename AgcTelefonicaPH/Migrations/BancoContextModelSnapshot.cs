﻿// <auto-generated />
using AgcTelefonicaPH.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgcTelefonicaPH.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgcTelefonicaPH.Models.ContactoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactoN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("AgcTelefonicaPH.Models.ObraModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("DatFim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatIni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idCliente");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("AgcTelefonicaPH.Models.ObraModel", b =>
                {
                    b.HasOne("AgcTelefonicaPH.Models.ContactoModel", "Contacto")
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");
                });
#pragma warning restore 612, 618
        }
    }
}
