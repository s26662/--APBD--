using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cwiczenie_6.App.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingForAllTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "elzbieta.nowak@clinic.pl", "Elżbieta", "Nowak" },
                    { 2, "tomasz.kowalski@clinic.pl", "Tomasz", "Kowalski" },
                    { 3, "michal.wisniewski@clinic.pl", "Michał", "Wiśniewski" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Silny lek przeciwbólowy", "Ketonal", "NLPZ" },
                    { 2, "Na przeziębienie", "Fervex", "Leki OTC" },
                    { 3, "Na nadciśnienie", "Propranolol", "Beta-bloker" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1989, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarzyna", "Zielińska" },
                    { 2, new DateTime(1992, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paweł", "Adamski" },
                    { 3, new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcin", "Szymański" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "2x dziennie po posiłku", 50 },
                    { 1, 3, "Tylko w razie bólu", 25 },
                    { 2, 1, "1 saszetka wieczorem", 1 },
                    { 3, 2, "1 rano na czczo", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
