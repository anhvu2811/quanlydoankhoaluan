using DoAn_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        #region
        public DbSet<NhomQuyenModel> NhomQuyenModels { get; set; }
        public DbSet<KhoaModel> KhoaModels { get; set; }
        public DbSet<NienKhoaModel> NienKhoaModels { get; set; }
        public DbSet<LoaiDeTaiModel> LoaiDeTaiModels { get; set; }
        public DbSet<ChuyenNganhModel> ChuyenNganhModels { get; set; }
        public DbSet<SinhVienModel> SinhVienModels { get; set; }
        public DbSet<GiangVienModel> GiangVienModels { get; set; }
        public DbSet<DeTaiModel> DeTaiModels { get; set; }
        public DbSet<NhomModel> NhomModels { get; set; }
        public DbSet<ChiTietNhomModel> ChiTietNhomModels { get; set; }
        public DbSet<DuyetDeTaiModel> DuyetDeTaiModels { get; set; }
        public DbSet<LopModel> LopModels { get; set; }
        public DbSet<ThoiGianDangKyModel> ThoiGianDangKyModels { get; set; }
        #endregion
    }
}
