using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStore.Migrations
{
    public partial class addShortDescriptToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescript",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescript",
                table: "Products");
        }
    }
}
