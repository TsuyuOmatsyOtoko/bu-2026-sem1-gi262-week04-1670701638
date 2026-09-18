using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            AS01_CountWords();
            AS02_CountNumber();
            AS03_CheckValidBrackets();
            AS04_PrintReverseLinkedList();
            AS05_FindMiddleElement();
            AS06_MergeDictionaries();
            AS07_RemoveDuplicatesFromLinkedList();
            AS08_TopFrequentNumber();
            AS09_PlayerInventory();
            AS10_GameEventQueue();
            AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            if (words == null || words.Length == 0) return;

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                if (wordCounts.ContainsKey(currentWord))
                {
                    wordCounts[currentWord]++;
                }
                else
                {
                    wordCounts[currentWord] = 1;
                }
            }

            string[] keys = new string[wordCounts.Count];
            int[] values = new int[wordCounts.Count];

            wordCounts.Keys.CopyTo(keys, 0);
            wordCounts.Values.CopyTo(values, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"word: '{keys[i]}' count: {values[i]}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            if (numbers == null || numbers.Length == 0) return;

            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];
                if (numberCounts.ContainsKey(currentNum))
                {
                    numberCounts[currentNum]++;
                }
                else
                {
                    numberCounts[currentNum] = 1;
                }
            }

            int[] keys = new int[numberCounts.Count];
            int[] values = new int[numberCounts.Count];

            numberCounts.Keys.CopyTo(keys, 0);
            numberCounts.Values.CopyTo(values, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"number: {keys[i]} count: {values[i]}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            if (input == null) return;

            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            LinkedList<char> stack = new LinkedList<char>();
            bool isValid = true;

            foreach (char c in as03Input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.AddLast(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    if (stack.Last.Value == bracketPairs[c])
                    {
                        stack.RemoveLast();
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0)
            {
                isValid = false;
            }

            Debug.Log(isValid ? "Valid" : "Invalid");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            //LinkedList<int> list = as04List.GetLinkedList();
            LinkedList<int> list = as04List != null ? as04List.GetLinkedList() : null;

            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            //LinkedList<string> list = as05List.GetLinkedList();
            LinkedList<string> list = as05List != null ? as05List.GetLinkedList() : null;

            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            //Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            //Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            Dictionary<string, int> dict1 = as06FirstDictionary != null ? as06FirstDictionary.GetDictionary() : new Dictionary<string, int>();
            Dictionary<string, int> dict2 = as06SecondDictionary != null ? as06SecondDictionary.GetDictionary() : new Dictionary<string, int>();

            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> entry in dict2)
            {
                if (mergedDictionary.ContainsKey(entry.Key))
                {
                    mergedDictionary[entry.Key] += entry.Value;
                }
                else
                {
                    mergedDictionary[entry.Key] = entry.Value;
                }
            }

            foreach (KeyValuePair<string, int> entry in mergedDictionary)
            {
                Debug.Log($"key: {entry.Key}, value: {entry.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            //LinkedList<int> list = as07List.GetLinkedList();
            LinkedList<int> list = as07List != null ? as07List.GetLinkedList() : null;

            if (list == null || list.Count == 0) return;

            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> nextNode = current.Next;

                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen[current.Value] = true;
                }

                current = nextNode;
            }

            foreach (int val in list)
            {
                Debug.Log(val);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            int topNum = numbers[0];
            int maxCount = counts[topNum];

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (counts[num] > maxCount)
                {
                    maxCount = counts[num];
                    topNum = num;
                }
            }

            Debug.Log($"{topNum} count: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            //Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            Dictionary<string, int> inventory = as09Inventory != null ? as09Inventory.GetDictionary() : new Dictionary<string, int>();

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log($"{item.Key}: {item.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            //LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            LinkedList<GameEvent> eventQueue = as10EventQueue != null ? as10EventQueue.GetLinkedList() : null;

            if (eventQueue == null || eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {currentEvent.name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                string type = currentEvent.eventType.ToLower();
                if (type == "enemy")
                {
                    Debug.Log($"Enemy event processed - {currentEvent.name}");
                }
                else if (type == "powerup")
                {
                    Debug.Log($"Power-up event processed - {currentEvent.name}");
                }
                else if (type == "level")
                {
                    Debug.Log($"Level event processed - {currentEvent.name}");
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            //Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            Dictionary<string, int> playerStats = as11PlayerStats != null ? as11PlayerStats.GetDictionary() : new Dictionary<string, int>();

            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats[statName] = value;
            }

            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");

            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log($"{stat.Key}: {stat.Value}");
            }
        }

        #endregion
    }
}