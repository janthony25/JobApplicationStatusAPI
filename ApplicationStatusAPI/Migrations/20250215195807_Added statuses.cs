using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedstatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatusId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubmissionStatusId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    ApplicationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.ApplicationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.SourceId);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionStatus",
                columns: table => new
                {
                    SubmissionStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionStatus", x => x.SubmissionStatusId);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "ApplicationStatusId", "ApplicationStatusName" },
                values: new object[,]
                {
                    { 1, "Waiting for reply" },
                    { 2, "Being considered" },
                    { 3, "Closed" }
                });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: 1,
                columns: new[] { "ApplicationStatusId", "SourceId", "SubmissionStatusId" },
                values: new object[] { 3, 1, 2 });

            migrationBuilder.InsertData(
                table: "Source",
                columns: new[] { "SourceId", "SourceName" },
                values: new object[] { 1, "Seek" });

            migrationBuilder.InsertData(
                table: "SubmissionStatus",
                columns: new[] { "SubmissionStatusId", "SubmissionStatusName" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Sent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ApplicationStatusId",
                table: "JobApplications",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_SourceId",
                table: "JobApplications",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_SubmissionStatusId",
                table: "JobApplications",
                column: "SubmissionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_ApplicationStatus_ApplicationStatusId",
                table: "JobApplications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "ApplicationStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Source_SourceId",
                table: "JobApplications",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "SourceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_SubmissionStatus_SubmissionStatusId",
                table: "JobApplications",
                column: "SubmissionStatusId",
                principalTable: "SubmissionStatus",
                principalColumn: "SubmissionStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_ApplicationStatus_ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Source_SourceId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_SubmissionStatus_SubmissionStatusId",
                table: "JobApplications");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "SubmissionStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_SourceId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_SubmissionStatusId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "SubmissionStatusId",
                table: "JobApplications");
        }
    }
}
