using TestMVC.Models;
using TestMVC.Dto_s;

namespace TestMVC.ExtensionFunctions
{
    public class CheckTest
    {
        public static int CheckTests(List<CkeckTest> checkTests, List<Test> tests)
        
        
        
        {
            int count = 0;

            for (int i = 0; i < checkTests.Count; i++)
            {
                CkeckTest currentCheckTest = checkTests[i];
                Test currentTest = tests[i];

                if (currentCheckTest.testId == currentTest.Id.ToString() &&
                    currentCheckTest.optionId == currentTest.RightOption)
                {
                    count++;
                }
            }

            return count;
        }


    }
}
