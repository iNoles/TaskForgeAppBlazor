namespace TaskForgeAppBlazor;

public class TaskStore(IndexedDbService db, TaskState state)
{
    private readonly IndexedDbService _db = db;
    private readonly TaskState _state = state;
    private const string StoreName = "tasks";

    public async Task LoadTasksAsync()
    {
        var tasks = await _db.GetAllItemsAsync<TaskItem>(StoreName);
        tasks.Sort((a, b) => a.Position.CompareTo(b.Position));
        _state.SetTasks(tasks);
    }

    public async Task AddTaskAsync(TaskItem task)
    {
        await _db.SaveItemAsync(StoreName, task.Id, task);
        _state.AddTask(task);
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        task.UpdatedAt = DateTime.UtcNow;
        await _db.SaveItemAsync(StoreName, task.Id, task);
        _state.UpdateTask(task);
    }

    public async Task RemoveTaskAsync(string taskId)
    {
        await _db.RemoveItemAsync(StoreName, taskId);
        _state.RemoveTask(taskId);
    }
}