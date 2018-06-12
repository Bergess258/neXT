using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    class Journal
    {
        public List<JournalEntry> list = new List<JournalEntry>();
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry journalEntry = new JournalEntry(args.Name, args.ChangeName, args.Obj.ToString());
            list.Add(journalEntry);
        }
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry journalEntry = new JournalEntry(args.Name, args.ChangeName, args.Obj.ToString());
            list.Add(journalEntry);
        }
        public override string ToString()
        {
            string s = "";
            foreach (JournalEntry j in list)
                s += j.Name + " " + j.ChangeName + " " + j.Obj + "\n";
            return s;
        }
    }
}
