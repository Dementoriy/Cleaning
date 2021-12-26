using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningDLL.Migrations
{
    public partial class CommentToOrderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Order",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Order");
        }
    }
}
