using MediatR;

namespace ToDo.Application.Tasks.Commands.DeleteTask
{
  public class DeleteTaskCommand : IRequest<bool>
  {
    public int Id { get; set; }

    public DeleteTaskCommand(int id)
    {
      Id = id;
    }
  }
}
