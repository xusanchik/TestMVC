using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TestMVC.Data;
using TestMVC.Interface;
using TestMVC.Models.ERole;
using Task = TestMVC.Models.Task;

namespace TestMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<User> _signInManager;

        public TaskController(ITaskRepository productRepository, SignInManager<User> signInManager, UserManager<User> userManager, IToastNotification toastNotification,AppDbContext appDbContext)
        {
            _taskRepository = productRepository;
            _userManager = userManager;
            _toastNotification = toastNotification;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var productViewModels = await _taskRepository.GetAllTasksAsync();
            await Console.Out.WriteLineAsync(productViewModels.ToString());
            return View(productViewModels);
        }
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var task = await _taskRepository.GetTaskByIdAsync(id);
                if (task == null) return NotFound();
                _toastNotification.AddSuccessToastMessage("Details Found!");
                return View(task);

            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage("Details Not Found!");
                return RedirectToAction("Index", "Home");
            }

        }
        [Authorize(Roles = "ADMIN, MANAGER")]
        public IActionResult Create() => View();

        [Authorize(Roles = "ADMIN,MANAGER")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,Status,Email")] Task task, string email)
        {

            if (!ModelState.IsValid) return View(task);
            task.DueDate = DateTime.SpecifyKind(task.DueDate, DateTimeKind.Utc);

            DateTime thresholdDate = new DateTime(2030, 1, 1);
            var oldTime = DateTime.UtcNow;
            if (task.DueDate > thresholdDate && task.DueDate < oldTime)
            {
                throw new Exception("please enter again date");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _taskRepository.CreateTaskAsync(task, email);
            await _taskRepository.CreateAudit(task, null, "Create", user);
            _toastNotification.AddSuccessToastMessage("Created successfully!");
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var task = await _taskRepository.GetTaskByIdAsync(id);
                if (task == null) return NotFound();

                return View(task);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,Status")] Task task)
        {
            if (id != task.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("There are not enough items entered, please try again!");
                return View(task);
            }

            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var oldProduct = await _taskRepository.GetOldValueAsync(id);
                var newProduct = await _taskRepository.UpdateTaskAsync(task);
                await _taskRepository.CreateAudit(newProduct, oldProduct, "Edit", user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_taskRepository.GetTaskByIdAsync(task.Id) == null)
                    return NotFound();
                else
                    throw;
            }
            _toastNotification.AddSuccessToastMessage("task changed successfully!");
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var product = await _taskRepository.GetTaskByIdAsync(id);

                if (product == null) return NotFound();

                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _taskRepository.DeleteTaskAsync(id);
            if (task == null) return NotFound();

            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _taskRepository.CreateAudit(task, null, "Delete", user);
            _toastNotification.AddSuccessToastMessage("your models deleted!");
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateTaskForUser()
        {
            return View();
        }
        public async Task<IActionResult> MyTask()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var Tas = await _appDbContext.Users.Include(x => x.Tasks).FirstOrDefaultAsync(s => s.Id == user.Id);
            
            return View(Tas);
        }
    }
}
