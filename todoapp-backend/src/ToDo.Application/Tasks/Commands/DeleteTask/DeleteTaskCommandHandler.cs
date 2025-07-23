using MediatR;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Tasks.Commands.DeleteTask
{
  public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
  {
    private readonly IToDoRepository _repository;

    public DeleteTaskCommandHandler(IToDoRepository repository)
    {
      _repository = repository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
      var task = await _repository.GetByIdAsync(request.Id, cancellationToken);
      if (task == null)
        return false;

      await _repository.DeleteAsync(task, cancellationToken);
      await _repository.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}
