using TestMVC.Models;
using Task = System.Threading.Tasks.Task;

namespace TestMVC.Interface;
public interface ITestRepository
{
    Task<List<Test>> GetAll();
    Task<Test> GetTestById(int id);
    Task AddTestAsync(Test test);
    Task DeleteTestAsync(int id);
    Task UpdateTest(Test test);
}
