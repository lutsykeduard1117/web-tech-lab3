using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DIY POSTS API",
        Version = "v1",
        Description = "Документування API з використанням Swagger",
        Contact = new OpenApiContact
        {
            Name = "Ed Lutsyk",
            Email = "lutsyk.eduard1117@vu.cdu.edu.ua"
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DIY POSTS API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();