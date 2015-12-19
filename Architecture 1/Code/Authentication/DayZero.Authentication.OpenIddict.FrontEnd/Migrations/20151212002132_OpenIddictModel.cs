using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DayZero.Authentication.OpenIddict.FrontEnd.Migrations
{
    public partial class OpenIddictModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //    table: "AspNetRoleClaims");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //    table: "AspNetUserClaims");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //    table: "AspNetUserLogins");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //    table: "AspNetUserRoles");

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    LogoutRedirectUri = table.Column<string>(nullable: true),
                    RedirectUri = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserLogins",
            //    nullable: false);

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserClaims",
            //    nullable: false);

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetRoleClaims",
            //    nullable: false);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //    table: "AspNetUserRoles",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //    table: "AspNetRoleClaims");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //    table: "AspNetUserClaims");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //    table: "AspNetUserLogins");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //    table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Application");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserLogins",
            //    nullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserClaims",
            //    nullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetRoleClaims",
            //    nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //    table: "AspNetUserRoles",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
