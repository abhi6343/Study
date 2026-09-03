using NotificationSystem.Entities;
using NotificationSystem.Strategy;

namespace NotificationSystem.Decorator
{
    internal class RetryableGatewayDecorator(INotificationGateway? wrappedGateway, int maxRetries, long retryDelayMillis) : INotificationGateway
    {
        public void Send(Notification notification)
        {
            int attempt = 0;
            while (attempt < maxRetries)
            {
                try
                {
                    wrappedGateway?.Send(notification);
                    return; // Success
                }
                catch (Exception e)
                {
                    attempt++;
                    Console.WriteLine($"Error: Attempt {attempt} failed for notification {notification.Id}. Retrying...");
                    if (attempt >= maxRetries)
                    {
                        Console.WriteLine(e.Message);
                        throw new Exception($"Failed to send notification after {maxRetries} attempts.", e);
                    }
                    Thread.Sleep((int)retryDelayMillis);
                }
            }
        }
    }
}
