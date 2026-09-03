using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ChatApplication.Entities;
using Microsoft.VSDiagnostics;

namespace ChatApplication.Benchmarks
{
    [CPUUsageDiagnoser]
    public class OneToOneChatBenchmarks
    {
        private OneToOneChat chat;
        private User user1;
        private User user2;
        [GlobalSetup]
        public void Setup()
        {
            user1 = new User("Alice");
            user2 = new User("Bob");
            chat = new OneToOneChat(user1, user2);
        }

        [Benchmark]
        public string GetName_Current()
        {
            string name = null;
            // Call GetName many times to amplify cost
            for (int i = 0; i < 10000; i++)
            {
                name = chat.GetName(user1);
            }

            return name;
        }
    }
}