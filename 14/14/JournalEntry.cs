using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    class JournalEntry
    {
        public string Name { get; set; }
        public string ChangeName { get; set; }
        public string Obj { get; set; }
        public JournalEntry(string name, string changeType, string obj)
        {
            Name = name;
            ChangeName = changeType;
            Obj = obj;
        }
        public override string ToString()
        {
            return "Name: " + Name + "\nType of change: " + ChangeName + "\n Object: " + Obj;
        }
    }
}
