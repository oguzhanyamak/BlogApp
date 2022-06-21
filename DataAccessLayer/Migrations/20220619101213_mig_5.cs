using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ContactStatus",
                table: "Contacts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Comments",
                newName: "BlogId");

            migrationBuilder.RenameColumn(
                name: "CommentStatus",
                table: "Comments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CommentID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogID",
                table: "Comments",
                newName: "IX_Comments_BlogId");

            migrationBuilder.RenameColumn(
                name: "CategoryStatus",
                table: "Categories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Blogs",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Blogs",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "BlogStatus",
                table: "Blogs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Blogs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryID",
                table: "Blogs",
                newName: "IX_Blogs_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.RenameColumn(
                name: "AuthorStatus",
                table: "Authors",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Authors",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Contacts",
                newName: "ContactStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactID");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comments",
                newName: "BlogID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Comments",
                newName: "CommentStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                newName: "IX_Comments_BlogID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Categories",
                newName: "CategoryStatus");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Blogs",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Blogs",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Blogs",
                newName: "BlogStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blogs",
                newName: "BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                newName: "IX_Blogs_AuthorID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Authors",
                newName: "AuthorStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "AuthorID");

            migrationBuilder.AddColumn<short>(
                name: "CategoryID",
                table: "Categories",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<short>(
                name: "CategoryID",
                table: "Blogs",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorID",
                table: "Blogs",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryID",
                table: "Blogs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
