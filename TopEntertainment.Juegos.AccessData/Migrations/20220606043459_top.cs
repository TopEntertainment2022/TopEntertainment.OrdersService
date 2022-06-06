using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopEntertainment.Ordenes.AccessData.Migrations
{
    public partial class top : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompraDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<float>(type: "real", maxLength: 20, nullable: false),
                    Importe = table.Column<float>(type: "real", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraDetalles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDetalles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", maxLength: 45, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "date", nullable: false),
                    Comprobante = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Importe = table.Column<float>(type: "real", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_CompraDetalles_Id",
                        column: x => x.Id,
                        principalTable: "CompraDetalles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", maxLength: 45, nullable: false),
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carritos_EstadoDetalles_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "EstadoDetalles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegoCarrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoID = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegoCarrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuegoCarrito_Carritos_CarritoID",
                        column: x => x.CarritoID,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoDetalles",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "EstadoDetalles",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_EstadoID",
                table: "Carritos",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoCarrito_CarritoID",
                table: "JuegoCarrito",
                column: "CarritoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "JuegoCarrito");

            migrationBuilder.DropTable(
                name: "CompraDetalles");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "EstadoDetalles");
        }
    }
}
