namespace TaskFlow.Domain.Entities;

public class Project : BaseEntity
{
    public string Title { get; set; }
    public IList<Task> Tasks { get; set; }
    public IList<User> Participants { get; set; }
}