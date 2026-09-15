using CodeAlpha_EventRegistrationSystem.DAL;
using CodeAlpha_EventRegistrationSystem.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using CodeAlpha_EventRegistrationSystem.Business;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();


builder.Services.AddDalServices();
builder.Services.AddBusinessServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CodeAlpha_EventRegistrationSystem.API.Middlewares.GlobalExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();