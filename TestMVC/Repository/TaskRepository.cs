using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestMVC.Data;
using TestMVC.Interface;
using TestMVC.Models;
using TestMVC.Models.ERole;
using Task = TestMVC.Models.Task;
using Tasks = System.Threading.Tasks.Task;

namespace TestMVC.Repository;
public class TaskRepository:ITaskRepository
{

    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    public TaskRepository(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Models.Task> GetTaskByIdAsync(int taskId) => await _context.tasks.FirstOrDefaultAsync(x => x.Id == taskId);

    public async Task<List<Models.Task>> GetAllTasksAsync()
    {
        List<Task> tasks = await _context.tasks.ToListAsync();
        await Console.Out.WriteLineAsync(tasks.ToString());
        return tasks;
    }

    public async Tasks CreateTaskAsync(Models.Task task, string email)
    {
        var _check = await _context.Users.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Email == email);
        var newTask = new Models.Task
        {
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            EStatus = task.EStatus
        };
        if (_check.Tasks is null)
        {
            _check.Tasks = new List<Models.Task> { newTask };
        }
        else
        {
            _check.Tasks.Add(newTask);
        }

        _context.tasks.Add(newTask);
        await _context.SaveChangesAsync();
    }

    public async Task<Task> UpdateTaskAsync(Models.Task task)
    {
        var existingTask = await _context.tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.EStatus = task.EStatus;

            await _context.SaveChangesAsync();
        }

        return existingTask;
    }
    public async Task<Task> GetOldValueAsync(int id) => await _context.tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    public async Task<Task> DeleteTaskAsync(int taskId)
    {
        var currentProduct = await _context.tasks.FirstOrDefaultAsync(x => x.Id == taskId);
        if (currentProduct == null) throw new Exception("Product not found");
        _context.tasks.Remove(currentProduct);
        await _context.SaveChangesAsync();
        return currentProduct;

    }
    public async Task<Task> CreateAudit(Task newProduct, Task oldProduct, string actionType, User user)
    {
        var auditTrailRecord = new AuditLog
        {
            UserName = user.UserName,
            Action = actionType,
            ControllerName = "Task",
            DateTime = DateTime.UtcNow,
            OldValue = JsonConvert.SerializeObject(oldProduct, Formatting.Indented),
            NewValue = JsonConvert.SerializeObject(newProduct, Formatting.Indented)
        };

        _context.AuditLog.Add(auditTrailRecord);
        try
        {
            await _context.SaveChangesAsync();
            return newProduct;
        }
        catch (Exception ex)
        {
            throw new Exception("Error saving audit log.", ex);
        }
    }

    public async Task<Task> CheckTaskName(Task task)
    {
        var checkBase = await _context.tasks.FindAsync(task);
        return checkBase ?? new Task();
    }

    public async Task<User> AddTaskForUser(string email, string taskName)
    {
        var check = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        var checkTask = await _context.tasks.FirstOrDefaultAsync(x => x.Title == taskName);
        if (check.Tasks == null)
        {
            check.Tasks = new List<Task> { checkTask };
        }
        else
        {
            check.Tasks.Add(checkTask);
        }

        await _context.SaveChangesAsync();
        return check;
    }

}
