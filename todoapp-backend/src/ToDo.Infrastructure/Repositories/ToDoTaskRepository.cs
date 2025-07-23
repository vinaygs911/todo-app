using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Infrastructure.Repositories;

public class ToDoRepository : IToDoRepository
{
  private readonly ToDoDbContext _context;

  public ToDoRepository(ToDoDbContext context)
  {
    _context = context;
  }

  public async Task<ToDoTask?> GetByIdAsync(int id, CancellationToken cancellationToken)
  {
    return await _context.ToDoItems
        .AsNoTracking()
        .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
  }

  public async Task<List<ToDoTask>> GetAllAsync(CancellationToken cancellationToken)
  {
    return await _context.ToDoItems.ToListAsync(cancellationToken);
  }

  public async Task AddAsync(ToDoTask task, CancellationToken cancellationToken)
  {
    await _context.ToDoItems.AddAsync(task, cancellationToken);
  }

  public async Task DeleteAsync(ToDoTask task, CancellationToken cancellationToken)
  {
    _context.ToDoItems.Remove(task);
    await Task.CompletedTask;
  }

  public async Task UpdateAsync(ToDoTask task, CancellationToken cancellationToken)
  {
    _context.ToDoItems.Update(task);
    await Task.CompletedTask;
  }

  public async Task SaveChangesAsync(CancellationToken cancellationToken)
  {
    await _context.SaveChangesAsync(cancellationToken);
  }
}
