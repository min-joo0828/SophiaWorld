using Microsoft.EntityFrameworkCore;
using SophiaWorld.Infrastructure.Data;
using SophiaWorld.Core.Interfaces;
using SophiaWorld.Core.Services;
using System;
using SophiaWorld.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// DB 연결
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI 등록
builder.Services.AddScoped<INoticeService, NoticeService>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();