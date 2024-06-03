using Microsoft.EntityFrameworkCore;
using GabitenStomatologiczny.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GabinetStomatologicznyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("GabinetStomatologicznyDB")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
