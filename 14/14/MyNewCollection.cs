using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLibrary;

namespace _14
{
    delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    class MyNewCollection<TKey,TValue>:DictionaryCommon<TKey,TValue>
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public MyNewCollection() : base() { }
        public MyNewCollection(int capacity) : base(capacity) { }
        public new bool Remove(TKey key)
        {
            bool ok=base.Remove(key);
            CollectionHandlerEventArgs args;
            if (ok==true)
             args= new CollectionHandlerEventArgs(name, " Removing",key);
            else args = new CollectionHandlerEventArgs(name, " Removing was failed", key);
            CollectionCountChanged(Name, args);
            return ok;
        }
        public new void Add(TKey key, TValue value)
        {
            Point t = new Point(key, value);
            CollectionHandlerEventArgs args = new CollectionHandlerEventArgs(Name, "Object is added", t);
            if (CollectionCountChanged != null)
                CollectionCountChanged(Name, args);
            base.Add(key, value);
        }
        public new Point this[int key]
        {
            get
            {
                return base[key];
            }
            set
            {
                if (key > -1 && key < Count)
                {
                    Entries[key] = value;
                    CollectionHandlerEventArgs args = new CollectionHandlerEventArgs(Name, "Object changed its value", value);
                    if (CollectionReferenceChanged != null)
                        CollectionReferenceChanged(Name, args);
                }
                else
                    throw new Exception("Index out of range");
            }
        }
        public bool Remove(int j)
        {
            j--;
            if (j > Count||j<0)
                return false;
            else
            {
                TValue buf=Entries[j].Value;
                CollectionHandlerEventArgs args = new CollectionHandlerEventArgs(Name, "Object is removed", buf);
                if (CollectionCountChanged != null)
                    CollectionCountChanged(Name, args);
                for (int i = 0; i < j; i++)
                    if (Entries[i].Next == j) Entries[i].Next = Entries[j].Next;
                for (int i = j+1; i < Count; i++)
                    Entries[i-1] = Entries[i];
                return true;
            }
        }
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;
    }
}
