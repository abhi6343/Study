using System;
using System.Collections.Generic;
using System.Text;

namespace LRUCache
{
    internal class Node<K, V>
    {
        public K key;
        public V value;
        public Node<K, V> prev, next;
        public Node(K key, V value) {
            this.key = key;
            this.value = value;
        }

    }
}
