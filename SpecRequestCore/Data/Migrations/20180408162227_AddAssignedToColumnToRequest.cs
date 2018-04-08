using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SpecRequestCore.Data.Migrations
{
    public partial class AddAssignedToColumnToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReviewerId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReviewerId",
                table: "Requests",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_ReviewerId",
                table: "Requests",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_ReviewerId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ReviewerId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Requests");
        }
    }
}
