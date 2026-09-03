namespace NotificationSystem.Entities
{
    internal class Recipient(string userId, string? email = null, string? phoneNumber = null, string? pushToken = null)
    {
        public string UserId { get; } = userId;

        public string? Email { get { return email; } }

        public bool HasEmail() => !string.IsNullOrEmpty(email);

        public string? PhoneNumber {  get { return phoneNumber; } }

        public bool HasPhoneNumber() => !string.IsNullOrEmpty(phoneNumber);

        public string? PushToken { get { return pushToken; } }

        public bool HasPushToken() => !string.IsNullOrEmpty(pushToken);
    }
}
