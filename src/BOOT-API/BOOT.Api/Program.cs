
using BOOT.Api.Filters;
using BOOT.Application.Extensions;
using BOOT.Infrastructura.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.

//InjectionBiblio
builder.Services.AddInjectionInfraestructue(Configuration);
builder.Services.AddInjectionApplication(Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();;
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SessionUsuarioFilter>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();


app.MapControllers();

app.Run();