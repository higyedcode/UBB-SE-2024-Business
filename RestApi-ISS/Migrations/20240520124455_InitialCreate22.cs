using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_ISS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "AdAccount",
               columns: table => new
               {
                   AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   NameOfCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   DomainOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   HeadquartersLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   AuthorisingInstituion = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AdAccount", x => x.AdAccountId);
               });

            migrationBuilder.CreateTable(
               name: "Influencer",
               columns: table => new
               {
                   InfluencerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   InfluencerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   FollowerCount = table.Column<int>(type: "int", nullable: false),
                   CollaborationPrice = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Influencer", x => x.InfluencerId);
               });

            migrationBuilder.CreateTable(
               name: "Campaign",
               columns: table => new
               {
                   CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Duration = table.Column<int>(type: "int", nullable: false),
                   AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                   table.ForeignKey(
                       name: "FK_Campaign_AdAccount_AdAccountId",
                       column: x => x.AdAccountId,
                       principalTable: "AdAccount",
                       principalColumn: "AdAccountId",
                       onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateTable(
               name: "Collaboration",
               columns: table => new
               {
                   CollaborationId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   CollaborationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Status = table.Column<bool>(type: "bit", nullable: false),
                   ContentRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   AdOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   CollaborationFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                   InfluencerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Collaboration", x => x.CollaborationId);
                   table.ForeignKey(
                       name: "FK_Collaboration_AdAccount_AdAccountId",
                       column: x => x.AdAccountId,
                       principalTable: "AdAccount",
                       principalColumn: "AdAccountId");
                   table.ForeignKey(
                       name: "FK_Collaboration_Influencer_InfluencerId",
                       column: x => x.InfluencerId,
                       principalTable: "Influencer",
                       principalColumn: "InfluencerId");
               });

            migrationBuilder.CreateTable(
               name: "Request",
               columns: table => new
               {
                   RequestId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   CollaborationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   AdOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ContentRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Compensation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   InfluencerAccept = table.Column<bool>(type: "bit", nullable: false),
                   AdAccountAccept = table.Column<bool>(type: "bit", nullable: false),
                   AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   InfluencerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Request", x => x.RequestId);
                   table.ForeignKey(
                       name: "FK_Request_AdAccount_AdAccountId",
                       column: x => x.AdAccountId,
                       principalTable: "AdAccount",
                       principalColumn: "AdAccountId",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Request_Influencer_InfluencerId",
                       column: x => x.InfluencerId,
                       principalTable: "Influencer",
                       principalColumn: "InfluencerId",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateTable(
               name: "AdSet",
               columns: table => new
               {
                   AdSetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   TargetAudience = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AdSet", x => x.AdSetId);
                   table.ForeignKey(
                       name: "FK_AdSet_AdAccount_AdAccountId",
                       column: x => x.AdAccountId,
                       principalTable: "AdAccount",
                       principalColumn: "AdAccountId",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AdSet_Campaign_CampaignId",
                       column: x => x.CampaignId,
                       principalTable: "Campaign",
                       principalColumn: "CampaignId");
               });

            migrationBuilder.CreateTable(
               name: "Ad",
               columns: table => new
               {
                   AdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   AdSetId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                   ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   WebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Ad", x => x.AdId);
                   table.ForeignKey(
                       name: "FK_Ad_AdAccount_AdAccountId",
                       column: x => x.AdAccountId,
                       principalTable: "AdAccount",
                       principalColumn: "AdAccountId",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Ad_AdSet_AdSetId",
                       column: x => x.AdSetId,
                       principalTable: "AdSet",
                       principalColumn: "AdSetId");
               });

            migrationBuilder.CreateIndex(
               name: "IX_Ad_AdAccountId",
               table: "Ad",
               column: "AdAccountId");

            migrationBuilder.CreateIndex(
               name: "IX_Ad_AdSetId",
               table: "Ad",
               column: "AdSetId");

            migrationBuilder.CreateIndex(
               name: "IX_AdSet_AdAccountId",
               table: "AdSet",
               column: "AdAccountId");

            migrationBuilder.CreateIndex(
               name: "IX_AdSet_CampaignId",
               table: "AdSet",
               column: "CampaignId");

            migrationBuilder.CreateIndex(
               name: "IX_Campaign_AdAccountId",
               table: "Campaign",
               column: "AdAccountId");

            migrationBuilder.CreateIndex(
               name: "IX_Collaboration_AdAccountId",
               table: "Collaboration",
               column: "AdAccountId");

            migrationBuilder.CreateIndex(
               name: "IX_Collaboration_InfluencerId",
               table: "Collaboration",
               column: "InfluencerId");

            migrationBuilder.CreateIndex(
               name: "IX_Request_AdAccountId",
               table: "Request",
               column: "AdAccountId");

            migrationBuilder.CreateIndex(
               name: "IX_Request_InfluencerId",
               table: "Request",
               column: "InfluencerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "Collaboration");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "AdSet");

            migrationBuilder.DropTable(
                name: "Influencer");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "AdAccount");
        }
    }
}
