using ToDo.Domain.Entities;
using ToDo.Application.DTOs;

namespace ToDo.Application.Mappers;

public static class ToDoTaskMapper
{
  public static ToDoTaskDto ToDto(this ToDoTask task)
  {
    return new ToDoTaskDto
    {
      Id = task.Id,
      Description = task.Description,
      IsCompleted = task.IsCompleted,
      Deadline = task.Deadline
    };
  }

  public static ToDoTask ToEntity(this ToDoTaskDto dto)
  {
    return new ToDoTask
    {
      Id = dto.Id,
      Description = dto.Description,
      IsCompleted = dto.IsCompleted,
      Deadline = dto.Deadline
    };
  }
}
