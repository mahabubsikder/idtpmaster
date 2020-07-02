using Microsoft.EntityFrameworkCore.Migrations;

namespace IDTPDomainModel.Migrations
{
    public partial class addedSecretSaltToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BBRefId",
                table: "FinancialInstitution",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionLicenseNumber",
                table: "FinancialInstitution",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionType",
                table: "FinancialInstitution",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SwiftCode",
                table: "FinancialInstitution",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VatId",
                table: "FinancialInstitution",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecretSalt",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BBRefId",
                table: "FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "InstitutionLicenseNumber",
                table: "FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "InstitutionType",
                table: "FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "SwiftCode",
                table: "FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "VatId",
                table: "FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "SecretSalt",
                table: "AspNetUsers");
        }
    }
}
