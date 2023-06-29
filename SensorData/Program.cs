using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SensorData.Data;
using SensorData.Services;
using SensorData.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "SensorData API", Version = "v1" });
});
builder.Services.AddDbContext<SensorDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();
builder.Services.AddScoped<ISensorService, SensorService>();

var app = builder.Build();

// Apply database migrations
if (app.Environment.IsDevelopment())
{
    var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<SensorDataContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SensorData API V1");
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
