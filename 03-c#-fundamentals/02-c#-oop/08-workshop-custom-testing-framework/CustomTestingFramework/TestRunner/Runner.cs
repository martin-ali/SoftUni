namespace CustomTestingFramework.TestRunner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CustomTestingFramework.Attributes;
    using CustomTestingFramework.Exceptions;
    using CustomTestingFramework.TestRunner.Contracts;
    using CustomTestingFramework.Utilities;

    public class Runner : ITestRunner
    {
        private readonly ICollection<string> resultInfo;

        public Runner()
        {
            this.resultInfo = new List<string>();
        }

        public IEnumerable<string> Run(string assemblyPath)
        {
            var testClasses = Assembly
                                .LoadFrom(assemblyPath)
                                .GetTypes()
                                .Where(t => t.HasAttribute<TestClassAttribute>());    // FIXME: Replace with cleaner expression;

            var resultInfo = new List<string>();
            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
                                    .GetMethods()
                                    .Where(m => m.HasAttribute<TestMethodAttribute>()) // FIXME: Replace with cleaner expression;
                                    .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);

                foreach (var methodInfo in testMethods)
                {
                    var result = $"Method: {methodInfo.Name} - ";
                    try
                    {
                        methodInfo.Invoke(testClassInstance, null);

                        result += "passed!";
                    }
                    catch (TestException)
                    {
                        result += "failed!";
                    }
                    catch
                    {
                        result += "unexpected error occured!";
                    }
                    finally
                    {
                        resultInfo.Add(result);
                    }
                }
            }

            return resultInfo;
        }
    }
}