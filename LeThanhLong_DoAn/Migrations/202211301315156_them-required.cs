namespace LeThanhLong_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themrequired : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CauHinhs",
                c => new
                    {
                        MaCauHinh = c.Long(nullable: false, identity: true),
                        CPU = c.String(),
                        RAM = c.String(),
                        OCung = c.String(),
                        ManHinh = c.String(),
                        CardManHinh = c.String(),
                        KetNoi = c.String(),
                        HeDieuHanh = c.String(),
                    })
                .PrimaryKey(t => t.MaCauHinh);
            
            CreateTable(
                "dbo.ChiTiets",
                c => new
                    {
                        MaSp = c.Long(nullable: false, identity: true),
                        MaHd = c.Long(),
                        SoLuong = c.Int(),
                        HoaDon_MaHoaDon = c.Long(),
                        SanPham_MaSanPham = c.Long(),
                    })
                .PrimaryKey(t => t.MaSp)
                .ForeignKey("dbo.HoaDons", t => t.HoaDon_MaHoaDon)
                .ForeignKey("dbo.SanPhams", t => t.SanPham_MaSanPham)
                .Index(t => t.HoaDon_MaHoaDon)
                .Index(t => t.SanPham_MaSanPham);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.Long(nullable: false, identity: true),
                        NgayLap = c.DateTime(),
                        MaKhachHang = c.Long(),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang)
                .Index(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhachHang = c.Long(nullable: false, identity: true),
                        TenKhachHang = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSanPham = c.Long(nullable: false, identity: true),
                        TenSanPham = c.String(nullable: false),
                        Gia = c.Single(nullable: false),
                        ChiTietSanPham = c.String(nullable: false),
                        HinhAnh = c.String(),
                        MaThuongHieu = c.Long(nullable: false),
                        MaDanhMuc = c.Long(nullable: false),
                        MaCauHinh = c.Long(),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.CauHinhs", t => t.MaCauHinh)
                .ForeignKey("dbo.DanhMucs", t => t.MaDanhMuc, cascadeDelete: true)
                .ForeignKey("dbo.ThuongHieux", t => t.MaThuongHieu, cascadeDelete: true)
                .Index(t => t.MaThuongHieu)
                .Index(t => t.MaDanhMuc)
                .Index(t => t.MaCauHinh);
            
            CreateTable(
                "dbo.DanhMucs",
                c => new
                    {
                        MaDanhMuc = c.Long(nullable: false, identity: true),
                        TenDanhMuc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.ThuongHieux",
                c => new
                    {
                        MaThuongHieu = c.Long(nullable: false, identity: true),
                        TenThuongHieu = c.String(nullable: false),
                        HinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.MaThuongHieu);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTiets", "SanPham_MaSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "MaThuongHieu", "dbo.ThuongHieux");
            DropForeignKey("dbo.SanPhams", "MaDanhMuc", "dbo.DanhMucs");
            DropForeignKey("dbo.SanPhams", "MaCauHinh", "dbo.CauHinhs");
            DropForeignKey("dbo.ChiTiets", "HoaDon_MaHoaDon", "dbo.HoaDons");
            DropForeignKey("dbo.HoaDons", "MaKhachHang", "dbo.KhachHangs");
            DropIndex("dbo.SanPhams", new[] { "MaCauHinh" });
            DropIndex("dbo.SanPhams", new[] { "MaDanhMuc" });
            DropIndex("dbo.SanPhams", new[] { "MaThuongHieu" });
            DropIndex("dbo.HoaDons", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTiets", new[] { "SanPham_MaSanPham" });
            DropIndex("dbo.ChiTiets", new[] { "HoaDon_MaHoaDon" });
            DropTable("dbo.ThuongHieux");
            DropTable("dbo.DanhMucs");
            DropTable("dbo.SanPhams");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTiets");
            DropTable("dbo.CauHinhs");
        }
    }
}
