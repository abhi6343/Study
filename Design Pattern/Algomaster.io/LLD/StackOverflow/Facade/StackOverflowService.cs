using StackOverflow.Entities;
using StackOverflow.Obserever;
using StackOverflow.Strategy;
using System.Collections.Concurrent;

namespace StackOverflow.Facade
{
    internal class StackOverflowService
    {
        private readonly ConcurrentDictionary<string, User> users = new();
        private readonly ConcurrentDictionary<string, Question> questions = new();
        private readonly ConcurrentDictionary<string, Answer> answers = new();
        private readonly IPostObserver reputationManager = new ReputationManager();

        public User CreateUser(string name)
        {
            var user = new User(name);
            users.TryAdd(user.Id, user);
            return user;
        }

        public Question PostQuestion(string userId, string title, string body, HashSet<Tag> tags)
        {
            var author = users[userId];
            var question = new Question(title, body, author, tags);
            question.AddObserver(reputationManager);
            questions.TryAdd(question.Id, question);
            return question;
        }

        public Answer PostAnswer(string userId, string questionId, string body)
        {
            var author = users[userId];
            var question = questions[questionId];
            var answer = new Answer(body, author);
            answer.AddObserver(reputationManager);
            question.AddAnswer(answer);
            answers.TryAdd(answer.Id, answer);
            return answer;
        }

        public void VoteOnPost(string userId, string postId, VoteType voteType)
        {
            var user = users[userId];
            var post = FindPostById(postId);
            post.Vote(user, voteType);
        }

        public void AcceptAnswer(string questionId, string answerId)
        {
            var question = questions[questionId];
            var answer = answers[answerId];
            question.AcceptAnswer(answer);
        }

        public IEnumerable<Question> SearchQuestions(IEnumerable<ISearchStrategy> strategies)
        {
            IEnumerable<Question> results = questions.Values;

            foreach (var strategy in strategies)
            {
                results = strategy.Filter(results);
            }

            return results;
        }

        public User GetUser(string userId)
        {
            return users[userId];
        }

        private Post FindPostById(string postId)
        {
            if (questions.TryGetValue(postId, out var question))
            {
                return question;
            }
            else if (answers.TryGetValue(postId, out var answer))
            {
                return answer;
            }

            throw new KeyNotFoundException("Post not found");
        }
    }
}
