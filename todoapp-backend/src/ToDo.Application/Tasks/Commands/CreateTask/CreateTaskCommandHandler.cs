using MediatR;
using ToDo.Application.Tasks.Commands.CreateTask;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
  private readonly IToDoRepository _repository;

  public CreateTaskCommandHandler(IToDoRepository repository)
  {
    _repository = repository;
  }

  public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
  {
    var task = new ToDoTask
    {
      Description = request.Description,
      Deadline = request.DeadLine,
      IsCompleted = false
    };

    await _repository.AddAsync(task, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return task.Id;
  }
}
