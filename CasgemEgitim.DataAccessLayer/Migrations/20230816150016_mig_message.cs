using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasgemEgitim.DataAccessLayer.Migrations
{
    public partial class mig_message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Students_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Students_SenderID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teachers_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teachers_SenderID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Messages",
                newName: "TeachertId1");

            migrationBuilder.RenameColumn(
                name: "ReceiverID",
                table: "Messages",
                newName: "TeachertId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                newName: "IX_Messages_TeachertId1");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                newName: "IX_Messages_TeachertId");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StudentId",
                table: "Messages",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StudentId1",
                table: "Messages",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Students_StudentId",
                table: "Messages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Students_StudentId1",
                table: "Messages",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Teachers_TeachertId",
                table: "Messages",
                column: "TeachertId",
                principalTable: "Teachers",
                principalColumn: "TeachertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Teachers_TeachertId1",
                table: "Messages",
                column: "TeachertId1",
                principalTable: "Teachers",
                principalColumn: "TeachertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Students_StudentId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Students_StudentId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teachers_TeachertId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Teachers_TeachertId1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_StudentId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_StudentId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "TeachertId1",
                table: "Messages",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "TeachertId",
                table: "Messages",
                newName: "ReceiverID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_TeachertId1",
                table: "Messages",
                newName: "IX_Messages_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_TeachertId",
                table: "Messages",
                newName: "IX_Messages_ReceiverID");

            migrationBuilder.AddColumn<bool>(
                name: "MessageStatus",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Students_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Students_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "Students",
                principalColumn: "StudentId");

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
    }
}
