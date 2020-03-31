using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeSuperHeroesPrueba.Migrations
{
    public partial class firstConexion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 50, nullable: false),
                    RNC = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    categoria = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 40, nullable: false),
                    RNC = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 40, nullable: false),
                    RNC = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.id);
                    table.ForeignKey(
                        name: "FK_factura_cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idStock = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 40, nullable: false),
                    precio = table.Column<double>(nullable: false),
                    Stockid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_producto_stock_Stockid",
                        column: x => x.Stockid,
                        principalTable: "stock",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "producto_cliente",
                columns: table => new
                {
                    idproducto_cliente = table.Column<int>(nullable: false),
                    idcliente = table.Column<int>(nullable: false),
                    idproducto = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    fechaFactura = table.Column<DateTime>(nullable: false),
                    productoid = table.Column<int>(nullable: true),
                    clienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_cliente", x => new { x.idproducto, x.idcliente, x.idproducto_cliente });
                    table.ForeignKey(
                        name: "FK_producto_cliente_cliente_clienteID",
                        column: x => x.clienteID,
                        principalTable: "cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_producto_cliente_producto_productoid",
                        column: x => x.productoid,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "producto_proveedor",
                columns: table => new
                {
                    idproducto_proveedor = table.Column<int>(nullable: false),
                    idproducto = table.Column<int>(nullable: false),
                    idproveedor = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    fechaImporte = table.Column<DateTime>(nullable: false),
                    productoid = table.Column<int>(nullable: true),
                    proveedorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_proveedor", x => new { x.idproducto, x.idproducto_proveedor, x.idproveedor });
                    table.ForeignKey(
                        name: "FK_producto_proveedor_producto_productoid",
                        column: x => x.productoid,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_producto_proveedor_proveedor_proveedorid",
                        column: x => x.proveedorid,
                        principalTable: "proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_factura_ClienteID",
                table: "factura",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_producto_Stockid",
                table: "producto",
                column: "Stockid");

            migrationBuilder.CreateIndex(
                name: "IX_producto_cliente_clienteID",
                table: "producto_cliente",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_producto_cliente_productoid",
                table: "producto_cliente",
                column: "productoid");

            migrationBuilder.CreateIndex(
                name: "IX_producto_proveedor_productoid",
                table: "producto_proveedor",
                column: "productoid");

            migrationBuilder.CreateIndex(
                name: "IX_producto_proveedor_proveedorid",
                table: "producto_proveedor",
                column: "proveedorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "producto_cliente");

            migrationBuilder.DropTable(
                name: "producto_proveedor");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "stock");
        }
    }
}
