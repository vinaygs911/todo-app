using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs;
using ToDo.Application.Tasks.Commands.CreateTask;
using ToDo.Application.Tasks.Commands.DeleteTask;
using ToDo.Application.Tasks.Commands.UpdateTask;
using ToDo.Application.Tasks.Queries.GetAllTasks;
using ToDo.Application.Tasks.Queries.GetTaskById;

namespace ToDo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
  private readonly IMediator _mediator;

  public TasksController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<ToDoTaskDto>>> GetAll([FromQuery] string? status)
  {
    var result = await _mediator.Send(new GetAllTasksQuery(status));
    return Ok(result);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ToDoTaskDto>> GetById(int id)
  {
    var result = await _mediator.Send(new GetTaskByIdQuery(id));
    return result is null ? NotFound() : Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<ToDoTaskDto>> Create([FromBody] ToDoTaskDto dto)
  {
    var command = new CreateTaskCommand
    {
      Description = dto.Description,
      DeadLine = dto.Deadline
    };

    var id = await _mediator.Send(command);

    var createdTask = await _mediator.Send(new GetTaskByIdQuery(id));

    return CreatedAtAction(nameof(GetById), new { id = createdTask!.Id }, createdTask);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<ToDoTaskDto>> Update(int id, [FromBody] ToDoTaskDto dto)
  {
    var command = new UpdateTaskCommand
    {
      Id = id,
      Description = dto.Description,
      DeadLine = dto.Deadline,
      IsCompleted = dto.IsCompleted
    };

    await _mediator.Send(command);

    var updatedTask = await _mediator.Send(new GetTaskByIdQuery(id));

    return Ok(updatedTask);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _mediator.Send(new DeleteTaskCommand(id));
    return NoContent(); // 204
  }
}
