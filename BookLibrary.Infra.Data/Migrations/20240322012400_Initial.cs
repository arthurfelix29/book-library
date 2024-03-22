using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibrary.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bookCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bookType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    total_copies = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    copies_in_use = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    isbn = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    author_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                    table.ForeignKey(
                        name: "FK_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_bookCategory_category_id",
                        column: x => x.category_id,
                        principalTable: "bookCategory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_book_bookType_type_id",
                        column: x => x.type_id,
                        principalTable: "bookType",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, "Jane", "Austen" },
                    { 2, "Harper", "Lee" },
                    { 3, "J.D.", "Salinger" },
                    { 4, "F. Scott", "Fitzgerald" },
                    { 5, "Paulo", "Coelho" },
                    { 6, "Markus", "Zusak" },
                    { 7, "C.S.", "Lewis" },
                    { 8, "Dan", "Brown" },
                    { 9, "John", "Steinbeck" },
                    { 10, "Douglas", "Adams" },
                    { 11, "Herman", "Melville" }
                });

            migrationBuilder.InsertData(
                table: "bookCategory",
                columns: new[] { "id", "description" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Non-Fiction" },
                    { 3, "Biography" },
                    { 4, "Mystery" },
                    { 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "bookType",
                columns: new[] { "id", "description" },
                values: new object[,]
                {
                    { 1, "Hardcover" },
                    { 2, "Paperback" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "id", "author_id", "category_id", "copies_in_use", "isbn", "title", "total_copies", "type_id" },
                values: new object[,]
                {
                    { 1, 1, 1, 80, "1234567891", "Pride and Prejudice", 100, 1 },
                    { 2, 2, 1, 65, "1234567892", "To Kill a Mockingbird", 75, 2 },
                    { 3, 3, 1, 45, "1234567893", "The Catcher in the Rye", 50, 1 },
                    { 4, 4, 2, 22, "1234567894", "The Great Gatsby", 50, 1 },
                    { 5, 5, 3, 35, "1234567895", "The Alchemist", 50, 1 },
                    { 6, 6, 4, 11, "1234567896", "The Book Thief", 75, 1 },
                    { 7, 7, 5, 14, "1234567897", "The Chronicles of Narnia", 100, 2 },
                    { 8, 8, 5, 40, "1234567898", "The Da Vinci Code", 50, 2 },
                    { 9, 9, 1, 35, "1234567899", "The Grapes of Wrath", 50, 1 },
                    { 10, 10, 2, 35, "1234567900", "The Hitchhiker's Guide to the Galaxy", 50, 2 },
                    { 11, 11, 1, 8, "8901234567", "Moby-Dick", 30, 1 }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "id", "author_id", "category_id", "isbn", "title", "total_copies", "type_id" },
                values: new object[] { 12, 2, 2, "9012345678", "To Kill a Mockingbird", 20, 2 });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "id", "author_id", "category_id", "copies_in_use", "isbn", "title", "total_copies", "type_id" },
                values: new object[] { 13, 3, 2, 1, "0123456789", "The Catcher in the Rye", 10, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_book_author_id",
                table: "book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_category_id",
                table: "book",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_type_id",
                table: "book",
                column: "type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "bookCategory");

            migrationBuilder.DropTable(
                name: "bookType");
        }
    }
}
