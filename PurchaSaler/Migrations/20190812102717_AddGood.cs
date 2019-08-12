using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaSaler.Migrations
{
    public partial class AddGood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shops_UserID",
                table: "Shops");

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodsName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    GoodsPhoto = table.Column<string>(nullable: true),
                    GoodsDescribe = table.Column<string>(nullable: true),
                    LikeIt = table.Column<int>(nullable: false),
                    Flag = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Sales = table.Column<int>(nullable: false),
                    ShopID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsID);
                    table.ForeignKey(
                        name: "FK_Goods_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserID",
                table: "Shops",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_ShopID",
                table: "Goods",
                column: "ShopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Shops_UserID",
                table: "Shops");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserID",
                table: "Shops",
                column: "UserID");
        }
    }
}
