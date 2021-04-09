using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Data.SqlClient;

namespace PersonsDemoApp.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatIdNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RelativeId = table.Column<int>(type: "int", nullable: false),
                    RelationType = table.Column<int>(type: "int", nullable: false),
                    ReverseRelationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRelationships_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRelationships_PersonId",
                table: "PersonalRelationships",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NatIdNr",
                table: "Persons",
                column: "NatIdNr",
                unique: true);

            migrationBuilder.Sql(InsertPerson);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalRelationships");

            migrationBuilder.DropTable(
                name: "Persons");
        }

        private const string InsertPerson = @"
            CREATE PROCEDURE InsertPerson
            (
                @NatIdNr nvarchar(450),
                @Nationality nvarchar(max),
                @Email nvarchar(max),
                @Address nvarchar(max),
                @DateOfBirth datetime2,
                @DateOfDeath datetime2,
                @FirstName nvarchar(max),
                @LastName nvarchar(max),
                @Sex nvarchar(max)
            )
            AS
                IF EXISTS (SELECT * FROM Persons WHERE NatIdNr = @NatIdNr)
                BEGIN
                    UPDATE Persons 
                    SET 
                        NatIdNr = @NatIdNr, 
                        Nationality = @Nationality,
                        Email = @Email, 
                        Address = @Address,
                        DateOfBirth = @DateOfBirth, 
                        DateOfDeath = @DateOfDeath,
                        FirstName = @FirstName, 
                        LastName = @LastName,
                        Sex = @Sex
                    WHERE 
                        NatIdNr =  @NatIdNr
                END
                ELSE
                BEGIN
                   INSERT into Persons 
                   VALUES (@NatIdNr, @Nationality, @Email, @Address, @DateOfBirth, @DateOfDeath, @FirstName, @LastName, @Sex)
                END";
    }
}
