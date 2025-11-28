namespace TaskForgeAppBlazor;

public class TaskState
{
    public List<TaskItem> Tasks { get; private set; } = [];

    public event Action? OnChange;

    public void SetTasks(List<TaskItem> tasks)
    {
        Tasks = tasks;
        Notify();
    }

    public void AddTask(TaskItem task)
    {
        Tasks.Add(task);
        Notify();
    }

    public void UpdateTask(TaskItem task)
    {
        var index = Tasks.FindIndex(t => t.Id == task.Id);
        if (index >= 0)
            Tasks[index] = task;
        Notify();
    }

    public void RemoveTask(string taskId)
    {
        Tasks.RemoveAll(t => t.Id == taskId);
        Notify();
    }

    private void Notify() => OnChange?.Invoke();
}