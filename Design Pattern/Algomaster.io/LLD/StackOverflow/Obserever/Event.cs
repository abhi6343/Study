using StackOverflow.Entities;

namespace StackOverflow.Obserever
{
    internal class Event(EventType type, User actor, Post targetPost)
    {
        public EventType EventType { get { return type; } }
        public User Actor { get { return actor; } }
        public Post TargetPost { get { return targetPost; } }
    }
}
