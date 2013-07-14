using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Intentions.CSharp.Test;
using JetBrains.ReSharper.Intentions.Extensibility;
using NUnit.Framework;

namespace StructuralSearchPatternDemo.Tests
{
    [TestFixture]
    public class ContainsNullCheckContextActionAvailabilityTests : CSharpContextActionAvailabilityTestBase
    {
        protected override IContextAction CreateContextAction(ICSharpContextActionDataProvider dataProvider)
        {
            return new ContainsNullCheckContextAction(dataProvider);
        }

        [TestCase("ContainsNullCheckAvailability")]
        public void TestExecution(string fileName)
        {
            DoOneTest(fileName);
        }

        protected override string ExtraPath
        {
            get { return string.Empty; }
        }
    }
}
