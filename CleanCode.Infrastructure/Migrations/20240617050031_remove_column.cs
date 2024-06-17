﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test_column",
                table: "data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test_column",
                table: "data",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
