using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TestMVC.Data;
using TestMVC.Dto_s;
using TestMVC.ExtensionFunctions;
using TestMVC.Interface;
using TestMVC.Models;
using TestMVC.Models.ERole;
using Windows.UI.Xaml;

namespace TestMVC.Controllers
{
    public class TestController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITestRepository _testRepository;
        private readonly IToastNotification _toastNotification;
        private readonly SignInManager<User> _signInManager;


        public TestController(ITestRepository testRepository, AppDbContext appDbContext, SignInManager<User> signInManager, IToastNotification toastNotification)
        {
                _toastNotification = toastNotification;
                _testRepository = testRepository;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            
        }

        public async Task<IActionResult> Index()
        {
            var allTests = await _testRepository.GetAll();
            return View("Index", allTests);
        }
        public async Task<IActionResult> TableQuestions()
        {
            var allTests = await _testRepository.GetAll();
            return View("TableQuestions", allTests);
        }
        public  async Task<IActionResult> Questions()
        {
            var allTests = await _testRepository.GetAll();
            return View("Questions", allTests);
        }
        public async Task<IActionResult> AddTest() => View("_AddTest");

        [HttpPost]
        public async Task<IActionResult> AddTest(TestDto addTeacherDto)
        {
            if (!ModelState.IsValid) return View("_TestPage");
            Test test = new Test();
            test.Question = addTeacherDto.Question;
            test.Options = addTeacherDto.Options;
            test.RightOption = addTeacherDto.RightOption;
            await _testRepository.AddTestAsync(test);
            var allTests = await _testRepository.GetAll();
            return View("Index", allTests);
        }
        public async Task<IActionResult> GetByIdTask(int id)
        {
            var testByIdAsync = await _testRepository.GetTestById(id);
            return View("_ByIdTest", testByIdAsync);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTest(int id, TestDto addTeacherDto)
        {
            if (!ModelState.IsValid) return View("_TestPage");
            var test = new Test();
            test.Question = addTeacherDto.Question;
            test.Options = addTeacherDto.Options;
            test.RightOption = addTeacherDto.RightOption;
            await _testRepository.UpdateTest(test);
            var tests = await _testRepository.GetAll();
            return View("_TestPage", tests);
        }
        public async Task<IActionResult> DeleteTest(int id)
        {
            await _testRepository.DeleteTestAsync(id);
            var allListTest = await _testRepository.GetAll();
            return View("_TestPage", allListTest);
        }



        public async Task<IActionResult> Check()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Check(List<CkeckTest> myArray)
        {
            var test = await _appDbContext.Test.ToListAsync();

            
            var count = CheckTest.CheckTests(myArray, test);
            var userres = new UserResult();
            var user = await _signInManager.UserManager.GetUserAsync(User);
            userres.UserName = user.UserName;
            var counts = await _appDbContext.Test.ToListAsync();

            userres.Result = ($"{ counts.Count} / {count}");
            _appDbContext.UserResults.Add(userres);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index","UserResult", userres);
            }

    
    }
}
