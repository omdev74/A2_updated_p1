using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace A2_updated_p1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "FAQId", "Answer", "CategoryId", "Question", "TopicId" },
                values: new object[,]
                {
                    { 1, "Java is a programming language...", "coding", "What is Java?", "java" },
                    { 2, "Python is a versatile programming language...", "coding", "Tell me about Python.", "python" },
                    { 3, "Historical events are significant occurrences...", "history", "What are historical events?", "history-events" },
                    { 4, "Smartphones are handheld devices that combine...", "gadgets", "How do smartphones work?", "smartphones" },
                    { 5, "Space exploration involves the discovery and exploration...", "science", "What is space exploration?", "space" },
                    { 6, "Europe offers a variety of beautiful destinations including...", "travel", "Best places to visit in Europe?", "europe-travel" },
                    { 7, "Action movies are known for their thrilling...", "movies", "Must-watch action movies?", "action-movies" },
                    { 8, "Maintaining mental health involves practices like...", "health", "How to maintain mental health?", "mental-health" },
                    { 9, "Football is a popular sport played between two teams...", "sports", "Football rules and regulations.", "football" },
                    { 10, "Rock music has been shaped by iconic bands like...", "music", "Influential rock music bands.", "rock-music" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "FAQId",
                keyValue: 10);
        }
    }
}
