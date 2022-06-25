using WebApplication2.Models;
using WebApplication2.Services;
var MyAllowSpecificOrigins = "AllowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>

{
    options.AddPolicy(name: MyAllowSpecificOrigins,

                 builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
