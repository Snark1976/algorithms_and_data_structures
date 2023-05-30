using System.Text;

namespace home_work_3
{
    public class MyLinkedList
    {
        internal class Node
        {
            public int Value;
            public Node? Next;

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node? _head;

        public int Size()
        { 
            int size = 0;
            Node? current = _head;
            while (current != null)
            {
                current = current.Next;
                size++;
            }
            return size;
        }

        public bool Contains(int value)
        {
            Node? current = _head;
            while (current != null)
            {
                if (current.Value == value) return true;
                current = current.Next;
            }
            return false;
        }

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
            }
            else
            {
                Node last = FindLast();
                last.Next = new Node(value);
            }
        }

        public int GetFirst()
        {
            return Get(0);
        }

        public int Get(int index)
        {
            if (index < 0 || _head == null)
            {
                throw new IndexOutOfRangeException(index.ToString());
            }

            Node? current = _head;
            int currentIndex = 0;
            while (current != null && currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }
            if (currentIndex == index && current != null)
            {
                return current.Value;
            }
            throw new IndexOutOfRangeException(index.ToString());
        }

        public int PopFirst()
        {
            return Pop(0);
        }

        public int Pop(int index)
        {
            if (index < 0 || _head == null)
            {
                throw new IndexOutOfRangeException(index.ToString());
            }

            if (index == 0)
            {
                int pop = _head.Value;
                _head = _head.Next;
                return pop;
            }

            Node previous = _head;
            int currentIndex = 1;
            while (previous.Next != null)
            {
                if (currentIndex == index)
                {
                    int pop = previous.Next.Value;
                    previous.Next = previous.Next.Next;
                    return pop;
                }

                previous = previous.Next;
                currentIndex++;
            }
            throw new IndexOutOfRangeException(index.ToString());
        }

        public MyLinkedList Reversed()
        {
            MyLinkedList reversed = new();
            for (int i = Size() - 1; i >= 0; i--)
                reversed.Add(Get(i));
            return reversed;
        }

        private Node FindLast()
        {
            if (_head is null)
                throw new IndexOutOfRangeException("0");
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        public override string ToString()
        {
            StringBuilder result = new("[");
            Node? current = _head;
            while (current != null)
            {
                result.Append(current.Value);
                if (current.Next is not null) result.Append(" -> ");
                current = current.Next;
            }
            result.Append(']');
            return result.ToString();
        }
    }
}