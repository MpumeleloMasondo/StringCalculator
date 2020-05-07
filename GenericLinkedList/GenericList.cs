using GenericLinkedList.Interface;
using System;
using System.Collections;

namespace GenericLinkedList.Generic
{
    public class GenericLinkedList<T> : IGenericLinkedList<T>, IEnumerable
    {

        public class Node
        {
            public T Value { get; private set; }
            public Node NextNode { get; set; }

            public Node Previous { get; set; }
            public Node(T element)
            {
                Value = element;
                NextNode = null;
            }
            public Node(T element, Node previousNode) : this(element)
            {
                previousNode.NextNode = this;
                Previous = this;
                NextNode = null;
            }
        }

        public Node Head;

        public Node Tail;

        public int Count { get; private set; }

        public GenericLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            Node nodeToAdd = null;
            if (Count == 0)
            {
                nodeToAdd = new Node(element);
                Head = nodeToAdd;
                Tail = Head;
            }
            else
            {
                nodeToAdd = new Node(element, Tail);
                Tail = nodeToAdd;
            }

            Count++;
            return true;
        }

        public bool RemoveAt(int index)
        {

            if (index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (index > Count)
                index = Count - 1;

            Node current = Head;
            object result = null;

            if (index == 0)
            {
                result = current.Value;
                Head = current.NextNode;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.NextNode;

                result = current.NextNode.Value;

                current.NextNode = current.NextNode.NextNode;
            }

            Count--;

            return true;
        }

        public bool InsertAtPosition(int index, T Value)
        {
            Node headNode = Head;

            if (index < 1)
                throw new ArgumentOutOfRangeException("Index", index, string.Format("Specified argument was out of the range of valid values. Expected minimum value {0}.", 1));

            if (index == 1)
            {
                var newNode = new Node(Value);
                newNode.NextNode = headNode;
                headNode = newNode;

            }
            else
            {
                while (index-- != 0)
                {
                    if (index == 1)
                    {

                        Node newNode = new Node(Value);
                        newNode.NextNode = headNode.NextNode;

                        headNode.NextNode = newNode;
                        Count++;
                        break;
                    }
                    
                    if (headNode == null && index != 1)
                        throw new ArgumentOutOfRangeException("Index", index, string.Format("Specified argument was out of the range of valid values. Expected maximum value {0}.", Count));

                    headNode = headNode.NextNode;
                }
            }

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            }
        }

        public void PrintList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.Value);
                node = node.NextNode;
                if (node != null)
                    Console.Write(",");
            }

            Console.WriteLine();
        }
    }
}
