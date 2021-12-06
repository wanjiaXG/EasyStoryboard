using EasyStoryboard.Core.Resources.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class Container<T> : IEnumerable<T>
    {
        public delegate void OnAddEvent(T item);

        private OnAddEvent _onAdd;
        public event OnAddEvent OnAdd 
        {
            add 
            {
                _onAdd += value;
            } 
            remove 
            {
                _onAdd -= value;
            }
        }

        public T this[int index]
        { 
            get
            {

            }
            set
            {
                
            } }

        private T[] Arr;

        public int Count { private set; get; }

        public Container()
        {
            Arr = new T[12];
        }

        public void Add(T obj)
        {
            lock (this)
            {
                if(Count == Arr.Length)
                {
                    int capacity = (Arr.Length >> 1) + Arr.Length;
                    T[] newArr = new T[capacity];
                    Array.Copy(Arr, newArr, Arr.Length);
                    Arr = newArr;
                }
                Arr[Count++] = obj;
                _onAdd?.Invoke(obj);
            }
        }

        public void AddRange(Container<T> container)
        {
            foreach(var item in container)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (this)
            {
                foreach (var item in Arr)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
