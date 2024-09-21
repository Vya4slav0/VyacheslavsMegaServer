using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VyacheslavsMegaServer.Migrations
{
    /// <inheritdoc />
    public partial class EditContactsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MainPageData_MainPageId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Contacts_ContactId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MainPageId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MainPageId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Contacts",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionLarge",
                table: "Contacts",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowContact",
                table: "Contacts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4bc75a9-ca48-45aa-a3f2-2ea5886ce303",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dc140be-3b1a-4077-9247-927be5ec7b5e", "AQAAAAIAAYagAAAAEHF1X+sTY6FbBycEx4Hnp2Spk2MsEv28ZbsoW+VQBznWVGnRub8gp0ljRghxPo4bSQ==", "773641d3-6950-4968-b39c-713c2265367b" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "DescriptionLarge", "ShowContact" },
                values: new object[] { "Царь и бог этого сервера", "", true });

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Contacts_ContactId",
                table: "Links",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Contacts_ContactId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "DescriptionLarge",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ShowContact",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Links",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Contacts",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<int>(
                name: "MainPageId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4bc75a9-ca48-45aa-a3f2-2ea5886ce303",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cee506bf-58dd-48c7-8e3f-fe90f1a87b4f", "AQAAAAIAAYagAAAAEOXql5qz393LYy/E7zOP4a+PzKhYG9d3EuuEoECV9sQ/xFB/K2k3XWjfbhqnrxvwLg==", "01db8b5e-bd4e-411d-a2fa-a0c6db39b1cf" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "MainPageId" },
                values: new object[] { "Царь и бог сего сервера", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MainPageId",
                table: "Contacts",
                column: "MainPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MainPageData_MainPageId",
                table: "Contacts",
                column: "MainPageId",
                principalTable: "MainPageData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Contacts_ContactId",
                table: "Links",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
