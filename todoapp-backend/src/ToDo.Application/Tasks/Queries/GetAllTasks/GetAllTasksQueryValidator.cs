// Application/Queries/GetAllTasks/GetAllTasksQueryValidator.cs
using FluentValidation;
using ToDo.Application.Tasks.Queries.GetAllTasks;

namespace ToDo.Application.Queries.GetAllTasks;

public class GetAllTasksQueryValidator : AbstractValidator<GetAllTasksQuery>
{
  public GetAllTasksQueryValidator()
  {
    RuleFor(q => q.Status)
        .Must(status => string.IsNullOrEmpty(status) || status == "active" || status == "completed")
        .WithMessage("Status must be 'active', 'completed', or empty.");
  }
}
