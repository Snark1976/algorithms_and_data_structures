using System.Xml.Linq;

namespace home_work_4
{
    internal class Tree<T> where T : IComparable<T>
    { 
        private class Node<N> where N: IComparable<N>
        {
            public N Value;
            public Node<N>? Left;
            public Node<N>? Right;

            public Node(N value)
            {
                Value = value;
            }
        }

        private Node<T>? _root;

        public void Add(T value)
        {
            if (_root is null)
            {
                _root = new Node<T>(value);
                return;
            }
            Add(_root, value);
        }

        private void Add(Node<T> current, T value)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                if (current.Left is null)
                {
                    current.Left = new Node<T>(value);
                }
                else
                {
                    Add(current.Left, value);
                }
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                if (current.Right is null)
                {
                    current.Right = new Node<T>(value);
                }
                else
                {
                    Add(current.Right, value);
                }
            }
        }

        public bool Contains(T value) => FindNode(_root, value) != null;

        private Node<T>? FindNode(Node<T>? current, T value)
        {
            if (current == null) return null;
            if (value.CompareTo(current.Value) == 0) return current;
            Node<T>? next = value.CompareTo(current.Value) < 0 ? current.Left : current.Right;
            return FindNode(next, value);
        }

        public void Remove(T value)
        {
            _root = RemoveNode(_root, value);
        }

        private Node<T>? RemoveNode(Node<T>? current, T value)
        {
            if (current is null) return null;

            if (value.CompareTo(current.Value) < 0)
            {
                current.Left = RemoveNode(current.Left, value);
                return current;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current.Right = RemoveNode(current.Right, value);
                return current;
            }

            if (current.Left == null && current.Right == null)
            {
                return null;
            }
            if (current.Left != null && current.Right == null)
            {
                return current.Left;
            }
            else if (current.Left == null && current.Right != null)
            {
                return current.Right;
            }

            Node<T> smallestNodeOnTheRight = FindFirst(current.Right);
            T smallestValueOnTheRight = smallestNodeOnTheRight.Value;
            current.Value = smallestValueOnTheRight;
            current.Right = RemoveNode(current.Right, smallestValueOnTheRight);
            return current;
        }

        public T FindFirst()
        {
            if (_root is null)
            {
                throw new InvalidOperationException("The tree contains no elements");
            }
            return FindFirst(_root).Value;
        }

        private Node<T> FindFirst(Node<T>? current)
        {
            if (current!.Left != null) 
                return FindFirst(current.Left);
            return current;
        }


        public List<T> Dfs()
        {
            List<T> result = new();
            if (_root is not null)  Dfs(_root, result);
            return result;
        }

        private void Dfs(Node<T> current, List<T> result)
        {
            if (current.Left != null)
            {
                Dfs(current.Left, result);
            }
            result.Add(current.Value);
            if (current.Right != null)
            {
                Dfs(current.Right, result);
            }
        }

        public List<T> Bfs()
        {
            if (_root == null)
            {
                return new();
            }

            List<T> result = new();
            Queue<Node<T>> queue = new();
            queue.Enqueue(_root);
            while (queue.TryDequeue(out Node<T>? next))
            {
                result.Add(next!.Value);
                if (next.Left != null)
                {
                    queue.Enqueue(next.Left);
                }
                if (next.Right != null)
                {
                    queue.Enqueue(next.Right);
                }
            }
            return result;
        }
    }
}
