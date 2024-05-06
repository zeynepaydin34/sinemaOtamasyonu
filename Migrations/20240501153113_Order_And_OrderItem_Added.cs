using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sinemaOtamasyonu.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderItemAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_Actors_ActorId",
                table: "Actor_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Movies_Movies_MovieId",
                table: "Actor_Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor_Movies",
                table: "Actor_Movies");

            migrationBuilder.RenameTable(
                name: "Actor_Movies",
                newName: "Actors_Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_Movies_MovieId",
                table: "Actors_Movies",
                newName: "IX_Actors_Movies_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Producers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors_Movies",
                table: "Actors_Movies",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actors_ActorId",
                table: "Actors_Movies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Movies_MovieId",
                table: "Actors_Movies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actors_ActorId",
                table: "Actors_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Movies_MovieId",
                table: "Actors_Movies");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors_Movies",
                table: "Actors_Movies");

            migrationBuilder.RenameTable(
                name: "Actors_Movies",
                newName: "Actor_Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_Movies_MovieId",
                table: "Actor_Movies",
                newName: "IX_Actor_Movies_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor_Movies",
                table: "Actor_Movies",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_Actors_ActorId",
                table: "Actor_Movies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Movies_Movies_MovieId",
                table: "Actor_Movies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
