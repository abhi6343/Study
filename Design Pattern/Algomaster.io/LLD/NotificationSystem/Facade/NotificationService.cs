using NotificationSystem.Decorator;
using NotificationSystem.Entities;
using NotificationSystem.Factory;

namespace NotificationSystem.Facade
{
    internal class NotificationService
    {
        private readonly TaskScheduler? scheduler;
        private readonly CancellationTokenSource cancellationTokenSource;

        public NotificationService(int poolSize)
        {
            var factory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(poolSize));
            this.scheduler = factory.Scheduler;
            this.cancellationTokenSource = new();
        }

        public void SendNotification(Notification notification)
        {
            Task.Factory.StartNew(() =>
            {
                var gateway = new RetryableGatewayDecorator(NotificationGatewayFactory.CreateGateway(notification.Type), 3, 1000);
                try
                {
                    gateway.Send(notification);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception while sending notification: {e}");
                }
            }, cancellationTokenSource.Token, TaskCreationOptions.None, scheduler);
        }

        public void Shutdown()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
