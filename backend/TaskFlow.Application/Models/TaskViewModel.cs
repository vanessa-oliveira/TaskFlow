using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Models;

public class TaskViewModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public UserViewModel? Assignee { get; set; }
    public IList<Comment>? Comments { get; set; }
}