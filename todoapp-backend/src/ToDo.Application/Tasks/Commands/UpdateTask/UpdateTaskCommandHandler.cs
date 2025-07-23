using MediatR;
using ToDo.Application.Tasks.Commands.UpdateTask;
using ToDo.Domain.Interfaces;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
{
  private readonly IToDoRepository _repository;

  public UpdateTaskCommandHandler(IToDoRepository repository)
  {
    _repository = repository;
  }

  public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
  {
    var task = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (task == null)
      return false;

    task.Description = request.Description;
    task.Deadline = request.DeadLine;
    task.IsCompleted = true;

    await _repository.UpdateAsync(task, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return true;
  }
}
