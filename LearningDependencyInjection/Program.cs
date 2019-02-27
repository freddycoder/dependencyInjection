using LearningDependencyInjection.BusinessLogic;
using LearningDependencyInjection.DependencyResoler;
using System;
using System.Reflection;

namespace LearningDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container(Assembly.GetAssembly(typeof(IContext)));

            container.AddContext<IContext>();

            container.GetRequiredService<BLogic>().ProcessData();

            container.GetRequiredService<CustomerLogic>().CreateNewCustomer("Sam");

            Console.ReadLine();
        }
    }
}
