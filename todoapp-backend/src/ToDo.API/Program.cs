using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Middlewares;
using ToDo.Application.Common.Behaviors;
using ToDo.Application.Tasks.Commands.CreateTask;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(CreateTaskCommandValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
      builder => builder
          .AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(options =>
{
  options.ListenAnyIP(80); // listens on port 80 inside the container
});
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
  using var scope = app.Services.CreateScope();
  var db = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
  db.Database.Migrate();

  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
