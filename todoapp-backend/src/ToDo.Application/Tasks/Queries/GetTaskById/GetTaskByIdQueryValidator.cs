using FluentValidation;
using ToDo.Application.Tasks.Queries.GetTaskById;

namespace ToDo.Application.Queries.GetTaskById;

public class GetTaskByIdQueryValidator : AbstractValidator<GetTaskByIdQuery>
{
  public GetTaskByIdQueryValidator()
  {
    RuleFor(q => q.Id)
        .GreaterThan(0)
        .WithMessage("Task ID must be greater than zero.");
  }
}
