using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaSaler.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Good",
                columns: table => new
                {
                    GoodID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShopID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    GoodTitle = table.Column<string>(nullable: true),
                    GoodPhoto = table.Column<string>(nullable: true),
                    GoodDescribe = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: true),
                    Quality = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good", x => x.GoodID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Good");
        }
    }
}
