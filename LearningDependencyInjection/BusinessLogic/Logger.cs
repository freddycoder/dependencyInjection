﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDependencyInjection.BusinessLogic
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging { message }");
        }
    }
}