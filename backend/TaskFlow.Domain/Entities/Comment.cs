namespace TaskFlow.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public User CreatedBy { get; set; }
    public Guid CreatedById { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModifiedAt { get; set; }
    public Task Task { get; set; }
    public Guid TaskId { get; set; }
}