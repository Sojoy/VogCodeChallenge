using Microsoft.VisualStudio.TestTools.UnitTesting;
using VogCodeChallenge.API;

namespace VogCodeChallenge.Test
{
    [TestClass]
    public class UnitTest_TestModule
    {
        [TestMethod]
        public void TestLeveler()
        {
            Assert.AreEqual(0.0, TestModule.Module(1.0f));
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(1, TestModule.Module(1));
        }

        [TestMethod]
        public void TestDoubler()
        {
            Assert.AreEqual(4, TestModule.Module(2));
        }

        [TestMethod]
        public void TestTripler1()
        {
            Assert.AreEqual(9, TestModule.Module(3));
        }

        [TestMethod]
        public void TestTripler2()
        {
            Assert.AreEqual(21, TestModule.Module(7));
        }

        [TestMethod]
        public void TestOthers1()
        {
            Assert.AreEqual(1.1f, TestModule.Module(1.1f));
        }

        [TestMethod]
        public void TestOthers2()
        {
            Assert.AreEqual(9.5, TestModule.Module(9.5));
        }
    }
}
