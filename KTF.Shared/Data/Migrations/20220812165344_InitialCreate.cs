using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KTF.Shared.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Unit = table.Column<float>(type: "REAL", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    Minimum = table.Column<float>(type: "REAL", nullable: true),
                    Maximun = table.Column<float>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Creater = table.Column<string>(type: "TEXT", nullable: true),
                    Updater = table.Column<string>(type: "TEXT", nullable: true),
                    Machine = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Creater = table.Column<string>(type: "TEXT", nullable: true),
                    Updater = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScaleHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Line = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Unit = table.Column<float>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Minimum = table.Column<float>(type: "REAL", nullable: false),
                    Maximun = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Creater = table.Column<string>(type: "TEXT", nullable: true),
                    Updater = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaleHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScaleReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Line = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Creater = table.Column<string>(type: "TEXT", nullable: true),
                    Updater = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaleReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaplerHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Line = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CurrentCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsCancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Creater = table.Column<string>(type: "TEXT", nullable: true),
                    Updater = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaplerHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaplerReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Line = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Creater = table.Column<string>(type: "TEXT", nullable: true),
                    Updater = table.Column<string>(type: "TEXT", nullable: true),
                    Ok = table.Column<int>(type: "INTEGER", nullable: false),
                    Ng = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaplerReport", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Line_Created",
                table: "Line",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Created",
                table: "Machine",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_ScaleHistory_Created",
                table: "ScaleHistory",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_ScaleReport_Created",
                table: "ScaleReport",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_StaplerHistory_Created",
                table: "StaplerHistory",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_StaplerReport_Created",
                table: "StaplerReport",
                column: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "ScaleHistory");

            migrationBuilder.DropTable(
                name: "ScaleReport");

            migrationBuilder.DropTable(
                name: "StaplerHistory");

            migrationBuilder.DropTable(
                name: "StaplerReport");
        }
    }
}
