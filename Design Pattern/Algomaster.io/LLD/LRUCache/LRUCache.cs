using System;
using System.Collections.Generic;
using System.Text;

namespace LRUCache
{
    internal class LRUCache<K, V>
    {
        readonly int capacity;
        readonly Dictionary<K, Node<K, V>> map;
        readonly Lock lockObj = new();
        readonly DoublyLinkedList<K, V> dll;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            dll = new DoublyLinkedList<K, V>();
            map = [];
        }
        public V GetV(K key)
        {
            lock (lockObj)
            {
                if (map.ContainsKey(key))
                {
                    var node = map[key];
                    dll.MoveToFront(node);
                    return node.value;
                }
                return default;
            }
        }
        public void Put(K key, V value)
        {
            lock (lockObj)
            {
                if (map.ContainsKey(key))
                {
                    var node = map[key];
                    node.value = value;
                    dll.MoveToFront(node);
                }
                else
                {
                    if (map.Count == capacity)                    {

                        if (dll.RemoveLast() is var lruNode && lruNode != null)
                        {
                            map.Remove(lruNode.key);
                        }
                                                
                    }

                    var newNode = new Node<K, V>(key, value);
                    dll.AddFirst(newNode);
                    map[key] = newNode;
                }
            }
        }

        public void Remove(K key) {
            lock (lockObj)
            {
                if(map.ContainsKey(key))
                {
                    var node = map[key];
                    dll.Remove(node);
                    map.Remove(key);
                }
            }
        }
    }
}
