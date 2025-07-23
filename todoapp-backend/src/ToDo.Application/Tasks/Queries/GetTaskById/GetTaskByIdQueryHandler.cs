using MediatR;
using ToDo.Application.DTOs;
using ToDo.Application.Mappers;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, ToDoTaskDto?>
{
  private readonly IToDoRepository _repository;

  public GetTaskByIdQueryHandler(IToDoRepository repository)
  {
    _repository = repository;
  }

  public async Task<ToDoTaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
  {
    var task = await _repository.GetByIdAsync(request.Id, cancellationToken);
    return task?.ToDto();
  }
}
