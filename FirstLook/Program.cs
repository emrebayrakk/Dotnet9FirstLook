using FirstLook.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<INewFeatures, NewFeatures>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// UsePathBase en ba�ta �a�r�lmal�
app.UsePathBase("/scalar/v1");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
