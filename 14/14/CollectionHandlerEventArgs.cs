using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    class CollectionHandlerEventArgs: EventArgs
    {
        public string Name { get; set; }

        public string ChangeName { get; set; }

        public object Obj { get; set; }

        public CollectionHandlerEventArgs(string name, string change, object obj)
        {
            Name = name;
            ChangeName = change;
            Obj = obj;
        }

        public override string ToString()
        {
            return "Название коллекции: " + Name + "\nСобытие: " + ChangeName + "\n Объект: " + Obj.ToString();
        }
    }
}
