using Rent.Web;
using Rent.Web.Servieces;
using Rent.Web.Servieces.IService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IVoitureService, VoitureService>();
SD.VoitureAPIBase = builder.Configuration["ServiceUrls:VoitureAPI"];
builder.Services.AddScoped<IVoitureService, VoitureService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
