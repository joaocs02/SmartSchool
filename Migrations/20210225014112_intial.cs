using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    alunoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeAluno = table.Column<string>(type: "TEXT", nullable: true),
                    SobreNomeAluno = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.alunoId);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    professorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeProfessor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.professorID);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    disciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    discricaoDisciplina = table.Column<string>(type: "TEXT", nullable: true),
                    professorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.disciplinaId);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_professorId",
                        column: x => x.professorId,
                        principalTable: "Professores",
                        principalColumn: "professorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    alunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    disciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => new { x.alunoId, x.disciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_alunoId",
                        column: x => x.alunoId,
                        principalTable: "Alunos",
                        principalColumn: "alunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_disciplinaId",
                        column: x => x.disciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "disciplinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "alunoId", "NomeAluno", "SobreNomeAluno", "Telefone" },
                values: new object[] { 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "professorID", "nomeProfessor" },
                values: new object[] { 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "professorID", "nomeProfessor" },
                values: new object[] { 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "professorID", "nomeProfessor" },
                values: new object[] { 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "professorID", "nomeProfessor" },
                values: new object[] { 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "professorID", "nomeProfessor" },
                values: new object[] { 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "disciplinaId", "discricaoDisciplina", "professorId" },
                values: new object[] { 1, "Matemática", 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "disciplinaId", "discricaoDisciplina", "professorId" },
                values: new object[] { 2, "Física", 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "disciplinaId", "discricaoDisciplina", "professorId" },
                values: new object[] { 3, "Português", 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "disciplinaId", "discricaoDisciplina", "professorId" },
                values: new object[] { 4, "Inglês", 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "disciplinaId", "discricaoDisciplina", "professorId" },
                values: new object[] { 5, "Programação", 5 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_disciplinaId",
                table: "AlunoDisciplinas",
                column: "disciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_professorId",
                table: "Disciplinas",
                column: "professorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
