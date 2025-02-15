using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedjob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "JobApplicationId", "CompanyName", "DateEdited", "DateSubmitted", "JobLink", "JobTitle", "LocationId" },
                values: new object[] { 1, "BidFood Limited", null, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.seek.co.nz/junior-.net-developer-jobs/in-All-Auckland?jobId=80539744&type=promoted", "Software Developer", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: 1);
        }
    }
}
