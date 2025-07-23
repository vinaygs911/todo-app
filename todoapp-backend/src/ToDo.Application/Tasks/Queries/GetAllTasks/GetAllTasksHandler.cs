using MediatR;
using ToDo.Application.DTOs;
using ToDo.Application.Mappers;
using ToDo.Application.Tasks.Queries.GetAllTasks;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Queries.GetAllTasks;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<ToDoTaskDto>>
{
  private readonly IToDoRepository _repository;

  public GetAllTasksQueryHandler(IToDoRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<ToDoTaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
  {
    var allTasks = await _repository.GetAllAsync(cancellationToken);

    var filtered = request.Status switch
    {
      "active" => allTasks.Where(t => !t.IsCompleted),
      "completed" => allTasks.Where(t => t.IsCompleted),
      _ => allTasks
    };

    return filtered.Select(t => t.ToDto()).ToList();
  }
}
