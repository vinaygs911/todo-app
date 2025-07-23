using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces
{
  public interface IToDoRepository
  {
    Task<ToDoTask?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<ToDoTask>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(ToDoTask task, CancellationToken cancellationToken);
    Task DeleteAsync(ToDoTask task, CancellationToken cancellationToken);
    Task UpdateAsync(ToDoTask task, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
  }
}
