using System;
using System.Collections;
using System.Collections.Generic;

namespace Task9
{
    public class MyLinkedList<T> : IEnumerable<int>
    {
        private DNode _head;
        public uint Count;

        public MyLinkedList(int n)
        {
            this._head = null;
            this.Count = 0;

            this.MakeList(n);
        }
        public int Input(string msg)
        {
            int x;
            Console.Write(msg);
            bool ok = int.TryParse(Console.ReadLine(), out x);
            if (ok) return x;
            else
            {
                Console.WriteLine("Введите целое число!");
                return Input(msg);
            }
        }
        public void MakeList(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                int num = this.Input($"Введиите {i + 1} элемент списка: ");
                if (num > 0)
                    this.AddToStart(num);
                else if (num == 0)
                    this.Add(num);
                else
                    arr[i] = num;
            }
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == 0)
                    break;
                this.Add(arr[i]);
                
            }
        }
        public void AddToStart(int data)
        {
            DNode node = new DNode(data);
            node.Next = this._head;
            node.Prev = null;

            if (this._head != null) this._head.Prev = node;
            this._head = node;

            this.Count++;
        }

        public void Add(int data)
        {
            DNode node = new DNode(data);
            if (this._head == null)
            {
                this.Count++;
                node.Prev = null;
                this._head = node;
                return;
            }

            DNode lastNode = GetLastNode();
            lastNode.Next = node;
            node.Prev = lastNode;

            this.Count++;
        }

        public void RemoveByKey(T key)
        {
            DNode temp = this._head;
            if (temp != null && temp.Data.Equals(key))
            {
                this.Count--;
                this._head = temp.Next;
                this._head.Prev = null;
                return;
            }

            while (temp != null && !temp.Data.Equals(key))
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                return;
            }

            this.Count--;
            if (temp.Next != null)
            {
                temp.Next.Prev = temp.Prev;
            }

            if (temp.Prev != null)
            {
                temp.Prev.Next = temp.Next;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index > this.Count - 1 || index < 0) throw new ArgumentException($"Некорректный индекс: {index}");

            var currentIndex = 0;
            var currentNode = _head;

            while (currentIndex != index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            this.Count--;
            if (currentIndex == 0) // Удаляем в начале
            {
                _head = currentNode.Next;
                if (_head != null) _head.Prev = null;
            }
            else if (currentIndex > 0 && currentIndex < this.Count - 1) // Удаляем в середине
            {
                currentNode.Prev.Next = currentNode.Next;
                currentNode.Next.Prev = currentNode.Prev;
            }
            else if (currentIndex == this.Count - 1) // Удаляем в конце
            {
                currentNode.Prev.Next = null;
            }
        }

        public bool FindElem(T key)
        {
            DNode temp = this._head;
            while (temp != null)
            {
                if (temp.Data.Equals(key)) return true;
                temp = temp.Next;
            }

            return false;
        }

        public int GetByIndex(uint index)
        {
            if (index > this.Count) throw new ArgumentException("Индекс превышает размер коллекции");

            var currentIndex = 0;
            var currentNode = _head;

            while (currentIndex != index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode.Data;
        }


        public override string ToString()
        {
            var result = "";
            var temp = _head;
            while (temp != null)
            {
                result += $"{temp.Data} -> ";
                temp = temp.Next;
            }

            return result;
        }

        private DNode GetLastNode()
        {
            DNode temp = this._head;
            while (temp.Next != null) temp = temp.Next;

            return temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

        private class NodeEnumerator : IEnumerator<int>
        {
            private readonly MyLinkedList<T> _collection;
            private int _index;

            public NodeEnumerator(MyLinkedList<T> linkedList)
            {
                this._collection = linkedList;
                this._index = -1;
            }

            public bool MoveNext()
            {
                this._index++;
                return this._index < _collection.Count;
            }

            public void Reset()
            {
                this._index = -1;
            }

            object IEnumerator.Current => Current;

            public int Current => _collection.GetByIndex((uint)this._index);

            public void Dispose()
            {
            }
        }

        private class DNode
        {
            public int Data;
            public DNode Prev;
            public DNode Next;

            public DNode(int data)
            {
                Data = data;
                Prev = null;
                Next = null;
            }
        }
    }
}