﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sorteador.DAL;

namespace Sorteador.DAL.Migrations
{
    [DbContext(typeof(SorteadorContext))]
    partial class SorteadorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sorteador.DAL.Participante", b =>
                {
                    b.Property<int>("ParticipanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipanteId");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("Sorteador.DAL.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantidadeVencedoresMaioresPontos")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeVencedoresMenoresPontos")
                        .HasColumnType("int");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("Sorteador.DAL.Sorteio", b =>
                {
                    b.Property<int>("SorteioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataEncerramento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("SorteioId");

                    b.HasIndex("SalaId");

                    b.ToTable("Sorteios");
                });

            modelBuilder.Entity("Sorteador.DAL.SorteioDetalhe", b =>
                {
                    b.Property<int>("SorteioDetalheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataParticipacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnderecoIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ParticipacaoValida")
                        .HasColumnType("bit");

                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.Property<int>("SorteioId")
                        .HasColumnType("int");

                    b.HasKey("SorteioDetalheId");

                    b.HasIndex("ParticipanteId");

                    b.HasIndex("SorteioId");

                    b.ToTable("SorteioDetalhes");
                });

            modelBuilder.Entity("Sorteador.DAL.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Sorteador.DAL.Sorteio", b =>
                {
                    b.HasOne("Sorteador.DAL.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Sorteador.DAL.SorteioDetalhe", b =>
                {
                    b.HasOne("Sorteador.DAL.Participante", "Participante")
                        .WithMany()
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sorteador.DAL.Sorteio", "Sorteio")
                        .WithMany("Participacoes")
                        .HasForeignKey("SorteioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participante");

                    b.Navigation("Sorteio");
                });

            modelBuilder.Entity("Sorteador.DAL.Sorteio", b =>
                {
                    b.Navigation("Participacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
