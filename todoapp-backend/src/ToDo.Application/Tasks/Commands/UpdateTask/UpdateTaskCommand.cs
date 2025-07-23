using MediatR;
using System.Data;

namespace ToDo.Application.Tasks.Commands.UpdateTask
{
  public class UpdateTaskCommand : IRequest<bool>
  {
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public DateTime? DeadLine { get; set; }
  }
}
