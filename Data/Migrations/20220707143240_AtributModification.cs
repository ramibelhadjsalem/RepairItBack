using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairItBack.Data.Migrations
{
    public partial class AtributModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOf",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Commandes");

            migrationBuilder.RenameColumn(
                name: "AppareilType",
                table: "Commandes",
                newName: "deviceType");

            migrationBuilder.RenameColumn(
                name: "typeDeLivarison",
                table: "AspNetUsers",
                newName: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Commandes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Commandes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "AddressLarg",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AddressLong",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "CinFileUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MFFileUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Verifed",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "AddressLarg",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressLong",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CinFileUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MFFileUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Verifed",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "deviceType",
                table: "Commandes",
                newName: "AppareilType");

            migrationBuilder.RenameColumn(
                name: "Tasks",
                table: "AspNetUsers",
                newName: "typeDeLivarison");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOf",
                table: "Commandes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Commandes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
