using SocialNetworklikeFacebook.Entities;

namespace SocialNetworklikeFacebook.Strategies
{
    internal interface INewsFeedGenerationStrategy
    {
        List<Post> GenerateFeed(User user);
    }
}
