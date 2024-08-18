using Microsoft.Extensions.Logging;
using StringCalculator.App.Interfaces;
using System.Text;

namespace StringCalculator.App.Models
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> _head;
        private readonly ILogger<LinkedList<T>> _logger;

        public LinkedList(ILogger<LinkedList<T>> logger)
        {
            _head = null;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Insert(T data, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");

            if (position == 0)
            {
                InsertAtHead(data);
                return;
            }

            var previousNode = GetNodeAtPosition(position - 1);
            InsertAfter(previousNode, data);
        }

        public void Delete(int position)
        {
            if (_head == null)
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (position < 0) throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");

            if (position == 0)
            {
                DeleteHead();
                return;
            }

            var previousNode = GetNodeAtPosition(position - 1);
            DeleteAfter(previousNode);
        }

        public void PrintList()
        {
            var currentNode = _head;
            var output = new StringBuilder();

            while (currentNode != null)
            {
                output.Append($"{currentNode.Data} -> ");
                currentNode = currentNode.Next;
            }

            output.Append("null");

            _logger.LogInformation("Output: {Output}", output.ToString());
        }

        private void InsertAtHead(T data)
        {
            var newNode = new Node<T>(data)
            {
                Next = _head
            };

            _head = newNode;
        }

        private void InsertAfter(Node<T> previousNode, T data)
        {
            if (previousNode == null) throw new ArgumentOutOfRangeException(nameof(previousNode), "Previous node cannot be null.");

            var newNode = new Node<T>(data)
            {
                Next = previousNode.Next
            };

            previousNode.Next = newNode;
        }

        private void DeleteHead()
        {
            _head = _head.Next;
        }

        private void DeleteAfter(Node<T> previousNode)
        {
            if (previousNode == null || previousNode.Next == null) throw new ArgumentOutOfRangeException(nameof(previousNode), "Position is out of range.");

            previousNode.Next = previousNode.Next.Next;
        }

        private Node<T> GetNodeAtPosition(int position)
        {
            var currentNode = _head;
            var currentPosition = 0;

            while (currentNode != null && currentPosition < position)
            {
                currentNode = currentNode.Next;
                currentPosition++;
            }

            if (currentNode == null) throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");

            return currentNode;
        }
    }
}
