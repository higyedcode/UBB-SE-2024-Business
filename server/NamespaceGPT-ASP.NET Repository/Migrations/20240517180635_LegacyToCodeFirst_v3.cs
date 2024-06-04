using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamespaceGPT_ASP.NET_Repository.Migrations
{
    /// <inheritdoc />
    public partial class LegacyToCodeFirst_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarketplaceId",
                table: "PriceDropAlerts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarketplaceId",
                table: "NewProductAlerts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserActivity_UserId",
                table: "UserActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ListingId",
                table: "Sale",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_UserId",
                table: "Sale",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceDropAlerts_MarketplaceId",
                table: "PriceDropAlerts",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceDropAlerts_ProductId",
                table: "PriceDropAlerts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceDropAlerts_UserId",
                table: "PriceDropAlerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewProductAlerts_MarketplaceId",
                table: "NewProductAlerts",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_NewProductAlerts_ProductId",
                table: "NewProductAlerts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_NewProductAlerts_UserId",
                table: "NewProductAlerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_MarketplaceId",
                table: "Listing",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ProductId",
                table: "Listing",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_ProductId",
                table: "FavouriteProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_UserId",
                table: "FavouriteProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BackInStockAlerts_MarketplaceId",
                table: "BackInStockAlerts",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BackInStockAlerts_ProductId",
                table: "BackInStockAlerts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BackInStockAlerts_UserId",
                table: "BackInStockAlerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdRecommendation_ListingId",
                table: "AdRecommendation",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdRecommendation_Listing_ListingId",
                table: "AdRecommendation",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BackInStockAlerts_AppUser_UserId",
                table: "BackInStockAlerts",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BackInStockAlerts_Marketplace_MarketplaceId",
                table: "BackInStockAlerts",
                column: "MarketplaceId",
                principalTable: "Marketplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BackInStockAlerts_Product_ProductId",
                table: "BackInStockAlerts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProduct_AppUser_UserId",
                table: "FavouriteProduct",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProduct_Product_ProductId",
                table: "FavouriteProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Marketplace_MarketplaceId",
                table: "Listing",
                column: "MarketplaceId",
                principalTable: "Marketplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Product_ProductId",
                table: "Listing",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductAlerts_AppUser_UserId",
                table: "NewProductAlerts",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductAlerts_Marketplace_MarketplaceId",
                table: "NewProductAlerts",
                column: "MarketplaceId",
                principalTable: "Marketplace",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductAlerts_Product_ProductId",
                table: "NewProductAlerts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDropAlerts_AppUser_UserId",
                table: "PriceDropAlerts",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDropAlerts_Marketplace_MarketplaceId",
                table: "PriceDropAlerts",
                column: "MarketplaceId",
                principalTable: "Marketplace",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDropAlerts_Product_ProductId",
                table: "PriceDropAlerts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AppUser_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Product_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AppUser_UserId",
                table: "Sale",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Listing_ListingId",
                table: "Sale",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivity_AppUser_UserId",
                table: "UserActivity",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdRecommendation_Listing_ListingId",
                table: "AdRecommendation");

            migrationBuilder.DropForeignKey(
                name: "FK_BackInStockAlerts_AppUser_UserId",
                table: "BackInStockAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_BackInStockAlerts_Marketplace_MarketplaceId",
                table: "BackInStockAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_BackInStockAlerts_Product_ProductId",
                table: "BackInStockAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProduct_AppUser_UserId",
                table: "FavouriteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProduct_Product_ProductId",
                table: "FavouriteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Marketplace_MarketplaceId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Product_ProductId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_NewProductAlerts_AppUser_UserId",
                table: "NewProductAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_NewProductAlerts_Marketplace_MarketplaceId",
                table: "NewProductAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_NewProductAlerts_Product_ProductId",
                table: "NewProductAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDropAlerts_AppUser_UserId",
                table: "PriceDropAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDropAlerts_Marketplace_MarketplaceId",
                table: "PriceDropAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDropAlerts_Product_ProductId",
                table: "PriceDropAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AppUser_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Product_ProductId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AppUser_UserId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Listing_ListingId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivity_AppUser_UserId",
                table: "UserActivity");

            migrationBuilder.DropIndex(
                name: "IX_UserActivity_UserId",
                table: "UserActivity");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ListingId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_UserId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Review_ProductId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_PriceDropAlerts_MarketplaceId",
                table: "PriceDropAlerts");

            migrationBuilder.DropIndex(
                name: "IX_PriceDropAlerts_ProductId",
                table: "PriceDropAlerts");

            migrationBuilder.DropIndex(
                name: "IX_PriceDropAlerts_UserId",
                table: "PriceDropAlerts");

            migrationBuilder.DropIndex(
                name: "IX_NewProductAlerts_MarketplaceId",
                table: "NewProductAlerts");

            migrationBuilder.DropIndex(
                name: "IX_NewProductAlerts_ProductId",
                table: "NewProductAlerts");

            migrationBuilder.DropIndex(
                name: "IX_NewProductAlerts_UserId",
                table: "NewProductAlerts");

            migrationBuilder.DropIndex(
                name: "IX_Listing_MarketplaceId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ProductId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteProduct_ProductId",
                table: "FavouriteProduct");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteProduct_UserId",
                table: "FavouriteProduct");

            migrationBuilder.DropIndex(
                name: "IX_BackInStockAlerts_MarketplaceId",
                table: "BackInStockAlerts");

            migrationBuilder.DropIndex(
                name: "IX_BackInStockAlerts_ProductId",
                table: "BackInStockAlerts");

            migrationBuilder.DropIndex(
                name: "IX_BackInStockAlerts_UserId",
                table: "BackInStockAlerts");

            migrationBuilder.DropIndex(
                name: "IX_AdRecommendation_ListingId",
                table: "AdRecommendation");

            migrationBuilder.DropColumn(
                name: "MarketplaceId",
                table: "PriceDropAlerts");

            migrationBuilder.DropColumn(
                name: "MarketplaceId",
                table: "NewProductAlerts");
        }
    }
}
