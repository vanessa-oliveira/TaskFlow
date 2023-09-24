namespace TaskFlow.Domain.Entities;

public class User : BaseEntity
{
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public IList<Project> Projects { get; set; }
}