using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebsitePsychologist.Models;
using WebsitePsychologist.Services;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("Default")!;
// Получаем версию сервера. Только для MySQL.
ServerVersion serverVerstion = ServerVersion.AutoDetect(connection);
// Добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(
        dbContextOption => dbContextOption
            .UseMySql(connection, serverVerstion)
            // Следующие три параметра помогают при отладке, но должны быть изменены или удалены для производства
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
    );

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDataBaseService();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Login";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
