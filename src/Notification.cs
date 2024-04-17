namespace LibraryManagement;
    public enum Action
    {
        ADD,
        DELETE
    }

    interface INotificationService
    {
        void SendNotificationOnSuccess(Action action, string message);
        void SendNotificationOnFailure(Action action, string message);
    }

    public struct EmailNotificationService : INotificationService
    {
        public void SendNotificationOnSuccess(Action action, string message)
        {
            string messageContent = action switch
            {
                Action.ADD => $"Hello, a new {message} successfully to the Library",
                Action.DELETE => $"Hello, {message} successfully from the Library",
                _ => "Action not assign",
            };
            Console.WriteLine(
                $"{messageContent}. If you have any queries or feedback, please contact our support team at support@library.com"
            );
        }

        public void SendNotificationOnFailure(Action action, string message)
        {
            string messageContent = action switch
            {
                Action.ADD => "We encountered an issue on adding " + message,
                Action.DELETE => "We encountered an issue on deleting " + message,
                _ => "Action not assign",
            };
            Console.WriteLine(
                $"{messageContent}. Please review the input data. For more help, visit our FAQ at library.com/faq."
            );
        }
    }

    public struct SMSNotificationService : INotificationService
    {
        public void SendNotificationOnSuccess(Action action, string message)
        {
            string messageContent = action switch
            {
                Action.ADD => $"{message}. Thank you!",
                Action.DELETE => $"{message}. Thank you!",
                _ => "Action not assign",
            };
            Console.WriteLine($"{messageContent}");
        }

        public void SendNotificationOnFailure(Action action, string message)
        {
            string messageContent = action switch
            {
                Action.ADD => "Error adding " + message,
                Action.DELETE => "Error deleting, " + message,
                _ => "Action not assign",
            };
            Console.WriteLine($"{messageContent}. Please email support@library.");
        }
    }