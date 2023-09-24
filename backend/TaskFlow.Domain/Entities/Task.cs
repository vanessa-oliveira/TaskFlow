using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class Task : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public User CreatedBy { get; set; }
    public Guid CreatedById { get; set; }
    public DateTime LastModifiedAt { get; set; }
    public User LastModifiedBy { get; set; }
    public Guid LastModifiedById { get; set; }
    public User Assignee { get; set; }
    public Guid AssigneeId { get; set; }
    public IList<Comment> Comments { get; set; }
    public Project Project { get; set; }
    public Guid ProjectId { get; set; }
}