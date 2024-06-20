using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateFinder.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    ActivityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndoorOutdoor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Date",
                columns: new[] { "Id", "ActivityLevel", "Description", "Duration", "IndoorOutdoor", "MyProperty", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { new Guid("105c536f-8a19-4a6e-8cfa-58923bd90f5a"), "Medium", null, "2", "Indoor", 0, "mall", null, null },
                    { new Guid("12845b63-fa0e-4b23-813a-3d380ec3e485"), "High", null, "2.5", "Indoor", 0, "indoor rock climbing", null, null },
                    { new Guid("2498dc33-6a8e-455a-8548-17e231a6c361"), "High", null, "1.5", "Indoor", 0, "boxing class", null, null },
                    { new Guid("28974797-f54f-449a-abb5-24f6a8128a7f"), "High", null, "1.5", "Both", 0, "swimming", null, null },
                    { new Guid("28bd2630-21de-408d-abf7-12987037ad03"), "Low", null, "2", "Indoor", 0, "aquarium", null, null },
                    { new Guid("2cd94e1c-40c2-4577-990d-67749ef1a92f"), "High", null, "2", "Indoor", 0, "trampoline park", null, null },
                    { new Guid("36502af6-1d1f-462d-b82d-3c9f613291b2"), "High", null, "1.5", "Indoor", 0, "indoor skydiving", null, null },
                    { new Guid("38f5bedd-6fcd-4104-9612-24fac6e65ae1"), "Medium", null, "2.5", "Both", 0, "botanical garden", null, null },
                    { new Guid("3c95dde6-2d54-40cc-ae0e-e581e99ef221"), "High", null, "1.5", "Indoor", 0, "dance class", null, null },
                    { new Guid("436f7fac-2ba4-4448-84d0-ee60170860bb"), "Low", null, "3.5", "Indoor", 0, "movie", null, null },
                    { new Guid("4397ca2c-7aeb-44a6-a1ff-d13b16243117"), "High", null, "1.5", "Indoor", 0, "roller skating", null, null },
                    { new Guid("5c8cd1a7-b032-434a-844b-6bb6f42b557b"), "Medium", null, "1.5", "Outdoor", 0, "park", null, null },
                    { new Guid("5dd4f244-6b34-4c34-8858-4b14e223a6f3"), "Low", null, "1", "Indoor", 0, "ice cream", null, null },
                    { new Guid("5de5544e-7493-4f5f-808c-d40026d220d7"), "High", null, "1.5", "Both", 0, "ice skating", null, null },
                    { new Guid("67030e81-fbe2-4000-8a5b-fa559f740e58"), "Low", null, "3.5", "Both", 0, "live music", null, null },
                    { new Guid("70d797b3-0362-4372-b082-c59de71ef49d"), "Low", null, "1.5", "Outdoor", 0, "christmas lights/lights", null, null },
                    { new Guid("7688da2f-353b-407b-81c1-d68c563e1ded"), "Low", null, "1.5", "Indoor", 0, "arcade", null, null },
                    { new Guid("87e12bda-c19d-46c1-8760-65723db72070"), "Medium", null, "2", "Both", 0, "mini golf", null, null },
                    { new Guid("8ccbd251-da62-4477-a498-f191c7efc900"), "Medium", null, "4", "Outdoor", 0, "beach", null, null },
                    { new Guid("9155e81f-cffa-4163-a88f-1e946eef1893"), "Medium", null, "2", "Outdoor", 0, "ice castle", null, null },
                    { new Guid("99b8d6af-1c34-4985-a0d8-d6d42ab21dc2"), "Medium", null, "3", "Indoor", 0, "museum", null, null },
                    { new Guid("9a010a9f-937e-4b3d-9f49-7978d84b329b"), "Medium", null, "2", "Outdoor", 0, "driving range", null, null },
                    { new Guid("a34ebccc-80c9-48f9-8fae-397f5d3eeb19"), "Medium", null, "2.5", "Indoor", 0, "art museum", null, null },
                    { new Guid("a609ab72-edce-4942-8931-e00b25b3c125"), "High", null, "5", "Outdoor", 0, "skiing", null, null },
                    { new Guid("a7017a4d-b86d-4350-98ad-058551bf1045"), "Medium", null, "2.5", "Outdoor", 0, "horseback riding", null, null },
                    { new Guid("ac22767e-2b38-4c93-b5c8-d17a6e8ee6e1"), "High", null, "4", "Outdoor", 0, "rock climbing", null, null },
                    { new Guid("b2990da4-e60f-4e42-b466-214927b583af"), "High", null, "2", "Indoor", 0, "cooking class", null, null },
                    { new Guid("b70d8c3f-d17e-45e3-8d2a-f24580730f5c"), "Medium", null, "4", "Outdoor", 0, "golf", null, null },
                    { new Guid("b75be1ed-d65f-4e79-8cfc-08db4dbab62c"), "Low", null, "3", "Indoor", 0, "play/musical", null, null },
                    { new Guid("bbbdd4c2-ae88-4077-a229-5d71f2003338"), "High", null, "2.5", "Indoor", 0, "indoor scuba diving", null, null },
                    { new Guid("bcc161d7-e999-4442-ba79-5c63365054f0"), "High", null, "2", "Outdoor", 0, "tubing hill", null, null },
                    { new Guid("be6e1ff8-aaf6-4b39-8d6c-0610d4182594"), "Low", null, "1", "Indoor", 0, "boba", null, null },
                    { new Guid("c551e3c7-cd8a-475d-8951-4b6edaac6ec3"), "Medium", null, "1.5", "Both", 0, "archery", null, null },
                    { new Guid("c85d6c33-4782-4ad8-99be-bace4a80fee3"), "Low", null, "3.5", "Outdoor", 0, "drive in movie", null, null },
                    { new Guid("ca16b378-cf25-4e8b-8fdc-8bb137555b59"), "High", null, "2", "Indoor", 0, "swing dancing", null, null },
                    { new Guid("d0d7e7e2-391d-4567-9ffd-e7f89a414b02"), "Medium", null, "5", "Outdoor", 0, "amusement park", null, null },
                    { new Guid("d5a66a77-c4ba-4edc-aec3-fce30483520d"), "Low", null, "2", "Indoor", 0, "karaoke", null, null },
                    { new Guid("d744d5db-235d-4978-b2c8-5233bc36ab52"), "High", null, "1.5", "Both", 0, "pickle ball", null, null },
                    { new Guid("dfac533c-e79f-45fd-8dce-6d7157d6bded"), "Medium", null, "3.5", "Outdoor", 0, "zoo", null, null },
                    { new Guid("dff9b5b5-9bc3-4fc4-b36c-d43c4b03417f"), "Medium", null, "1.5", "Indoor", 0, "axe throwing", null, null },
                    { new Guid("e7f5c0e6-8960-4fd9-8ac7-b51cb370b487"), "High", null, "1.5", "Indoor", 0, "raquetball", null, null },
                    { new Guid("e812751d-a952-40f2-bb0e-17216080e236"), "Low", null, "1.5", "Outdoor", 0, "farmers market", null, null },
                    { new Guid("ec62a070-b65c-4d06-9a21-3ffb43dd0349"), "Low", null, "1.5", "Indoor", 0, "thrift", null, null },
                    { new Guid("ee7f8da9-08d4-4bac-8477-47cf4a09d5ec"), "Low", null, "1.5", "Indoor", 0, "nickelcade", null, null },
                    { new Guid("f4007407-6a14-42d5-913b-25ba088ba232"), "High", null, "3", "Outdoor", 0, "mountain biking", null, null },
                    { new Guid("f4e2ab78-5ecf-4b93-8b49-c646829ea885"), "Medium", null, "2", "Indoor", 0, "bowling", null, null },
                    { new Guid("f70870b1-5ef2-4cc0-bc7a-7926a8bfc8b4"), "Medium", null, "1.5", "Indoor", 0, "laser tag", null, null },
                    { new Guid("f9d3d807-0707-4594-af18-dccf376d498e"), "Medium", null, "2", "Indoor", 0, "butterfly", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Date");
        }
    }
}
