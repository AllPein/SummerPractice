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
        //Функция для ввода числа
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
        //Функция, создающая список
        public void MakeList(int n)
        {

            for (int i = 0; i < n; ++i)
            {
                int num = this.Input($"Введиите {i + 1} элемент списка: ");
                if (i == 0)
                {
                    this._head = new DNode(num);
                }
                else
                {
                    this.Add(num);
                }
            }

        }
        //Функция для получения последней положительной ноды 
        private DNode GetLastPositive()
        {
            var temp = this._head;
            while (temp.Next != null && temp.Next.Data > 0)
            {
                temp = temp.Next;
            }

            return temp.Data > 0 ? temp : null; // Проверка - если ли вообще положительные элементы?
        }
        //Функция добавления в начало списка
        public void AddToStart(int data)
        {
            DNode node = new DNode(data);
            node.Next = this._head;
            node.Prev = null;

            if (this._head != null) this._head.Prev = node;
            this._head = node;

            this.Count++;
        }
        //Функция добавление в конец списка
        private void AddToEnd(int data)
        {
            var node = new DNode(data);
            node.Data = data;

            var last = this.GetLastNode();
            last.Next = node;

        }
        //Функция добавления в список в зависимости от знака числа
        public void Add(int data)
        {
            if (data > 0)
            {
                this.AddToStart(data);
            }
            else if (data < 0)
            {
                this.AddToEnd(data);
            }
            else
            {
                var lastPositive = GetLastPositive();
                if (lastPositive == null) this.AddToStart(0);
                else
                {
                    var nextOfLastPositive= lastPositive.Next;
                    var node = new DNode(data);
                    node.Data = 0;
                    lastPositive.Next = node;
                    node.Next = nextOfLastPositive;
                }
            }
        }
        //Функция удаления из по ключу
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
        //Функция поиска элемента в списке по ключу
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
        //Функция получения элемента по индексу
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
        //Функция для получения последнего элемента списка
        private DNode GetLastNode()
        {
            DNode temp = this._head;
            while (temp.Next != null) temp = temp.Next;

            return temp;
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
        //Класс, описывающий элемент списка
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