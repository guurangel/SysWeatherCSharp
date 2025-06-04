using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysWeatherCSharpp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MunicipiosC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroHabitantes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Clima = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Regiao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Altitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    AreaKm2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipiosC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OcorrenciasC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NivelRisco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MunicipioId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcorrenciasC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcorrenciasC_MunicipiosC_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "MunicipiosC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MunicipioId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosC_MunicipiosC_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "MunicipiosC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificacoesOcorrenciaC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    OcorrenciaId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacoesOcorrenciaC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacoesOcorrenciaC_OcorrenciasC_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "OcorrenciasC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificacoesOcorrenciaC_UsuariosC_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuariosC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificacoesOcorrenciaC_OcorrenciaId",
                table: "NotificacoesOcorrenciaC",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacoesOcorrenciaC_UsuarioId",
                table: "NotificacoesOcorrenciaC",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasC_MunicipioId",
                table: "OcorrenciasC",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosC_Cpf",
                table: "UsuariosC",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosC_Email",
                table: "UsuariosC",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosC_MunicipioId",
                table: "UsuariosC",
                column: "MunicipioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificacoesOcorrenciaC");

            migrationBuilder.DropTable(
                name: "OcorrenciasC");

            migrationBuilder.DropTable(
                name: "UsuariosC");

            migrationBuilder.DropTable(
                name: "MunicipiosC");
        }
    }
}
