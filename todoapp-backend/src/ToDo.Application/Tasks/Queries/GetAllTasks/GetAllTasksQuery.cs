using MediatR;
using ToDo.Application.DTOs;

namespace ToDo.Application.Tasks.Queries.GetAllTasks;

public class GetAllTasksQuery : IRequest<List<ToDoTaskDto>>
{
  public string? Status { get; set; }

  public GetAllTasksQuery(string? status = null)
  {
    Status = status?.ToLower();
  }
}
