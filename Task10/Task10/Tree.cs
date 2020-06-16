using System;

namespace Task10
{
    public class Tree
    {
        //Класс описывающий узел дерева
        public class  Node
        {
            public int key;
            public int height;
            public Node left, right;
            
            public Node(int k)
            {
                this.key = k;
                this.left = this.right = null;
                this.height = 1;
            }
            
        }
        
        private Node node;

        public Tree(int key)
        {
            this.node = new Node(key);
        }
        //Метод получения высоты узла
        private int GetHeight(ref Node p)
        {
            return p != null ? p.height : 0;
        }
        //Метод получения разности высоты левого и правого поддерева
        private int bFactor(ref Node p)
        {
            return this.GetHeight(ref p.right) - this.GetHeight(ref p.left);
        }
        //Метод увеличения высоты
        private void AddHeight()
        {
            this.node.height++;
        }
        //Метод фиксирования высоты
        private void FixHeight(ref Node p)
        {
            int hl = this.GetHeight(ref p.left);
            int hr = this.GetHeight(ref p.right);

            p.height = (hl > hr ? hl : hr) + 1;
        }
        //Правый поворот дерева
        private Node RotateRight(ref Node p)
        {
            Node q = p.left;
            p.left = q.right;
            q.right = p;
            this.FixHeight(ref p);
            this.FixHeight(ref q);
            return q;
        }
        //Левый поворот дерева
        private Node RotateLeft(ref Node q)
        {
            Node p = q.right;
            q.right = p.left;
            p.left = q;
            this.FixHeight(ref q);
            this.FixHeight(ref p);
            return p;
        }
        //Метод балансировки
        private Node Balance(ref Node p)
        {
            this.FixHeight(ref p);

            if (this.bFactor(ref p) == 2)
            {
                if (this.bFactor(ref p.right) < 0) p.right = this.RotateRight(ref p.right);
                return this.RotateLeft(ref p);
            }
            if (this.bFactor(ref p) == -2)
            {
                if (this.bFactor(ref p.left) > 0) p.left = this.RotateLeft(ref p.left);
                return this.RotateRight(ref p);
            }
            return p;
        }
        //Метод добавления узла в дерево
        public Node Insert(ref Node p, int k)
        {
            if (p == null) return new Node(k);

            if (k < p.key)
            {
                p.left = Insert(ref p.left, k);
                this.AddHeight();
            }
            else if (k > p.key && this.node.height == 2)
            {
                p.left = p.right;
                p.right = null;
                p.right = Insert(ref p.right, k);
                this.AddHeight();
            }
            else
            {
                p.right = Insert(ref p.right, k);
                this.AddHeight();
            }
            
            return Balance(ref p);
        }
        //Метод прохода по дереву
        public static void Run(Node p, int l)
        {
            if (p != null)
            {
                Run(p.left, l + 3);
                for (int i = 0; i < l; i++) Console.Write("     ");
                Console.WriteLine(p.key);
                Run(p.right, l + 3);
            }
        }
    }
}