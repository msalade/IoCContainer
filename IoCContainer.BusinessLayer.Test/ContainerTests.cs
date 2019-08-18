using System.ComponentModel;
using NUnit.Framework;

namespace IoCContainer.BusinessLayer.Test
{
    public class ContainerTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new Container();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}