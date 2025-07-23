using MediatR;

namespace ToDo.Application.Tasks.Commands.CreateTask
{
  public class CreateTaskCommand : IRequest<int>
  {
    public string Description { get; set; } = string.Empty;
    public DateTime? DeadLine { get; set; }
  }
}
