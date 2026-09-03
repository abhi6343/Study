using NotificationSystem.Entities;
using NotificationSystem.Strategy;

namespace NotificationSystem.Factory
{
    internal class NotificationGatewayFactory
    {
        private static readonly Dictionary<NotificationType, INotificationGateway?> gatewayMap = [];

        public static INotificationGateway? CreateGateway(NotificationType type)
        {
            if (gatewayMap.TryGetValue(type, out INotificationGateway? value))
            {
                return value;
            }

            INotificationGateway? gateway = null;

            switch (type)
            {
                case NotificationType.EMAIL:
                    gateway = new EmailGateway();
                    break;
                case NotificationType.SMS:
                    gateway = new SmsGateway();
                    break;
                case NotificationType.PUSH:
                    gateway = new PushGateway();
                    break;
            }

            gatewayMap[type] = gateway;
            return gateway;
        }
    }
}
