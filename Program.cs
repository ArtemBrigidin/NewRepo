using Tanki_ASP.NET.Game;
using Tanki_ASP.NET.Game.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
    .AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/PartialViews/{0}.cshtml");
    });

var connectionString = "Data Source=~\\DataBase.sqlite;"; // так не работает ссылка на базу данных, но если указать нормальный путь к ней, то она работает для регистрации и авторизации.
builder.Services.AddSingleton<IProfile>(provider => new Profile(connectionString));
builder.Services.AddSingleton<IGameManager>(provider => {
    var manager = new GameManager();
    manager.InitGameTanks(null);
    return manager;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
