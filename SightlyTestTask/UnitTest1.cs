
namespace SightlyTestTask
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NUnit.Framework;

    using Assert = NUnit.Framework.Assert;

    [TestClass]
    public class UnitTest1
    {
        [TestCase(1)]
        [TestCase(2)]
        public void TestMethod1(int a)
        {
            Assert.AreEqual(1, a);
        }
    }
}
