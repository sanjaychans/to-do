using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.DAL.Migrations
{
    public partial class Added_SortIndex_LookupItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "SortIndex",
                table: "Lookups",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortIndex",
                table: "Lookups");
        }
    }
}
