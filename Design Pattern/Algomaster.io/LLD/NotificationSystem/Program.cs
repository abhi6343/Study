// 1. Setup the notification service
using NotificationSystem.Entities;
using NotificationSystem.Facade;

NotificationService notificationService = new(10);

// 2. Define recipients
Recipient recipient1 = new("user123", "john.doe@example.com", null, "pushToken123");
Recipient recipient2 = new("user456", null, "+15551234567", null);

// 3. Send various notifications using the Facade (NotificationService)

// Scenario 1: Send a welcome email
var welcomeEmail = new Notification.Builder(recipient1, NotificationType.EMAIL)
        .Subject("Welcome!")
        .Message("Welcome to notification system")
        .Build();
notificationService.SendNotification(welcomeEmail);

// Scenario 2: Send a direct push notification
var pushNotification = new Notification.Builder(recipient1, NotificationType.PUSH)
        .Subject("New Message")
        .Message("You have a new message from Jane.")
        .Build();
notificationService.SendNotification(pushNotification);

// Scenario 3: Send order confirmation SMS
var orderSms = new Notification.Builder(recipient2, NotificationType.SMS)
        .Message("Your order for Digital Clock is confirmed")
        .Build();
notificationService.SendNotification(orderSms);

// Wait for a moment to allow the queue processor to work
Thread.Sleep(1000);

// 4. Shutdown the system
Console.WriteLine("\nShutting down the notification system...");
notificationService.Shutdown();
Console.WriteLine("System shut down successfully.");
