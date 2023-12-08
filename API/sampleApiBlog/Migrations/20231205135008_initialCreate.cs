using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sampleApiBlog.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLOGS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLGTITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BLGCONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BLGTHUMB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BLGUSRID = table.Column<long>(type: "bigint", nullable: false),
                    CREATEDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMTCONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMTNICKNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USRNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USRPASS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USRAVATAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BLOGS");

            migrationBuilder.DropTable(
                name: "COMMENTS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
