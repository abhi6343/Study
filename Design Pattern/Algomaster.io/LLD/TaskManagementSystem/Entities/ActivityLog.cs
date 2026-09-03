using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Entities
{
    internal class ActivityLog(string description)
    {
        readonly DateTime timestamp = DateTime.Now;
        public override string ToString() => $"[{timestamp}] {description}";
    }
}
