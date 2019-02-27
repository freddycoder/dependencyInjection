using System;
using System.Collections.Generic;
using System.Text;

namespace LearningDependencyInjection.BusinessLogic
{
    public class Context : IContext
    {
        public void Add(object obj)
        {
            Console.WriteLine(nameof(obj) + " " + obj.ToString() + " as been added to the database");
        }
    }
}
