using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateFinder.Storage.Migrations
{
    /// <inheritdoc />
    public partial class idtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    ActivityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndoorOutdoor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "ActivityLevel", "Duration", "IndoorOutdoor", "Name" },
                values: new object[,]
                {
                    { 1, "High", 4.0, "Outdoor", "rock climbing" },
                    { 2, "High", 2.5, "Indoor", "indoor rock climbing" },
                    { 3, "Medium", 5.0, "Outdoor", "amusement park" },
                    { 4, "Medium", 2.0, "Indoor", "bowling" },
                    { 5, "Medium", 2.0, "Both", "mini golf" },
                    { 6, "Medium", 4.0, "Outdoor", "golf" },
                    { 7, "Medium", 2.0, "Outdoor", "driving range" },
                    { 8, "High", 2.0, "Indoor", "trampoline park" },
                    { 9, "Low", 3.5, "Both", "live music" },
                    { 10, "Medium", 3.5, "Outdoor", "zoo" },
                    { 11, "Medium", 2.5, "Both", "botanical garden" },
                    { 12, "Medium", 3.0, "Indoor", "museum" },
                    { 13, "Medium", 2.5, "Indoor", "art museum" },
                    { 14, "Medium", 2.0, "Indoor", "mall" },
                    { 15, "Medium", 1.5, "Indoor", "laser tag" },
                    { 16, "High", 2.5, "Indoor", "indoor scuba diving" },
                    { 17, "High", 1.5, "Indoor", "indoor skydiving" },
                    { 18, "Medium", 2.0, "Outdoor", "ice castle" },
                    { 19, "Low", 3.0, "Indoor", "play/musical" },
                    { 20, "Medium", 4.0, "Outdoor", "beach" },
                    { 21, "Medium", 2.0, "Indoor", "butterfly" },
                    { 22, "Low", 1.5, "Outdoor", "farmers market" },
                    { 23, "Low", 3.5, "Indoor", "movie" },
                    { 24, "Low", 3.5, "Outdoor", "drive in movie" },
                    { 25, "Low", 1.5, "Indoor", "arcade" },
                    { 26, "High", 1.5, "Both", "ice skating" },
                    { 27, "High", 3.0, "Outdoor", "mountain biking" },
                    { 28, "Medium", 1.5, "Indoor", "axe throwing" },
                    { 29, "Medium", 1.5, "Both", "archery" },
                    { 30, "Low", 1.0, "Indoor", "boba" },
                    { 31, "Low", 1.0, "Indoor", "ice cream" },
                    { 32, "Medium", 1.5, "Outdoor", "park" },
                    { 33, "Low", 1.5, "Outdoor", "christmas lights" },
                    { 34, "High", 1.5, "Both", "pickle ball" },
                    { 35, "High", 1.5, "Indoor", "raquetball" },
                    { 36, "Medium", 2.5, "Outdoor", "horseback riding" },
                    { 37, "High", 2.0, "Outdoor", "jetskiing" },
                    { 38, "High", 3.5, "Outdoor", "kayaking" },
                    { 39, "Low", 5.0, "Both", "road trip" },
                    { 40, "High", 4.0, "Outdoor", "skiing" },
                    { 41, "High", 3.0, "Outdoor", "paintballing" },
                    { 42, "High", 2.5, "Outdoor", "skydiving" },
                    { 43, "Low", 3.0, "Both", "concert" },
                    { 44, "Medium", 5.0, "Outdoor", "air show" },
                    { 45, "Low", 2.5, "Indoor", "symphony" },
                    { 46, "High", 3.5, "Outdoor", "hiking" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
