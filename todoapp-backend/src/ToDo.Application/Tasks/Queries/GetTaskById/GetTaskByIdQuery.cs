using MediatR;
using ToDo.Application.DTOs;

namespace ToDo.Application.Tasks.Queries.GetTaskById;

public class GetTaskByIdQuery : IRequest<ToDoTaskDto?>
{
  public int Id { get; set; }

  public GetTaskByIdQuery(int id)
  {
    Id = id;
  }
}
