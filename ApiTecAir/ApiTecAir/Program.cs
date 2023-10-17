using ApiTecAir.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
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
    
    options.AddPolicy("IisWebPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:4000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

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
app.UseCors("IisWebPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();