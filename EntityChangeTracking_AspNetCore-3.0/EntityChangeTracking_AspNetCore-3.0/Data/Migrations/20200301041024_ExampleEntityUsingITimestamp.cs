using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityChangeTracking_AspNetCore_3._0.Data.Migrations
{
    public partial class ExampleEntityUsingITimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Example",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    EditedDateTime = table.Column<DateTime>(nullable: true),
                    EditedBy = table.Column<string>(nullable: true),
                    FieldA = table.Column<string>(nullable: true),
                    FieldB = table.Column<string>(nullable: true),
                    FieldC = table.Column<string>(nullable: true),
                    FieldD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Example");
        }
    }
}
