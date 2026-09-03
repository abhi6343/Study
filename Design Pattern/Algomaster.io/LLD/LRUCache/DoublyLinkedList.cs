using System;
using System.Collections.Generic;
using System.Text;

namespace LRUCache
{
    internal class DoublyLinkedList<K, V>
    {
        readonly public Node<K, V> head, tail;
        public DoublyLinkedList()
        {
            head = new Node<K, V>(default, default);
            tail = new Node<K, V>(default, default);
            head.next = tail;
            tail.prev = head;
        }
        public void AddFirst(Node<K, V> node)
        {
            node.next = head.next;
            node.prev = head;
            head.next.prev = node;
            head.next = node;
        }
        public void Remove(Node<K, V> node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
        public void MoveToFront(Node<K, V> node)
        {
            Remove(node);
            AddFirst(node);
        }
        public Node<K, V> RemoveLast()
        {
            if (tail.prev == head)
            {
                return default;
            }
            var last = tail.prev;
            Remove(tail.prev);
            return last;
        }
    }
}
