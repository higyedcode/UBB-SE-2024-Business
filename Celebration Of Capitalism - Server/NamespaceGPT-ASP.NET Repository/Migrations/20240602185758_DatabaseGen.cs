using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NamespaceGPT_ASP.NET_Repository.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseGen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COCMarketplace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketplaceName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    WebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCMarketplace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COCProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attributes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COCUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpartacusAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartacusAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpartacusBusiness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LogoFileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    BannerShort = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerUsernames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaqIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartacusBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpartacusComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartacusComment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpartacusFAQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartacusFAQ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpartacusPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfLikes = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    CommentIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartacusPost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpartacusReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    AdminCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartacusReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COCListing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MarketplaceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCListing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCListing_COCMarketplace_MarketplaceId",
                        column: x => x.MarketplaceId,
                        principalTable: "COCMarketplace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCListing_COCProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "COCProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCBackInStockAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MarketplaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCBackInStockAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCBackInStockAlerts_COCMarketplace_MarketplaceId",
                        column: x => x.MarketplaceId,
                        principalTable: "COCMarketplace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCBackInStockAlerts_COCProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "COCProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCBackInStockAlerts_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCFavouriteProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCFavouriteProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCFavouriteProduct_COCProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "COCProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCFavouriteProduct_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCNewProductAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    COCMarketplaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCNewProductAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCNewProductAlerts_COCMarketplace_COCMarketplaceId",
                        column: x => x.COCMarketplaceId,
                        principalTable: "COCMarketplace",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COCNewProductAlerts_COCProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "COCProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCNewProductAlerts_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCPriceDropAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COCMarketplaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCPriceDropAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCPriceDropAlerts_COCMarketplace_COCMarketplaceId",
                        column: x => x.COCMarketplaceId,
                        principalTable: "COCMarketplace",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_COCPriceDropAlerts_COCProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "COCProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCPriceDropAlerts_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCReview_COCProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "COCProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCReview_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCUserActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCUserActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCUserActivity_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCAdRecommendation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCAdRecommendation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCAdRecommendation_COCListing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "COCListing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ListingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCSale_COCListing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "COCListing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCSale_COCUser_UserId",
                        column: x => x.UserId,
                        principalTable: "COCUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COCAdRecommendation_ListingId",
                table: "COCAdRecommendation",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_COCBackInStockAlerts_MarketplaceId",
                table: "COCBackInStockAlerts",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_COCBackInStockAlerts_ProductId",
                table: "COCBackInStockAlerts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_COCBackInStockAlerts_UserId",
                table: "COCBackInStockAlerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COCFavouriteProduct_ProductId",
                table: "COCFavouriteProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_COCFavouriteProduct_UserId",
                table: "COCFavouriteProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COCListing_MarketplaceId",
                table: "COCListing",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_COCListing_ProductId",
                table: "COCListing",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_COCNewProductAlerts_COCMarketplaceId",
                table: "COCNewProductAlerts",
                column: "COCMarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_COCNewProductAlerts_ProductId",
                table: "COCNewProductAlerts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_COCNewProductAlerts_UserId",
                table: "COCNewProductAlerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COCPriceDropAlerts_COCMarketplaceId",
                table: "COCPriceDropAlerts",
                column: "COCMarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_COCPriceDropAlerts_ProductId",
                table: "COCPriceDropAlerts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_COCPriceDropAlerts_UserId",
                table: "COCPriceDropAlerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COCReview_ProductId",
                table: "COCReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_COCReview_UserId",
                table: "COCReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COCSale_ListingId",
                table: "COCSale",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_COCSale_UserId",
                table: "COCSale",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_COCUserActivity_UserId",
                table: "COCUserActivity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COCAdRecommendation");

            migrationBuilder.DropTable(
                name: "COCBackInStockAlerts");

            migrationBuilder.DropTable(
                name: "COCFavouriteProduct");

            migrationBuilder.DropTable(
                name: "COCNewProductAlerts");

            migrationBuilder.DropTable(
                name: "COCPriceDropAlerts");

            migrationBuilder.DropTable(
                name: "COCReview");

            migrationBuilder.DropTable(
                name: "COCSale");

            migrationBuilder.DropTable(
                name: "COCUserActivity");

            migrationBuilder.DropTable(
                name: "SpartacusAccount");

            migrationBuilder.DropTable(
                name: "SpartacusBusiness");

            migrationBuilder.DropTable(
                name: "SpartacusComment");

            migrationBuilder.DropTable(
                name: "SpartacusFAQ");

            migrationBuilder.DropTable(
                name: "SpartacusPost");

            migrationBuilder.DropTable(
                name: "SpartacusReview");

            migrationBuilder.DropTable(
                name: "COCListing");

            migrationBuilder.DropTable(
                name: "COCUser");

            migrationBuilder.DropTable(
                name: "COCMarketplace");

            migrationBuilder.DropTable(
                name: "COCProduct");
        }
    }
}
