using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Entities
{
    internal class Tag(string name)
    {
        public string Name { get; } = name;
    }
}
