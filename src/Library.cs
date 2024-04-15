using System.Dynamic;

namespace Library
{
    class Library
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void GetBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Title}, {book.Id}");
            }
        }

        public void GetUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine($"{user.Name}, {user.Id}");
            }
        }
    }
}
