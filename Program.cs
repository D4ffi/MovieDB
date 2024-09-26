using MovieDB.Models;
using MovieDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.Configure<MovieDbApi>(builder.Configuration.GetSection("MovieDbApi"));
builder.Services.AddHttpClient<IMovieRequest, MovieRequest>(client =>
{
    var config = builder.Configuration.GetSection("MovieDbApi").Get<MovieDbApi>();
    if (config != null)
    {
        client.BaseAddress = new Uri(config.BaseUrl);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.Token}");
    }
    
} );

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

app.MapControllerRoute(
    name: "detail",
    pattern: "Detail/{id}",
    defaults: new { controller = "Detail", action = "Index" });

app.Run();
