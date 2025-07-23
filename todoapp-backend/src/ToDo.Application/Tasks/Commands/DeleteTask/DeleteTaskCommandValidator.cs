using FluentValidation;

namespace ToDo.Application.Tasks.Commands.DeleteTask
{
  public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
  {
    public DeleteTaskCommandValidator()
    {
      RuleFor(x => x.Id)
          .GreaterThan(0)
          .WithMessage("Task Id must be a positive number.");
    }
  }
}
