using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaliosTests
{
    public class LegaliosBaseTest
    {
        public static IEnumerable<object[]> GetTestData(TestScenario[] tests) =>
            tests.SelectMany((tt) => tt.tests.Select((tx) => (new object[] { tt.testTitle, tx.testName, tx.testYear, tx.testMonth, tx.resultYear })));
        public static IEnumerable<object[]> GetTestIntData(TestIntScenario[] tests) =>
            tests.SelectMany((tt) => tt.tests.Select((tx) => (new object[] { tt.testTitle, tx.testName, tx.testYear, tx.testMonth, tx.resultYear, tx.resultMonth, tx.resultValue })));
        public static IEnumerable<object[]> GetTestDecData(TestDecScenario[] tests) =>
            tests.SelectMany((tt) => tt.tests.Select((tx) => (new object[] { tt.testTitle, tx.testName, tx.testYear, tx.testMonth, tx.resultYear, tx.resultMonth, tx.resultValue })));

    }
    public record TestScenario(string testTitle, TestParams[] tests);
    public record TestParams(string testName, Int16 testYear, Int16 testMonth, Int16 resultYear);
    public record TestData(string testTitle, TestParams test);
    public record TestIntScenario(string testTitle, TestIntParams[] tests);
    public record TestIntParams(string testName, Int16 testYear, Int16 testMonth, Int16 resultYear, Int16 resultMonth, Int32 resultValue);
    public record TestIntData(string testTitle, TestIntParams test);
    public record TestDecScenario(string testTitle, TestDecParams[] tests);
    public record TestDecParams(string testName, Int16 testYear, Int16 testMonth, Int16 resultYear, Int16 resultMonth, Decimal resultValue);
    public record TestDecData(string testTitle, TestDecParams test);
}
