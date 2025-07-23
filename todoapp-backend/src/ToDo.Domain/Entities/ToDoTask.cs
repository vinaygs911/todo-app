namespace ToDo.Domain.Entities;
public class ToDoTask
{
  public int Id { get; set; }
  public string Description { get; set; } = string.Empty;
  public DateTime? Deadline { get; set; }
  public bool IsCompleted { get; set; }
}
