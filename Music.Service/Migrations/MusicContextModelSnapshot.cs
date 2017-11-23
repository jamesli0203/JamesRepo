﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Music.Service.Models;
using System;

namespace Music.Service.Migrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Music.Service.Models.Album", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ArtistId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("YearReleases");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album","dbo");
                });

            modelBuilder.Entity("Music.Service.Models.Artist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Artist","dbo");
                });

            modelBuilder.Entity("Music.Service.Models.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AlbumId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Track");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song","dbo");
                });

            modelBuilder.Entity("Music.Service.Models.Album", b =>
                {
                    b.HasOne("Music.Service.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Music.Service.Models.Song", b =>
                {
                    b.HasOne("Music.Service.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
