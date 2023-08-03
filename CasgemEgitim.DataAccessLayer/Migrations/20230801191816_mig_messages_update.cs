using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasgemEgitim.DataAccessLayer.Migrations
{
    public partial class mig_messages_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SenderID",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverID",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Teachers_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "Teachers",
                principalColumn: "TeachertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Teachers_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "Teachers",
                principalColumn: "TeachertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teachers_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teachers_SenderID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderID",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "SenderID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
