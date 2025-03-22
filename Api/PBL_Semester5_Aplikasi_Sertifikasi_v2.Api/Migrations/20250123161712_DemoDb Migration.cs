using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Migrations
{
    /// <inheritdoc />
    public partial class DemoDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accessed",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    alamat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessed", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accessor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    alamat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    alamat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jadwal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idAssessi = table.Column<int>(name: "id Assessi", type: "int", nullable: false),
                    idAssessor = table.Column<int>(name: "id Assessor", type: "int", nullable: false),
                    idSoal = table.Column<int>(name: "id Soal", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jadwal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jawaban_peserta_assessi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jawabanassessment = table.Column<string>(name: "jawaban assessment", type: "nvarchar(max)", nullable: false),
                    idassessi = table.Column<int>(name: "id assessi", type: "int", nullable: false),
                    idassessor = table.Column<int>(name: "id assessor", type: "int", nullable: false),
                    idsoal = table.Column<int>(name: "id soal", type: "int", nullable: false),
                    idpertanyaan = table.Column<int>(name: "id pertanyaan", type: "int", nullable: false),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jawaban_peserta_assessi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jawaban_peserta_assessi_terverifikasi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rekomendasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tanggapan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pertanyaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jawaban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idassessi = table.Column<int>(name: "id assessi", type: "int", nullable: false),
                    idassessor = table.Column<int>(name: "id assessor", type: "int", nullable: false),
                    idsoal = table.Column<int>(name: "id soal", type: "int", nullable: false),
                    idsesiassessment = table.Column<int>(name: "id sesi assessment", type: "int", nullable: false),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jawaban_peserta_assessi_terverifikasi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pertanyaan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idsoal = table.Column<int>(name: "id soal", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pertanyaan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sesi_assessment",
                columns: table => new
                {
                    idsesiassessment = table.Column<int>(name: "id sesi assessment", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sesi_assessment", x => x.idsesiassessment);
                });

            migrationBuilder.CreateTable(
                name: "soal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    judul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idaccessor = table.Column<int>(name: "id accessor", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soal", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accessed");

            migrationBuilder.DropTable(
                name: "accessor");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "jadwal");

            migrationBuilder.DropTable(
                name: "jawaban_peserta_assessi");

            migrationBuilder.DropTable(
                name: "jawaban_peserta_assessi_terverifikasi");

            migrationBuilder.DropTable(
                name: "pertanyaan");

            migrationBuilder.DropTable(
                name: "sesi_assessment");

            migrationBuilder.DropTable(
                name: "soal");
        }
    }
}
