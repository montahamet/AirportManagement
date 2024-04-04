using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migAnnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassangersId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_MyPlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassangersId",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassangersId",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "MyPlaneId",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_MyPlaneId",
                table: "Flights",
                newName: "IX_Flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "Passengers",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PassangersPassportNumber",
                table: "FlightPassenger",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "PassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassangersPassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassangersPassportNumber",
                table: "FlightPassenger",
                column: "PassangersPassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassangersPassportNumber",
                table: "FlightPassenger",
                column: "PassangersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassangersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassangersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "PassangersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "MyPlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                newName: "IX_Flights_MyPlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PassangersId",
                table: "FlightPassenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassangersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassangersId",
                table: "FlightPassenger",
                column: "PassangersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassangersId",
                table: "FlightPassenger",
                column: "PassangersId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_MyPlaneId",
                table: "Flights",
                column: "MyPlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
