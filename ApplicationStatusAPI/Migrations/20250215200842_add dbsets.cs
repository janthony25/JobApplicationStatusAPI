using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class adddbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubmissionStatus",
                table: "SubmissionStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Source",
                table: "Source");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStatus",
                table: "ApplicationStatus");

            migrationBuilder.RenameTable(
                name: "SubmissionStatus",
                newName: "SubmissionStatuses");

            migrationBuilder.RenameTable(
                name: "Source",
                newName: "Sources");

            migrationBuilder.RenameTable(
                name: "ApplicationStatus",
                newName: "ApplicationStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubmissionStatuses",
                table: "SubmissionStatuses",
                column: "SubmissionStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sources",
                table: "Sources",
                column: "SourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStatuses",
                table: "ApplicationStatuses",
                column: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_ApplicationStatusId",
                table: "JobApplications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "ApplicationStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Sources_SourceId",
                table: "JobApplications",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "SourceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_SubmissionStatuses_SubmissionStatusId",
                table: "JobApplications",
                column: "SubmissionStatusId",
                principalTable: "SubmissionStatuses",
                principalColumn: "SubmissionStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Sources_SourceId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_SubmissionStatuses_SubmissionStatusId",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubmissionStatuses",
                table: "SubmissionStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sources",
                table: "Sources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStatuses",
                table: "ApplicationStatuses");

            migrationBuilder.RenameTable(
                name: "SubmissionStatuses",
                newName: "SubmissionStatus");

            migrationBuilder.RenameTable(
                name: "Sources",
                newName: "Source");

            migrationBuilder.RenameTable(
                name: "ApplicationStatuses",
                newName: "ApplicationStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubmissionStatus",
                table: "SubmissionStatus",
                column: "SubmissionStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Source",
                table: "Source",
                column: "SourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStatus",
                table: "ApplicationStatus",
                column: "ApplicationStatusId");

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
    }
}
