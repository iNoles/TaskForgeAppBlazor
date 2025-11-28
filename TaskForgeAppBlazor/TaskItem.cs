namespace TaskForgeAppBlazor;

public class TaskItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public int Priority { get; set; } = 1; // 0=Low,1=Med,2=High
    public DateTime? DueDate { get; set; }
    public int Position { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}