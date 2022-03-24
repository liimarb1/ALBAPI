using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class FuncSquad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Squads_SquadId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SquadId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Funcionarios");

            migrationBuilder.CreateTable(
                name: "FuncionariosSquads",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false),
                    SquadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosSquads", x => new { x.FuncionarioId, x.SquadId });
                    table.ForeignKey(
                        name: "FK_FuncionariosSquads_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosSquads_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeReal = table.Column<string>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gestores_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosSquads_SquadId",
                table: "FuncionariosSquads",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_FuncionarioId",
                table: "Gestores",
                column: "FuncionarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionariosSquads");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.AddColumn<int>(
                name: "SquadId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SquadId",
                table: "Funcionarios",
                column: "SquadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Squads_SquadId",
                table: "Funcionarios",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
