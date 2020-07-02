using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDTPDomainModel.Migrations
{
    public partial class AddedMasterToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    TokenSalt = table.Column<string>(nullable: true),
                    TokenExpiryDate = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterTokenDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    MasterTokenId = table.Column<int>(nullable: false),
                    AllowedIpOrWebsite = table.Column<string>(nullable: true),
                    ApiCallerType = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTokenDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterTokenDetails_MasterTokens_MasterTokenId",
                        column: x => x.MasterTokenId,
                        principalTable: "MasterTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterTokenDetails_MasterTokenId",
                table: "MasterTokenDetails",
                column: "MasterTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTokens_UserId",
                table: "MasterTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterTokenDetails");

            migrationBuilder.DropTable(
                name: "MasterTokens");
        }
    }
}
