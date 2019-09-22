using IoCContainer.BusinessLayer.Contracts;
using IoCContainer.BusinessLayer.Test.HelpClasses;
using IoCContainer.BusinessLayer.Test.HelpClasses.Contracts;
using NUnit.Framework;
using System;

namespace IoCContainer.BusinessLayer.Test
{
    public class ContainerTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new Container();
            _container.Register<ISample, Sample>();
        }

        [Test]
        public void test_that_container_return_instace()
        {
            //Act
            var sample = _container.GetInstance<ISample>();

            //Assert
            Assert.AreEqual(typeof(Sample), sample.GetType());
        }

        [Test]
        public void test_that_registering_class_more_than_once_will_throw_expetion()
        {
            //Act && Assert
            Assert.Throws<InvalidOperationException>(() => _container.Register<ISample, Sample>());
        }

        [Test]
        public void test_that_registering_singleton_more_than_once_will_throw_expetion()
        {
            //Act
            _container.RegisterSingleton(new Sample());

            // Assert
            Assert.Throws<InvalidOperationException>(() => _container.RegisterSingleton(new Sample()));
        }
    }
}