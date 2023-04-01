using QualificationExam.API;
using QualificationExam.Application.Configurators;
using QualificationExam.Identity.Configurators;
using QualificationExam.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.LoadIdentityConf();
builder.Services.LoadIdentityServices();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();
await SeedData.SeedAsync(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllers();

app.Run();
