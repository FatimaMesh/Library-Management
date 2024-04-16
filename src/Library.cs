namespace Library
{
    class Library
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public INotificationService notification;

        public Library(INotificationService notification)
        {
            this.notification = notification;
            Books = new List<Book>();
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            if (Users.Any(currentUser => user.Id == currentUser.Id))
            {
                notification.SendNotificationOnFailure(
                    Action.ADD,
                    "'" + user.Name + "', user already exists"
                );
                return;
            }
            Users.Add(user);
            notification.SendNotificationOnSuccess(
                Action.ADD,
                "user '" + user.Name + "' has been added"
            );
        }

        public void AddBook(Book book)
        {
            if (FindBookByTitle(book.Title!) != null)
            {
                notification.SendNotificationOnFailure(
                    Action.ADD,
                    "'" + book.Title + "', book already exists"
                );
                return;
            }
            Books.Add(book);
            notification.SendNotificationOnSuccess(
                Action.ADD,
                "book '" + book.Title + "' has been added"
            );
        }

        public Book? FindBookByTitle(string title)
        {
            return Books.Find(book => title.Equals(book.Title, StringComparison.OrdinalIgnoreCase));
        }

        public List<User> FindUserByName(string name)
        {
            return Users
                .Where(user => name.Equals(user.Name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void DeleteUserById(string id)
        {
            User? isFound = Users.FirstOrDefault(user => user.Id.ToString() == id);
            if (isFound != null)
            {
                Users.Remove(isFound);
                notification.SendNotificationOnSuccess(
                    Action.DELETE,
                    $"User: {isFound.Name} deleted"
                );
                return;
            }
            notification.SendNotificationOnFailure(Action.DELETE, $"'User not Found to delete'");
        }

        public void DeleteBookById(string id)
        {
            Book? isFound = Books.FirstOrDefault(book => book.Id.ToString() == id);
            if (isFound != null)
            {
                Books.Remove(isFound);
                notification.SendNotificationOnSuccess(
                    Action.DELETE,
                    $"Book: {isFound.Title} deleted"
                );
                return;
            }
            notification.SendNotificationOnFailure(Action.DELETE, $"'Book not Found to delete'");
        }

        // Get all books/users with pagination, sorted by created date
        public void GetBooks(int page, int pageLimit)
        {
            if (IsEmptyList(Books))
            {
                Console.WriteLine($"Empty list");
                return;
            }
            var sortBook = Books
                .OrderBy(book => book.CreatedDate)
                .Skip((page - 1) * pageLimit)
                .Take(pageLimit)
                .ToList();
            foreach (var book in sortBook)
            {
                Console.WriteLine($"{book}");
            }
        }

        public void GetUsers(int page, int pageLimit)
        {
            if (IsEmptyList(Users))
            {
                Console.WriteLine($"Empty list");
                return;
            }
            var sortUser = Users
                .OrderBy(user => user.CreatedDate)
                .Skip((page - 1) * pageLimit)
                .Take(pageLimit)
                .ToList();

            foreach (var user in sortUser)
            {
                Console.WriteLine($"{user}");
            }
        }

        public Boolean IsEmptyList(dynamic list)
        {
            return list.Count <= 0;
        }
    }
}
