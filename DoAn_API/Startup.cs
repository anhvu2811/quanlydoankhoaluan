﻿using DoAn_API.Data;
using DoAn_API.DTO;
using DoAn_API.Repository;
using DoAn_API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoAn_API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            services.AddCors(option => option.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<AuthenticationService>();
            services.AddScoped<INhomQuyenRepository, NhomQuyenRepository>();
            services.AddScoped<IKhoaRepository, KhoaRepository>();
            services.AddScoped<INienKhoaRepository, NienKhoaRepository>();
            services.AddScoped<ILoaiDeTaiRepository, LoaiDeTaiRepository>();
            services.AddScoped<IChuyenNganhRepository, ChuyenNganhRepository>();
            services.AddScoped<IGiangVienRepository, GiangVienRepository>();
            services.AddScoped<ISinhVienRepository, SinhVienRepository>();
            services.AddScoped<IDeTaiRepository, DeTaiRepository>();
            services.AddScoped<INhomRepository, NhomRepository>();
            services.AddScoped<IChiTietNhomRepository, ChiTietNhomRepository>();
            services.AddScoped<IDuyetDeTaiRepository, DuyetDeTaiRepository>();
            services.AddScoped<ILopRepository, LopRepository>();
            services.AddScoped<IThoiGianDangKyRepository, ThoiGianDangKyRepository>();

            services.Configure<AppSetting>(Configuration.GetSection("AppSettings"));

            var secretKey = Configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //Tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //Ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("GiaoVuPolicy", policy => policy.RequireRole("Giáo vụ"));
                options.AddPolicy("GiangVienGoPolicy", policy => policy.RequireRole("Giảng viên"));
                options.AddPolicy("TruongBoMonPolicy", policy => policy.RequireRole("Trưởng bộ môn"));
                options.AddPolicy("TruongKhoaPolicy", policy => policy.RequireRole("Trưởng khoa"));
                options.AddPolicy("SinhVienPolicy", policy => policy.RequireRole("Sinh viên"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoAn_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowReactApp");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
