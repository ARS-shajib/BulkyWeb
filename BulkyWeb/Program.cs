/*Bulky.DataAccess.Data: Includes ApplicationDbContext (which is defined in the first file).*/
using Bulky.DataAccess.Data;
/*Microsoft.EntityFrameworkCore: Required to configure the database.*/
using Microsoft.EntityFrameworkCore;
/*Creates a web application builder, which is responsible for setting up services (like EF Core, MVC, authentication, etc.).*/
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

/*Registers MVC controllers with views, enabling the Model-View-Controller (MVC) pattern.*/
builder.Services.AddControllersWithViews();
/*Registers the ApplicationDbContext in the dependency injection container.Uses SQL Server as the database provider.
Retrieves the "ConnectionStrings" from appsettings.json.This tells EF Core which database to connect to.
*/
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*Builds the web application after configuring all services.*/
var app = builder.Build();

// Configure the HTTP request pipeline.In production mode, it enables error handling and HTTP Strict Transport Security (HSTS).
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/*Configures middlewares: HTTPS redirection (forces HTTPS). Static files (enables serving CSS, JavaScript, images).
Routing (enables endpoint mapping). Authorization (ensures only authenticated users can access restricted parts of the app).*/
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
/*Starts the web server and listens for requests.*/
app.Run();
