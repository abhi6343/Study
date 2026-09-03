using SocialNetworklikeFacebook.Entities;

namespace SocialNetworklikeFacebook.Strategies
{
    internal class ChronologicalStrategy : INewsFeedGenerationStrategy
    {
        public List<Post> GenerateFeed(User user)
        {
            var friends = user.Friends;
            List<Post> feed = [];

            foreach (var friend in friends)
            {
                feed.AddRange(friend.Posts);
            }

            // Sort posts by timestamp in reverse (most recent first)
            feed.Sort((p1, p2) => p2.Timestamp.CompareTo(p1.Timestamp));

            return feed;
        }
    }
}
