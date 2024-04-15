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
        
        public Book? FindBookByTitle(string title)
        {
            var isFound = Books.Find(book =>
                title.Equals(book.Title, StringComparison.OrdinalIgnoreCase)
            );
            return isFound;
        }

        public User? FindUsersByName(string name)
        {
            var isFound = Users.Find(user =>
                name.Equals(user.Name, StringComparison.OrdinalIgnoreCase)
            );
            return isFound;
        }        
        public void DeleteUserById(string id){
            var isFound = Users.Find(user => user.Id.ToString() == id);
            Users.Remove(isFound!);
        }
        public void DeleteBookById(string id){
            var isFound = Books.Find(book => book.Id.ToString() == id);
            Books.Remove(isFound!);
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
