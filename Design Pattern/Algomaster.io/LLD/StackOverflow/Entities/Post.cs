using StackOverflow.Obserever;
using System.Collections.Concurrent;

namespace StackOverflow.Entities
{
    internal class Post(string id, string body, User? author) : Content(id, body, author)
    {
        private int voteCount = 0;
        private readonly ConcurrentDictionary<string, VoteType> voters = new();
        private readonly List<IPostObserver> observers = [];
        private readonly Lock postLock = new();

        public void AddObserver(IPostObserver observer)
        {
            observers.Add(observer);
        }

        protected void NotifyObservers(Event eventObj)
        {
            foreach (var observer in observers)
            {
                observer.OnPostEvent(eventObj);
            }
        }

        public void Vote(User user, VoteType voteType)
        {
            lock (postLock)
            {
                string userId = user.Id;
                if (voters.TryGetValue(userId, out var existingVoteType) && existingVoteType == voteType)
                    return; // Already voted

                if (voters.ContainsKey(userId)) // User is changing their vote
                {
                    voteCount += (voteType == VoteType.UPVOTE) ? 2 : -2;
                }
                else // New vote
                {
                    voteCount += (voteType == VoteType.UPVOTE) ? 1 : -1;
                }

                voters[userId] = voteType;

                EventType eventType;
                if (this is Question)
                {
                    eventType = (voteType == VoteType.UPVOTE) ? EventType.UPVOTE_QUESTION : EventType.DOWNVOTE_QUESTION;
                }
                else
                {
                    eventType = (voteType == VoteType.UPVOTE) ? EventType.UPVOTE_ANSWER : EventType.DOWNVOTE_ANSWER;
                }

                NotifyObservers(new(eventType, user, this));
            }
        }
    }
}
