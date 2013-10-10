using System;
using WindowsFormsApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication.FactoryTest;
using FluentAssertions;
namespace UnitTestProject
{
    [TestClass]
    public class WindowsFormsAppTests
    {
        [TestMethod]
        [TestCategory("FactoryTest")]
        public void TestSimpleConstructor()
        {
            var pinkMyObject = SimpleObjectFactory.GetMYDependency<Dummy>(false);
            var pinkMyObject2 = SimpleObjectFactory.GetMYDependency<Dummy>(true);

            Assert.AreEqual(pinkMyObject, pinkMyObject2, "Dummy object are the same");

        }

        [TestMethod]
        [TestCategory("FactoryTest")]
        public void TestComplexConstructorWithParams()
        {
            var pinkMyObject = SimpleObjectFactory.GetMYDependency<DummyWithConstructor>(false, 1, "2", true);

            Assert.IsNotNull(pinkMyObject);

        }

        [TestMethod]
        [TestCategory("FactoryTest")]
        public void TestComplexConstructorWithMixedParams()
        {
           try
            {
                SimpleObjectFactory.GetMYDependency<DummyWithConstructor>(false, 1, true, "2");
            }

            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }


        [TestMethod]
        [TestCategory("FactoryTest")]
        public void TestComplexConstructorWithMixedParamsUsingFluent()
        {

            Action action =  ()=>
            
            {
                SimpleObjectFactory.GetMYDependency<DummyWithConstructor>(false, 1, true, "2");
            };

            action.ShouldThrow<InvalidOperationException>().
                WithMessage("constructor parameters doesn't match type", ComparisonMode.Substring);
          
        }
    }
}
