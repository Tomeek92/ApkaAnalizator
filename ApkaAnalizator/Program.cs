using ApkaAnalizatorInfrastructure.Extensions;
using ApkaAnalizatorApplication.Extensions;
using ApkaAnalizatorDomain.Enties;
using ApkaAnalizatorInfrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddIdentityCore<Account>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 3;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApkaAnalizatorDbContext>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");



app.Run();
