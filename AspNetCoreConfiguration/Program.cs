var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");
app.Run();