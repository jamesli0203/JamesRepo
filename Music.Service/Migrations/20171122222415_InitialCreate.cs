using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Music.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Artist",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<long>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    YearReleases = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "dbo",
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumId = table.Column<long>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Track = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "dbo",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                schema: "dbo",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                schema: "dbo",
                table: "Song",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Album",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Artist",
                schema: "dbo");
        }
    }
}
