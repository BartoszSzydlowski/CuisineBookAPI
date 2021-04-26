using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Migrations
{
	public partial class CorrectingFoodDbModel : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CreationDate",
				table: "Food");

			migrationBuilder.DropColumn(
				name: "ModificationDate",
				table: "Food");

			migrationBuilder.DropColumn(
				name: "ModifiedBy",
				table: "Food");

			migrationBuilder.RenameColumn(
				name: "Name",
				table: "Food",
				newName: "Title");

			migrationBuilder.AlterColumn<DateTime>(
				name: "Created",
				table: "Food",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<int>(
				name: "CalorificValue",
				table: "Food",
				type: "int",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AddColumn<string>(
				name: "CreatedBy",
				table: "Food",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "LastModified",
				table: "Food",
				type: "datetime2",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "LastModifiedBy",
				table: "Food",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "UserId",
				table: "Food",
				type: "nvarchar(450)",
				maxLength: 450,
				nullable: false,
				defaultValue: "");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CreatedBy",
				table: "Food");

			migrationBuilder.DropColumn(
				name: "LastModified",
				table: "Food");

			migrationBuilder.DropColumn(
				name: "LastModifiedBy",
				table: "Food");

			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Food");

			migrationBuilder.RenameColumn(
				name: "Title",
				table: "Food",
				newName: "Name");

			migrationBuilder.AlterColumn<string>(
				name: "Created",
				table: "Food",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<string>(
				name: "CalorificValue",
				table: "Food",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AddColumn<DateTime>(
				name: "CreationDate",
				table: "Food",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "ModificationDate",
				table: "Food",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "ModifiedBy",
				table: "Food",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}
	}
}