using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sparkdemo.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTableField_ValueField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "table_fields",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "table_fields");
        }
    }
}
