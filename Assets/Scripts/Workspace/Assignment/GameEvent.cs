using UnityEngine;

namespace Assignment
{
    [System.Serializable]
    public class GameEvent
    {
        [SerializeField] public string eventType;
        [SerializeField] public string name;
        [SerializeField] public int priority = 1;

        public string EventType => eventType;
        public string Name => name;
        public int Priority => priority;

        public GameEvent(string eventType, string description, int priority = 1)
        {
            this.eventType = eventType;
            name = description;
            this.priority = priority;
        }
    }
}