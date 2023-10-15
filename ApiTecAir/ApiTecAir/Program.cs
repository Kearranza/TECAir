using ApiTecAir.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // actualiza con el sitio que necesitas
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    
    options.AddPolicy("IisPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3333")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<TECAirDbContext>(option=> option.UseNpgsql(builder.Configuration.GetConnectionString("connection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");
app.UseCors("IisPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();