using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment
{
    [Serializable]
    public class IntLinkedListInput
    {
        [SerializeField] private int[] values;

        public LinkedList<int> GetLinkedList()
        {
            return new LinkedList<int>(values ?? Array.Empty<int>());
        }
    }

    [Serializable]
    public class StringLinkedListInput
    {
        [SerializeField] private string[] values;

        public LinkedList<string> GetLinkedList()
        {
            return new LinkedList<string>(values ?? Array.Empty<string>());
        }
    }

    [Serializable]
    public class GameEventLinkedListInput
    {
        [SerializeField] private GameEvent[] values;

        public LinkedList<GameEvent> GetLinkedList()
        {
            return new LinkedList<GameEvent>(values ?? Array.Empty<GameEvent>());
        }
    }

    [Serializable]
    public class StringIntEntry
    {
        [SerializeField] private string key;
        [SerializeField] private int value;

        public string Key => key;
        public int Value => value;
    }

    [Serializable]
    public class StringIntDictionaryInput
    {
        [SerializeField] private StringIntEntry[] entries;

        public Dictionary<string, int> GetDictionary()
        {
            if (entries == null)
            {
                return new Dictionary<string, int>();
            }

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (StringIntEntry entry in entries)
            {
                if (entry == null)
                {
                    continue;
                }

                if (entry.Key == null)
                {
                    Debug.LogError("Dictionary input contains a null key.");
                    return new Dictionary<string, int>();
                }

                if (dictionary.ContainsKey(entry.Key))
                {
                    Debug.LogError($"Dictionary input contains duplicate key: '{entry.Key}'.");
                    return new Dictionary<string, int>();
                }

                dictionary.Add(entry.Key, entry.Value);
            }

            return dictionary;
        }
    }
}