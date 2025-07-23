using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Persistence;

public class ToDoDbContext : DbContext
{
  public DbSet<ToDoTask> ToDoItems => Set<ToDoTask>();

  public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
}
