using FluentValidation;

namespace ToDo.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
  public CreateTaskCommandValidator()
  {
    RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Description is required.")
        .MinimumLength(10).WithMessage("Description must be at least 10 characters.");

    RuleFor(x => x.DeadLine)
         .GreaterThanOrEqualTo(DateTime.Today).When(x => x.DeadLine.HasValue)
        .WithMessage("Deadline must be a future date.");
  }
}
