using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace A2_updated_p1.Migrations
{
    /// <inheritdoc />
    public partial class AddTopicTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { "action-movies", "movies", "Action Movies" },
                    { "europe-travel", "travel", "Europe Travel" },
                    { "football", "sports", "Football" },
                    { "history-events", "history", "Historical Events" },
                    { "java", "coding", "Java" },
                    { "mental-health", "health", "Mental Health" },
                    { "python", "coding", "Python" },
                    { "rock-music", "music", "Rock Music" },
                    { "smartphones", "gadgets", "Smartphones" },
                    { "space", "science", "Space Exploration" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "action-movies");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "europe-travel");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "football");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "history-events");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "java");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "mental-health");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "python");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "rock-music");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "smartphones");

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "TopicId",
                keyValue: "space");
        }
    }
}
