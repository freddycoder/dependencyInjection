using System;
using System.Collections.Generic;
using System.Text;

namespace LearningDependencyInjection.BusinessLogic
{
    public class CustomerLogic
    {
        private readonly IContext _context;
        public CustomerLogic(IContext context)
        {
            _context = context;
        }

        public void CreateNewCustomer(string name)
        {
            _context.Add(name);
        }
    }
}
