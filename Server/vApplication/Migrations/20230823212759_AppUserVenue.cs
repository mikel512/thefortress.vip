using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vApplication.Migrations
{
    public partial class AppUserVenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMessage",
                columns: table => new
                {
                    AdminMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "analytics",
                columns: table => new
                {
                    AnalyticsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__analytic__506974E39436EBE6", x => x.AnalyticsId);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalQueue",
                columns: table => new
                {
                    QueueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tour = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaylistEmbed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "CodeUsers",
                columns: table => new
                {
                    CodeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CodeUser__C6DE2C15B83FB2CB", x => x.CodeId);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    DateStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Upvotes = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Comment_pk", x => x.CommentId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "LinkType",
                columns: table => new
                {
                    LinkTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FaImgClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkType", x => x.LinkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TrustedCode",
                columns: table => new
                {
                    TrustedCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimesUsed = table.Column<int>(type: "int", nullable: false),
                    MaxTimesUsed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustedCode", x => x.TrustedCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketsLink = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MenuLink = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Hours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City_FK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.VenueId);
                    table.ForeignKey(
                        name: "FK_Venue_City",
                        column: x => x.City_FK,
                        principalTable: "City",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "EventConcert",
                columns: table => new
                {
                    EventConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Tickets = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Venue_FK = table.Column<int>(type: "int", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EventTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventCon__91322059EC10CB1A", x => x.EventConcertId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_EventConcert_Venue",
                        column: x => x.Venue_FK,
                        principalTable: "Venue",
                        principalColumn: "VenueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventConcert",
                table: "EventConcert",
                columns: new[] { "EventConcertId", "Venue_FK" });

            migrationBuilder.CreateIndex(
                name: "IX_EventConcert_Venue_FK",
                table: "EventConcert",
                column: "Venue_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Venue",
                table: "Venue",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_City_FK",
                table: "Venue",
                column: "City_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMessage");

            migrationBuilder.DropTable(
                name: "analytics");

            migrationBuilder.DropTable(
                name: "ApprovalQueue");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "CodeUsers");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "EventConcert");

            migrationBuilder.DropTable(
                name: "LinkType");

            migrationBuilder.DropTable(
                name: "TrustedCode");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
