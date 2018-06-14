using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainLibrary;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            MyNewCollection<PlacesV, PlacesV> Dic = new MyNewCollection<PlacesV, PlacesV>();
            MyNewCollection<PlacesV, PlacesV> Dic1 = new MyNewCollection<PlacesV, PlacesV>();
            Dic.Name = "А";
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            Dic.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            Dic.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);
            Dic.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            Dic1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(50);
                Dic.Add(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            }
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(50);
                Dic1.Add(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            }
            Dic[1] = new DictionaryCommon<PlacesV, PlacesV>.Point(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            Dic1[1] = new DictionaryCommon<PlacesV, PlacesV>.Point(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            Dic.Remove(1);
            Console.WriteLine("Журнал 1");
            Console.WriteLine(journal1.ToString());
            Console.WriteLine("Журнал 2");
            Console.WriteLine(journal2.ToString());
        }
    }
}
