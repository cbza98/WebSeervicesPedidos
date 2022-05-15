﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSUSPedido.Helpers;

namespace WebSUSPedido.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210522205451_CopTitoDemo")]
    partial class CopTitoDemo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSUSPedido.Models.Login.OPE_USUARIO", b =>
                {
                    b.Property<string>("CODIGO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ADMINISTRADOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CAJERO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODIGO_EMPRESA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CONTRASENA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ESTADO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FECHA_CREACION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FECHA_MODIFICACION")
                        .HasColumnType("datetime2");

                    b.Property<string>("IMAGEN1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOMBRE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA17")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA18")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA19")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA21")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA22")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA23")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA24")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA25")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA26")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA27")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA28")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA29")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA30")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA31")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA32")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA33")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA34")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA35")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REFERENCIA9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SUPERUSUARIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_CAMBIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_CREACION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_MODIFICACION")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CODIGO");

                    b.ToTable("OPE_USUARIO");
                });

            modelBuilder.Entity("WebSUSPedido.Models.Login.OPE_USUARIO", b =>
                {
                    b.OwnsMany("WebSUSPedido.Models.Login.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("OPE_USUARIOCODIGO")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("OPE_USUARIOCODIGO");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("OPE_USUARIOCODIGO");
                        });

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
