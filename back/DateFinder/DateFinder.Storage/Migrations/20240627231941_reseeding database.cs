using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateFinder.Storage.Migrations
{
    /// <inheritdoc />
    public partial class reseedingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0deaf8f8-818f-47b3-a357-0e02d7a1557a"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("22dde74c-1637-4f56-a34c-6a8087a60c45"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("2303b8ae-f423-41dc-a049-936072092aea"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("28d66744-a6e1-4967-90a8-343306ef91ed"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("31f7e71f-2e93-45c0-8940-a849fe26b5f8"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("3509727f-34f8-46e3-bf78-ea712da01a54"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("37169b1b-3102-4e30-9d2f-a1a229316dcf"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("3bc973f5-f9a0-4cc2-808f-9c9eac359db6"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("41389edf-884d-4b77-920a-8fe449601b47"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("42f47a06-2557-4882-89ce-f14441aa0c6e"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("50cabfce-aced-4074-a61b-9a72f1fe7161"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("52d63045-4a1e-4130-8edd-925bcad5fb0f"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("58e74f56-1870-42e3-9634-d3c1623e6f5a"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("5b65fbc4-0854-4754-a842-f73110880e4c"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("5c564aec-13e5-48e9-bc33-4a63a0799d8a"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("6117c081-1226-4760-a1ed-840fa915175d"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("72226db9-1521-4953-9a09-ef4799a30ffd"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("805eb25c-6e2e-45bb-9952-f41038737c1f"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("86942b5b-33cd-40c7-8635-550c08284663"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("86a17ebc-92b0-4913-9dd3-984d823c128c"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("8da154d6-cefb-4533-836e-87e1efb011db"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("9730ce3a-a838-4348-92cf-1921bae78cb6"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("9ac14f97-58f5-4417-ab8b-3cc2d0960557"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("9fed3c73-618d-45db-9e26-68ec1373ea8d"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a5e7df70-ca1f-451c-8ddc-4779adc26a95"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a9419870-c228-4e66-b7ad-c7d85c5041e7"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("acda8474-dbb5-44b1-b476-07bd62ee2358"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("ad3d5f90-9e69-4080-b199-059e358c473f"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("b2d86f27-15fe-489e-80e4-9101ac6e59f5"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("bd368050-308a-449d-8df6-42d585287dc9"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("bf2ba458-f787-4e56-93f5-84e9f40e1a92"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("bfc65bb0-2355-4223-b9b1-4a1e06a4e6c8"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("c364471f-6bcb-4b92-86cd-ce94b98b000e"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("c4019fb0-6e8e-4f2c-bbec-3b36842dc2ae"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("c88cad38-382b-4bfb-9eb7-f804075105f7"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("c92edbe9-8efb-4b8b-96fc-fb7d92ea8fdb"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("cf096883-244e-4156-b05c-1a18c4d91fea"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("cf5cc53b-cdd6-4452-8f55-bcd45a213800"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("d24047c3-0982-4f71-8999-0fff60cb748c"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("d718e815-da67-4b4a-a0f5-dcf80632efbc"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("db19893d-0848-4fe6-99c4-d0d1b9e43226"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("dd0772ae-a650-4c1b-b9b7-db8b511d3229"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("de68b7be-3552-4b3b-b585-7bb00323a228"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("e3e3b06d-21ab-49dd-844a-0de1800700b6"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("ea4e9c67-03e5-4837-a26d-670faf29e511"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("efa2ddf5-de74-4ca3-b026-612be0f8e688"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("f6167de2-119a-4598-97b0-82ce061295ae"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("fc2a60a4-1927-4384-aaa8-50416d011f9a"));

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "ActivityLevel", "Description", "Duration", "IndoorOutdoor", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { new Guid("01b6e4c6-721c-4bd9-8078-491ad1499015"), "Low", null, 3.0, "Indoor", "play/musical", null, null },
                    { new Guid("0731f1f8-33f2-4cbb-bd27-689b4bb0dfdd"), "Medium", null, 1.5, "Indoor", "axe throwing", null, null },
                    { new Guid("09375188-bc7e-46f6-b79c-69973ed965ce"), "Medium", null, 2.0, "Both", "mini golf", null, null },
                    { new Guid("0a1bb980-2605-4aaa-aa6c-f7d0f7c8799a"), "Medium", null, 1.5, "Outdoor", "park", null, null },
                    { new Guid("0d7f1045-ea6f-4e2d-af80-6eb72b020efa"), "Low", null, 1.0, "Indoor", "boba", null, null },
                    { new Guid("0e0a8c58-9080-474f-ad5e-2456a68ba451"), "High", null, 2.5, "Indoor", "indoor rock climbing", null, null },
                    { new Guid("0ee32973-8e62-4d78-8f92-08c1c8812808"), "Medium", null, 3.5, "Outdoor", "zoo", null, null },
                    { new Guid("120fe3fb-7d35-4443-b2a7-c18a335bfb93"), "Low", null, 3.5, "Outdoor", "drive in movie", null, null },
                    { new Guid("13319364-6b92-4756-980f-8f1ff4a915fd"), "High", null, 3.0, "Outdoor", "paintballing", null, null },
                    { new Guid("13f03c1f-f4ab-48c3-9a4f-3e6ed8aff629"), "Medium", null, 2.0, "Indoor", "bowling", null, null },
                    { new Guid("15de9d4a-a980-40de-abde-cd4409267e99"), "High", null, 4.0, "Outdoor", "snowboarding", null, null },
                    { new Guid("167d453c-b15d-42b0-85a2-78e74277041c"), "High", null, 2.5, "Outdoor", "skydiving", null, null },
                    { new Guid("1b84cba9-8cc3-4e00-8d8b-2307043bffb6"), "High", null, 3.5, "Outdoor", "kayaking", null, null },
                    { new Guid("289dc090-3a99-4bee-b75b-b7eec822d656"), "Low", null, 1.0, "Indoor", "ice cream", null, null },
                    { new Guid("2f82285e-78a6-44d2-b364-9bbb85489731"), "High", null, 2.5, "Indoor", "indoor scuba diving", null, null },
                    { new Guid("44c075fb-9d44-450d-98e2-c7be6ff0f6d9"), "Low", null, 1.5, "Outdoor", "christmas lights/lights", null, null },
                    { new Guid("44dec13d-95b5-42f9-97c4-f15d06a997f1"), "High", null, 1.5, "Both", "pickle ball", null, null },
                    { new Guid("47f4a54c-57e6-40cc-951e-ab60cd6a371d"), "Medium", null, 2.0, "Outdoor", "driving range", null, null },
                    { new Guid("49aa8435-b305-42fb-b4e4-1fac1b21ce49"), "High", null, 4.0, "Outdoor", "rock climbing", null, null },
                    { new Guid("528f28a6-eedc-4e79-b13f-23f4278b82b2"), "Low", null, 1.5, "Indoor", "arcade", null, null },
                    { new Guid("5741d76d-c752-4382-b790-c5685dcc3bef"), "High", null, 1.5, "Both", "ice skating", null, null },
                    { new Guid("5799c3f7-c0cc-4849-9b38-51144b999b3e"), "Low", null, 2.5, "Indoor", "symphony", null, null },
                    { new Guid("5c0d93c7-25a1-4730-9544-1f4294a14f93"), "High", null, 3.5, "Outdoor", "hiking", null, null },
                    { new Guid("61575de3-85bf-425e-ba8d-d0a90daf785b"), "Medium", null, 4.0, "Outdoor", "beach", null, null },
                    { new Guid("6193ab6c-6d28-4581-bc2d-20fb9cf9bba5"), "Medium", null, 2.0, "Indoor", "mall", null, null },
                    { new Guid("6326fb39-983d-4ad1-b612-5b81ffe29ff7"), "Medium", null, 2.5, "Indoor", "art museum", null, null },
                    { new Guid("6662013e-4ad8-48da-a7a7-3ce2919e88d8"), "Medium", null, 4.0, "Outdoor", "golf", null, null },
                    { new Guid("6d8cc3dd-0a72-4848-89eb-9445927a3b9d"), "High", null, 2.0, "Indoor", "trampoline park", null, null },
                    { new Guid("70559920-5d4f-4a73-b24c-8b39ad662ecd"), "Medium", null, 2.5, "Both", "botanical garden", null, null },
                    { new Guid("748db71d-a136-42f8-9417-4970374dbd78"), "Medium", null, 1.5, "Both", "archery", null, null },
                    { new Guid("74e7a7a2-267f-43ff-8666-8337313aaea1"), "Low", null, 3.0, "Both", "concert", null, null },
                    { new Guid("8010126d-3885-454f-ad5c-00a4ad400ec3"), "Medium", null, 5.0, "Outdoor", "air show", null, null },
                    { new Guid("865da27f-a05a-4dfe-bbc2-02c7adb0f111"), "Medium", null, 2.0, "Outdoor", "ice castle", null, null },
                    { new Guid("8a865142-da0d-4e3f-b46e-f84e6378c976"), "Low", null, 2.5, "Indoor", "ballet", null, null },
                    { new Guid("8b36a925-1c29-44ad-b6db-ccacd4ed98b9"), "Medium", null, 2.0, "Indoor", "butterfly", null, null },
                    { new Guid("8df752e8-d994-466b-81e5-13762e950567"), "High", null, 2.0, "Outdoor", "jetskiing", null, null },
                    { new Guid("a0c64e67-1885-4ee7-b658-29f389af8ae0"), "Medium", null, 1.5, "Indoor", "laser tag", null, null },
                    { new Guid("a12e5f6a-48d8-4ba8-9c61-dfe6f304fee6"), "Low", null, 3.5, "Both", "live music", null, null },
                    { new Guid("a246ed1a-1b53-4c1b-b7ff-aa4cfd876bae"), "Low", null, 1.5, "Outdoor", "farmers market", null, null },
                    { new Guid("a329dde3-58dc-4c09-9c3b-75547f6a62c1"), "Low", null, 3.5, "Indoor", "movie", null, null },
                    { new Guid("a83606f9-a23b-4b47-bed0-d92676ab42df"), "Medium", null, 3.0, "Indoor", "museum", null, null },
                    { new Guid("a9479af8-1195-4078-b533-4920387a4cc4"), "High", null, 4.0, "Outdoor", "skiing", null, null },
                    { new Guid("a96e99d9-60eb-4f11-927a-7c578c95212d"), "High", null, 1.5, "Indoor", "raquetball", null, null },
                    { new Guid("c5f20399-f37d-482b-9f9f-351a71c2fab5"), "Low", null, 5.0, "Both", "road trip", null, null },
                    { new Guid("cd6ecef7-7764-44c1-9a52-c222423fdf7f"), "High", null, 3.0, "Outdoor", "mountain biking", null, null },
                    { new Guid("d5e1d6e7-eeb6-4ed2-a233-16a18f7381a3"), "High", null, 1.5, "Indoor", "indoor skydiving", null, null },
                    { new Guid("fd12f861-87b4-4700-8a8d-051bbf7c409c"), "Medium", null, 2.5, "Outdoor", "horseback riding", null, null },
                    { new Guid("febc60ec-32e5-4da9-a241-3d4cf24f35ea"), "Medium", null, 5.0, "Outdoor", "amusement park", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("01b6e4c6-721c-4bd9-8078-491ad1499015"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0731f1f8-33f2-4cbb-bd27-689b4bb0dfdd"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("09375188-bc7e-46f6-b79c-69973ed965ce"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0a1bb980-2605-4aaa-aa6c-f7d0f7c8799a"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0d7f1045-ea6f-4e2d-af80-6eb72b020efa"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0e0a8c58-9080-474f-ad5e-2456a68ba451"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0ee32973-8e62-4d78-8f92-08c1c8812808"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("120fe3fb-7d35-4443-b2a7-c18a335bfb93"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("13319364-6b92-4756-980f-8f1ff4a915fd"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("13f03c1f-f4ab-48c3-9a4f-3e6ed8aff629"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("15de9d4a-a980-40de-abde-cd4409267e99"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("167d453c-b15d-42b0-85a2-78e74277041c"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("1b84cba9-8cc3-4e00-8d8b-2307043bffb6"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("289dc090-3a99-4bee-b75b-b7eec822d656"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("2f82285e-78a6-44d2-b364-9bbb85489731"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("44c075fb-9d44-450d-98e2-c7be6ff0f6d9"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("44dec13d-95b5-42f9-97c4-f15d06a997f1"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("47f4a54c-57e6-40cc-951e-ab60cd6a371d"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("49aa8435-b305-42fb-b4e4-1fac1b21ce49"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("528f28a6-eedc-4e79-b13f-23f4278b82b2"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("5741d76d-c752-4382-b790-c5685dcc3bef"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("5799c3f7-c0cc-4849-9b38-51144b999b3e"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("5c0d93c7-25a1-4730-9544-1f4294a14f93"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("61575de3-85bf-425e-ba8d-d0a90daf785b"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("6193ab6c-6d28-4581-bc2d-20fb9cf9bba5"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("6326fb39-983d-4ad1-b612-5b81ffe29ff7"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("6662013e-4ad8-48da-a7a7-3ce2919e88d8"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("6d8cc3dd-0a72-4848-89eb-9445927a3b9d"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("70559920-5d4f-4a73-b24c-8b39ad662ecd"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("748db71d-a136-42f8-9417-4970374dbd78"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("74e7a7a2-267f-43ff-8666-8337313aaea1"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("8010126d-3885-454f-ad5c-00a4ad400ec3"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("865da27f-a05a-4dfe-bbc2-02c7adb0f111"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("8a865142-da0d-4e3f-b46e-f84e6378c976"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("8b36a925-1c29-44ad-b6db-ccacd4ed98b9"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("8df752e8-d994-466b-81e5-13762e950567"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a0c64e67-1885-4ee7-b658-29f389af8ae0"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a12e5f6a-48d8-4ba8-9c61-dfe6f304fee6"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a246ed1a-1b53-4c1b-b7ff-aa4cfd876bae"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a329dde3-58dc-4c09-9c3b-75547f6a62c1"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a83606f9-a23b-4b47-bed0-d92676ab42df"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a9479af8-1195-4078-b533-4920387a4cc4"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("a96e99d9-60eb-4f11-927a-7c578c95212d"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("c5f20399-f37d-482b-9f9f-351a71c2fab5"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("cd6ecef7-7764-44c1-9a52-c222423fdf7f"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("d5e1d6e7-eeb6-4ed2-a233-16a18f7381a3"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("fd12f861-87b4-4700-8a8d-051bbf7c409c"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("febc60ec-32e5-4da9-a241-3d4cf24f35ea"));

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "ActivityLevel", "Description", "Duration", "IndoorOutdoor", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { new Guid("0deaf8f8-818f-47b3-a357-0e02d7a1557a"), "High", null, 1.5, "Indoor", "indoor skydiving", null, null },
                    { new Guid("22dde74c-1637-4f56-a34c-6a8087a60c45"), "High", null, 2.0, "Outdoor", "jetskiing", null, null },
                    { new Guid("2303b8ae-f423-41dc-a049-936072092aea"), "High", null, 3.0, "Outdoor", "paintballing", null, null },
                    { new Guid("28d66744-a6e1-4967-90a8-343306ef91ed"), "Low", null, 1.5, "Outdoor", "farmers market", null, null },
                    { new Guid("31f7e71f-2e93-45c0-8940-a849fe26b5f8"), "Low", null, 1.5, "Outdoor", "christmas lights/lights", null, null },
                    { new Guid("3509727f-34f8-46e3-bf78-ea712da01a54"), "High", null, 4.0, "Outdoor", "snowboarding", null, null },
                    { new Guid("37169b1b-3102-4e30-9d2f-a1a229316dcf"), "High", null, 3.5, "Outdoor", "kayaking", null, null },
                    { new Guid("3bc973f5-f9a0-4cc2-808f-9c9eac359db6"), "Low", null, 3.5, "Indoor", "movie", null, null },
                    { new Guid("41389edf-884d-4b77-920a-8fe449601b47"), "Low", null, 2.5, "Indoor", "symphony", null, null },
                    { new Guid("42f47a06-2557-4882-89ce-f14441aa0c6e"), "Medium", null, 2.5, "Indoor", "art museum", null, null },
                    { new Guid("50cabfce-aced-4074-a61b-9a72f1fe7161"), "Low", null, 3.5, "Outdoor", "drive in movie", null, null },
                    { new Guid("52d63045-4a1e-4130-8edd-925bcad5fb0f"), "Medium", null, 1.5, "Indoor", "laser tag", null, null },
                    { new Guid("58e74f56-1870-42e3-9634-d3c1623e6f5a"), "High", null, 2.5, "Outdoor", "skydiving", null, null },
                    { new Guid("5b65fbc4-0854-4754-a842-f73110880e4c"), "Low", null, 3.0, "Both", "concert", null, null },
                    { new Guid("5c564aec-13e5-48e9-bc33-4a63a0799d8a"), "Medium", null, 2.0, "Indoor", "bowling", null, null },
                    { new Guid("6117c081-1226-4760-a1ed-840fa915175d"), "Medium", null, 5.0, "Outdoor", "air show", null, null },
                    { new Guid("72226db9-1521-4953-9a09-ef4799a30ffd"), "Medium", null, 2.5, "Outdoor", "horseback riding", null, null },
                    { new Guid("805eb25c-6e2e-45bb-9952-f41038737c1f"), "Medium", null, 2.0, "Outdoor", "driving range", null, null },
                    { new Guid("86942b5b-33cd-40c7-8635-550c08284663"), "Low", null, 3.0, "Indoor", "play/musical", null, null },
                    { new Guid("86a17ebc-92b0-4913-9dd3-984d823c128c"), "Medium", null, 4.0, "Outdoor", "golf", null, null },
                    { new Guid("8da154d6-cefb-4533-836e-87e1efb011db"), "High", null, 3.5, "Outdoor", "hiking", null, null },
                    { new Guid("9730ce3a-a838-4348-92cf-1921bae78cb6"), "Medium", null, 2.5, "Both", "botanical garden", null, null },
                    { new Guid("9ac14f97-58f5-4417-ab8b-3cc2d0960557"), "Low", null, 2.5, "Indoor", "ballet", null, null },
                    { new Guid("9fed3c73-618d-45db-9e26-68ec1373ea8d"), "High", null, 3.0, "Outdoor", "mountain biking", null, null },
                    { new Guid("a5e7df70-ca1f-451c-8ddc-4779adc26a95"), "Medium", null, 1.5, "Indoor", "axe throwing", null, null },
                    { new Guid("a9419870-c228-4e66-b7ad-c7d85c5041e7"), "Medium", null, 3.5, "Outdoor", "zoo", null, null },
                    { new Guid("acda8474-dbb5-44b1-b476-07bd62ee2358"), "Medium", null, 1.5, "Outdoor", "park", null, null },
                    { new Guid("ad3d5f90-9e69-4080-b199-059e358c473f"), "High", null, 2.5, "Indoor", "indoor rock climbing", null, null },
                    { new Guid("b2d86f27-15fe-489e-80e4-9101ac6e59f5"), "Low", null, 1.0, "Indoor", "ice cream", null, null },
                    { new Guid("bd368050-308a-449d-8df6-42d585287dc9"), "Medium", null, 5.0, "Outdoor", "amusement park", null, null },
                    { new Guid("bf2ba458-f787-4e56-93f5-84e9f40e1a92"), "High", null, 1.5, "Both", "ice skating", null, null },
                    { new Guid("bfc65bb0-2355-4223-b9b1-4a1e06a4e6c8"), "High", null, 4.0, "Outdoor", "rock climbing", null, null },
                    { new Guid("c364471f-6bcb-4b92-86cd-ce94b98b000e"), "Low", null, 1.5, "Indoor", "arcade", null, null },
                    { new Guid("c4019fb0-6e8e-4f2c-bbec-3b36842dc2ae"), "Medium", null, 2.0, "Indoor", "butterfly", null, null },
                    { new Guid("c88cad38-382b-4bfb-9eb7-f804075105f7"), "Medium", null, 3.0, "Indoor", "museum", null, null },
                    { new Guid("c92edbe9-8efb-4b8b-96fc-fb7d92ea8fdb"), "Low", null, 1.0, "Indoor", "boba", null, null },
                    { new Guid("cf096883-244e-4156-b05c-1a18c4d91fea"), "Medium", null, 2.0, "Outdoor", "ice castle", null, null },
                    { new Guid("cf5cc53b-cdd6-4452-8f55-bcd45a213800"), "Medium", null, 2.0, "Indoor", "mall", null, null },
                    { new Guid("d24047c3-0982-4f71-8999-0fff60cb748c"), "High", null, 2.5, "Indoor", "indoor scuba diving", null, null },
                    { new Guid("d718e815-da67-4b4a-a0f5-dcf80632efbc"), "Low", null, 3.5, "Both", "live music", null, null },
                    { new Guid("db19893d-0848-4fe6-99c4-d0d1b9e43226"), "Low", null, 5.0, "Both", "road trip", null, null },
                    { new Guid("dd0772ae-a650-4c1b-b9b7-db8b511d3229"), "Medium", null, 2.0, "Both", "mini golf", null, null },
                    { new Guid("de68b7be-3552-4b3b-b585-7bb00323a228"), "Medium", null, 1.5, "Both", "archery", null, null },
                    { new Guid("e3e3b06d-21ab-49dd-844a-0de1800700b6"), "High", null, 2.0, "Indoor", "trampoline park", null, null },
                    { new Guid("ea4e9c67-03e5-4837-a26d-670faf29e511"), "High", null, 4.0, "Outdoor", "skiing", null, null },
                    { new Guid("efa2ddf5-de74-4ca3-b026-612be0f8e688"), "High", null, 1.5, "Both", "pickle ball", null, null },
                    { new Guid("f6167de2-119a-4598-97b0-82ce061295ae"), "High", null, 1.5, "Indoor", "raquetball", null, null },
                    { new Guid("fc2a60a4-1927-4384-aaa8-50416d011f9a"), "Medium", null, 4.0, "Outdoor", "beach", null, null }
                });
        }
    }
}
