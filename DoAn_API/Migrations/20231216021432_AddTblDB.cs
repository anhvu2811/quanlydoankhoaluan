using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn_API.Migrations
{
    public partial class AddTblDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuyenNganh",
                columns: table => new
                {
                    ChuyenNganhID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenChuyenNganh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenNganh", x => x.ChuyenNganhID);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    KhoaID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.KhoaID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDeTai",
                columns: table => new
                {
                    LoaiDeTaiID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenLoaiDeTai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDeTai", x => x.LoaiDeTaiID);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyen",
                columns: table => new
                {
                    NhomQuyenID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenNhomQuyen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyen", x => x.NhomQuyenID);
                });

            migrationBuilder.CreateTable(
                name: "NienKhoa",
                columns: table => new
                {
                    NienKhoaID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenNienKhoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NienKhoa", x => x.NienKhoaID);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    LopID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KhoaID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.LopID);
                    table.ForeignKey(
                        name: "FK_Lop_Khoa_KhoaID",
                        column: x => x.KhoaID,
                        principalTable: "Khoa",
                        principalColumn: "KhoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianDangKy",
                columns: table => new
                {
                    ThoiGianDangKyID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    BatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiDeTaiID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiGianDangKy", x => x.ThoiGianDangKyID);
                    table.ForeignKey(
                        name: "FK_ThoiGianDangKy_LoaiDeTai_LoaiDeTaiID",
                        column: x => x.LoaiDeTaiID,
                        principalTable: "LoaiDeTai",
                        principalColumn: "LoaiDeTaiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    GiangVienID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KhoaID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    NhomQuyenID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.GiangVienID);
                    table.ForeignKey(
                        name: "FK_GiangVien_Khoa_KhoaID",
                        column: x => x.KhoaID,
                        principalTable: "Khoa",
                        principalColumn: "KhoaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiangVien_NhomQuyen_NhomQuyenID",
                        column: x => x.NhomQuyenID,
                        principalTable: "NhomQuyen",
                        principalColumn: "NhomQuyenID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    SinhVienID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LopID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    NhomQuyenID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.SinhVienID);
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_LopID",
                        column: x => x.LopID,
                        principalTable: "Lop",
                        principalColumn: "LopID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SinhVien_NhomQuyen_NhomQuyenID",
                        column: x => x.NhomQuyenID,
                        principalTable: "NhomQuyen",
                        principalColumn: "NhomQuyenID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeTai",
                columns: table => new
                {
                    DeTaiID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenDeTai = table.Column<string>(type: "nvarchar(2555)", maxLength: 2555, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NienKhoaID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    LoaiDeTaiID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ChuyenNganhID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    GiangVienID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SinhVienID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeTai", x => x.DeTaiID);
                    table.ForeignKey(
                        name: "FK_DeTai_ChuyenNganh_ChuyenNganhID",
                        column: x => x.ChuyenNganhID,
                        principalTable: "ChuyenNganh",
                        principalColumn: "ChuyenNganhID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeTai_GiangVien_GiangVienID",
                        column: x => x.GiangVienID,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeTai_LoaiDeTai_LoaiDeTaiID",
                        column: x => x.LoaiDeTaiID,
                        principalTable: "LoaiDeTai",
                        principalColumn: "LoaiDeTaiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeTai_NienKhoa_NienKhoaID",
                        column: x => x.NienKhoaID,
                        principalTable: "NienKhoa",
                        principalColumn: "NienKhoaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeTai_SinhVien_SinhVienID",
                        column: x => x.SinhVienID,
                        principalTable: "SinhVien",
                        principalColumn: "SinhVienID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DuyetDeTai",
                columns: table => new
                {
                    DuyetID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NgayDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeTaiID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    GiangVienID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyetDeTai", x => x.DuyetID);
                    table.ForeignKey(
                        name: "FK_DuyetDeTai_DeTai_DeTaiID",
                        column: x => x.DeTaiID,
                        principalTable: "DeTai",
                        principalColumn: "DeTaiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuyetDeTai_GiangVien_GiangVienID",
                        column: x => x.GiangVienID,
                        principalTable: "GiangVien",
                        principalColumn: "GiangVienID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nhom",
                columns: table => new
                {
                    NhomID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TenNhom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeTaiID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhom", x => x.NhomID);
                    table.ForeignKey(
                        name: "FK_Nhom_DeTai_DeTaiID",
                        column: x => x.DeTaiID,
                        principalTable: "DeTai",
                        principalColumn: "DeTaiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhom",
                columns: table => new
                {
                    ChiTietNhomID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NhomID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SinhVienID = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhom", x => x.ChiTietNhomID);
                    table.ForeignKey(
                        name: "FK_ChiTietNhom_Nhom_NhomID",
                        column: x => x.NhomID,
                        principalTable: "Nhom",
                        principalColumn: "NhomID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietNhom_SinhVien_SinhVienID",
                        column: x => x.SinhVienID,
                        principalTable: "SinhVien",
                        principalColumn: "SinhVienID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhom_NhomID",
                table: "ChiTietNhom",
                column: "NhomID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhom_SinhVienID",
                table: "ChiTietNhom",
                column: "SinhVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DeTai_ChuyenNganhID",
                table: "DeTai",
                column: "ChuyenNganhID");

            migrationBuilder.CreateIndex(
                name: "IX_DeTai_GiangVienID",
                table: "DeTai",
                column: "GiangVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DeTai_LoaiDeTaiID",
                table: "DeTai",
                column: "LoaiDeTaiID");

            migrationBuilder.CreateIndex(
                name: "IX_DeTai_NienKhoaID",
                table: "DeTai",
                column: "NienKhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_DeTai_SinhVienID",
                table: "DeTai",
                column: "SinhVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DuyetDeTai_DeTaiID",
                table: "DuyetDeTai",
                column: "DeTaiID");

            migrationBuilder.CreateIndex(
                name: "IX_DuyetDeTai_GiangVienID",
                table: "DuyetDeTai",
                column: "GiangVienID");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_KhoaID",
                table: "GiangVien",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_NhomQuyenID",
                table: "GiangVien",
                column: "NhomQuyenID");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_KhoaID",
                table: "Lop",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Nhom_DeTaiID",
                table: "Nhom",
                column: "DeTaiID");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_LopID",
                table: "SinhVien",
                column: "LopID");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_NhomQuyenID",
                table: "SinhVien",
                column: "NhomQuyenID");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianDangKy_LoaiDeTaiID",
                table: "ThoiGianDangKy",
                column: "LoaiDeTaiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietNhom");

            migrationBuilder.DropTable(
                name: "DuyetDeTai");

            migrationBuilder.DropTable(
                name: "ThoiGianDangKy");

            migrationBuilder.DropTable(
                name: "Nhom");

            migrationBuilder.DropTable(
                name: "DeTai");

            migrationBuilder.DropTable(
                name: "ChuyenNganh");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "LoaiDeTai");

            migrationBuilder.DropTable(
                name: "NienKhoa");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "NhomQuyen");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
