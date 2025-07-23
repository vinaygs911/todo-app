using FluentValidation;

namespace ToDo.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
  public UpdateTaskCommandValidator()
  {
    RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Task Id must be a positive number.");

    RuleFor(x => x.Description)
        .MinimumLength(10)
        .When(x => !string.IsNullOrWhiteSpace(x.Description))
        .WithMessage("Description must be at least 10 characters long.");

    RuleFor(x => x.DeadLine)
        .GreaterThanOrEqualTo(DateTime.Today)
        .When(x => x.DeadLine.HasValue)
        .WithMessage("Deadline must be a future date.");
    
    RuleFor(x => x.IsCompleted)
      .NotNull().WithMessage("Completion status must be specified.");
  }
}
