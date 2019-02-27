using System;
using System.Collections.Generic;
using System.Text;

namespace LearningDependencyInjection.BusinessLogic
{
    public interface IContext
    {
        void Add(object obj);
    }
}
