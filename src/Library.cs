namespace Library
{
    class Library
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public INotificationService notification;
        public int page = 1;
        public int pageLimit = 10;

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
                notification.SendNotificationOnFailure(""+user.Name);
                return;
            }
            Users.Add(user);
            notification.SendNotificationOnSuccess(""+user.Name);
        }

        public void AddBook(Book book)
        {
            if (FindBookByTitle(book.Title!) != null)
            {
                Console.WriteLine($"{book.Title} Book already there");
                return;
            }
            Books.Add(book);
        }

        public Book? FindBookByTitle(string title)
        {
            Book? isFound = Books.FirstOrDefault(book =>
                title.Equals(book.Title, StringComparison.OrdinalIgnoreCase)
            );
            if (isFound != null)
            {
                return isFound;
            }
            return null;
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
                return;
            }
            Console.WriteLine($"User not Found");
        }

        public void DeleteBookById(string id)
        {
            Book? isFound = Books.FirstOrDefault(book => book.Id.ToString() == id);
            if (isFound != null)
            {
                Books.Remove(isFound);
                return;
            }
            Console.WriteLine($"Book not Found");
        }

        // Get all books/users with pagination, sorted by created date
        public void GetBooks()
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
                Console.WriteLine($"Title: {book.Title}, Date: {book.CreatedDate}");
            }
        }

        public void GetUsers()
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
                Console.WriteLine($"Name: {user.Name}, Date: {user.CreatedDate}");
            }
        }

        public Boolean IsEmptyList(dynamic list)
        {
            return list.Count <= 0;
        }
    }
}
