var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// add service for IConfiguration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<EmpleadoServicio>();
builder.Services.AddScoped<ReportesServicio>();
builder.Services.AddScoped<MovimientosServicio>();



var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
