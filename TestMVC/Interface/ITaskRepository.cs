using TestMVC.Models.ERole;

namespace TestMVC.Interface;
public interface ITaskRepository
{
    Task<Models.Task> GetTaskByIdAsync(int taskId);
    Task<List<Models.Task>> GetAllTasksAsync();
    Task CreateTaskAsync(Models.Task task, string email);
    Task<Models.Task> UpdateTaskAsync(Models.Task task);
    Task<Models.Task> DeleteTaskAsync(int taskId);
    public Task<Models.Task> GetOldValueAsync(int id);
    /// <summary>
    /// Creates an audit log entry for a product operation asynchronously.
    /// </summary>
    /// <param name="entity">Product entity representing the current state of the product.</param>
    /// <param name="oldValue">Product entity representing the previous state of the product.</param>
    /// <param name="actionType">The type of action performed (e.g., 'Create', 'Update', 'Delete').</param>
    /// <param name="user">User object representing the user performing the action.</param>
    /// <returns>
    ///     Returns a Task representing the completion of the audit log creation.
    /// </returns>
    public Task<Models.Task> CreateAudit(Models.Task entity, Models.Task oldValue, string actionType, User user);

    Task<Models.Task> CheckTaskName(Models.Task task);
}
