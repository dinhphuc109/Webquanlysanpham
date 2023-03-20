using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webquanlysanpham.Migrations
{
    public partial class AddSanPhamToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donViTinhs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDVT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DVTinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donViTinhs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "nhaCungCaps",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaCungCaps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sanPham_NhaCungCaps",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<long>(type: "bigint", nullable: true),
                    NCCID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPham_NhaCungCaps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongSP = table.Column<int>(type: "int", nullable: false),
                    GiaSP = table.Column<double>(type: "float", nullable: false),
                    DvtID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donViTinhs");

            migrationBuilder.DropTable(
                name: "nhaCungCaps");

            migrationBuilder.DropTable(
                name: "sanPham_NhaCungCaps");

            migrationBuilder.DropTable(
                name: "sanPhams");
        }
    }
}
