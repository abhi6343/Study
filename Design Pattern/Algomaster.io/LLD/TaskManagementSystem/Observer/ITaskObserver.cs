using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Observer
{
    internal interface ITaskObserver
    {
        void Update(Builder.Task task, string changeType);
    }
}
