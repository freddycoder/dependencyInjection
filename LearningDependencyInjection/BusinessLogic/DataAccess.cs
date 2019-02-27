using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDependencyInjection.BusinessLogic
{
    public class DataAccess : IDataAccess
    {
        private readonly IContext _context;
        public DataAccess(IContext context)
        {
            _context = context;
        }

        public void LoadData()
        {
            Console.WriteLine("Loading Data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
        }
    }
}
