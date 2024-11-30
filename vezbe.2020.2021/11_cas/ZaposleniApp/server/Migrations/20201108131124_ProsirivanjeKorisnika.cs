using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class ProsirivanjeKorisnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumZaposlenja",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Informacije",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interesovanja",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Obrazovanje",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PoslednjaAktivnost",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RadnaPozicija",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tim",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    GlavnaSlika = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AppUserId",
                table: "Photo",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DatumZaposlenja",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Informacije",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Interesovanja",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Obrazovanje",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PoslednjaAktivnost",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RadnaPozicija",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tim",
                table: "Users");
        }
    }
}
