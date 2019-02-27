using System;
using System.IO;
using System.Reflection;
using LearningDependencyInjection.BusinessLogic;
using LearningDependencyInjection.DependencyResoler;
using Xunit;

namespace BasicTest
{
    public class FirstTestAdd
    {
        private readonly Container _container;
        private readonly StringWriter sw;
        public FirstTestAdd()
        {
            sw = new StringWriter();
            Console.SetOut(sw);

            _container = new Container(Assembly.GetAssembly(typeof(IContext)));
        }

        [Fact]
        public void TestRequiredIContext()
        {
            _container.AddContext<IContext>();

            IContext context = _container.GetRequiredService<IContext>();

            context.Add("Sam");

            Assert.Equal("obj Sam as been added to the database\r\n", sw.ToString());
        }

        [Fact]
        public void TestRequiredContext()
        {
            _container.AddContext<Context>();

            Context context = _container.GetRequiredService<Context>();

            context.Add("Sam");

            Assert.Equal("obj Sam as been added to the database\r\n", sw.ToString());
        }

        [Fact]
        public void UltimateTest1()
        {
            _container.AddContext<IContext>();

            CustomerLogic customerLogic = _container.GetRequiredService<CustomerLogic>();

            customerLogic.CreateNewCustomer("Sam");

            Assert.Equal("obj Sam as been added to the database\r\n", sw.ToString());
        }

        [Fact]
        public void UltimateTest2()
        {
            _container.AddContext<Context>();

            CustomerLogic customerLogic = _container.GetRequiredService<CustomerLogic>();

            customerLogic.CreateNewCustomer("Sam");

            Assert.Equal("obj Sam as been added to the database\r\n", sw.ToString());
        }
    }
}
