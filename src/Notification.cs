namespace Library
{
    interface INotificationService
    {
        public void SendNotificationOnSuccess(string message);
        public void SendNotificationOnFailure(string message);
    }

    public struct EmailNotificationService : INotificationService
    {
        public void SendNotificationOnSuccess(string message)
        {
            Console.WriteLine(
                $"Hello, a new {message} successfully to the Library. If you have any queries or feedback, please contact our support team at support@library.com."
            );
        }

        public void SendNotificationOnFailure(string message)
        {
            Console.WriteLine(
                $"{message}. Please review the input data. For more help, visit our FAQ at library.com/faq."
            );
        }
    }

    public struct SMSNotificationService : INotificationService
    {
        public void SendNotificationOnSuccess(string message)
        {
            Console.WriteLine($"{message}. Thank you!");
        }

        public void SendNotificationOnFailure(string message)
        {
            Console.WriteLine($"{message}. Please email support@library.com.");
        }
    }
}
