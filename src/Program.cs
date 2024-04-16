namespace Library
{
    internal class Program
    {
        private static void Main()
        {
            var user1 = new User("Alice", new DateTime(2023, 1, 1));
            var user2 = new User("Bob", new DateTime(2023, 2, 1));
            var user3 = new User("Charlie", new DateTime(2023, 3, 1));
            var user4 = new User("David", new DateTime(2023, 4, 1));
            var user5 = new User("Eve", new DateTime(2024, 5, 1));
            var user6 = new User("Fiona", new DateTime(2024, 6, 1));
            var user7 = new User("George", new DateTime(2024, 7, 1));
            var user8 = new User("Hannah", new DateTime(2024, 8, 1));
            var user9 = new User("Ian");
            var user10 = new User("Julia");

            var book1 = new Book("The Great Gatsby", new DateTime(2023, 1, 1));
            var book2 = new Book("1984", new DateTime(2023, 2, 1));
            var book3 = new Book("To Kill a Mockingbird", new DateTime(2023, 3, 1));
            var book4 = new Book("The Catcher in the Rye", new DateTime(2023, 4, 1));
            var book5 = new Book("Pride and Prejudice", new DateTime(2023, 5, 1));
            var book6 = new Book("Wuthering Heights", new DateTime(2023, 6, 1));
            var book7 = new Book("Jane Eyre", new DateTime(2023, 7, 1));
            var book8 = new Book("Brave New World", new DateTime(2023, 8, 1));
            var book9 = new Book("Moby-Dick", new DateTime(2023, 9, 1));
            var book10 = new Book("War and Peace", new DateTime(2023, 10, 1));
            var book11 = new Book("Hamlet", new DateTime(2023, 11, 1));
            var book12 = new Book("Great Expectations", new DateTime(2023, 12, 1));
            var book13 = new Book("Ulysses", new DateTime(2024, 1, 1));
            var book14 = new Book("The Odyssey", new DateTime(2024, 2, 1));
            var book15 = new Book("The Divine Comedy", new DateTime(2024, 3, 1));
            var book16 = new Book("Crime and Punishment", new DateTime(2024, 4, 1));
            var book17 = new Book("The Brothers Karamazov", new DateTime(2024, 5, 1));
            var book18 = new Book("Don Quixote", new DateTime(2024, 6, 1));
            var book19 = new Book("The Iliad");
            var book20 = new Book("Anna Karenina");

            var emailService = new EmailNotificationService();
            var smsService = new SMSNotificationService();
            var libraryWithEmail = new Library(emailService);
            var libraryWithSMS = new Library(smsService);

            Console.WriteLine($"==========Adding library items============");
            libraryWithSMS.AddBook(book1);
            libraryWithSMS.AddBook(book2);
            libraryWithSMS.AddBook(book3);
            libraryWithSMS.AddBook(book4);
            libraryWithSMS.AddBook(book5);
            libraryWithSMS.AddBook(book6);
            libraryWithSMS.AddBook(book7);
            libraryWithSMS.AddBook(book8);
            libraryWithSMS.AddBook(book9);
            libraryWithSMS.AddBook(book10);

            libraryWithEmail.AddBook(book11);
            libraryWithEmail.AddBook(book12);
            libraryWithEmail.AddBook(book13);
            libraryWithEmail.AddBook(book14);
            libraryWithEmail.AddBook(book15);
            libraryWithEmail.AddBook(book16);
            libraryWithEmail.AddBook(book17);
            libraryWithEmail.AddBook(book18);
            libraryWithEmail.AddBook(book19);
            libraryWithEmail.AddBook(book20);

            libraryWithSMS.AddUser(user1);
            libraryWithSMS.AddUser(user2);
            libraryWithSMS.AddUser(user3);
            libraryWithSMS.AddUser(user4);
            libraryWithSMS.AddUser(user5);
            libraryWithSMS.AddUser(user6);
            libraryWithSMS.AddUser(user7);
            libraryWithSMS.AddUser(user8);
            libraryWithSMS.AddUser(user9);
            libraryWithSMS.AddUser(user10);

            libraryWithEmail.AddUser(user1);
            libraryWithEmail.AddUser(user5);
            libraryWithEmail.AddUser(user7);
            libraryWithEmail.AddUser(user10);

            Console.WriteLine($"==========Show library books============");
            libraryWithSMS.GetBooks(1, 3);
            Console.WriteLine($"==========Show library Users============");
            libraryWithSMS.GetUsers(2, 3);

            Console.WriteLine($"==========Found Items============");
            //find book
            var foundBook = libraryWithSMS.FindBookByTitle("The Great Gatsby");
            if (foundBook != null)
            {
                Console.WriteLine($"Book Found: {foundBook}");
            }
            else
            {
                Console.WriteLine($"No Book Found");
            }
            //find user
            var foundUser = libraryWithSMS.FindUserByName("Alice");
            if (foundUser.Count > 0)
            {
                foreach (var user in foundUser)
                {
                    Console.WriteLine($"User Found: {user}");
                }
            }
            else
            {
                Console.WriteLine($"No User Found");
            }
            
            Console.WriteLine($"==========Delete Items============");
            libraryWithSMS.DeleteBookById(book1.Id.ToString());
            libraryWithSMS.DeleteUserById(user1.Id.ToString());
            libraryWithSMS.DeleteUserById(user1.Id.ToString());

            libraryWithEmail.DeleteBookById(book13.Id.ToString());
            libraryWithEmail.DeleteUserById(user10.Id.ToString());
            libraryWithEmail.DeleteUserById(user10.Id.ToString());

            Console.WriteLine($"==========Show library books============");
            libraryWithEmail.GetBooks(1, 5);
            Console.WriteLine($"==========Show library Users============");
            libraryWithEmail.GetUsers(1, 3);
        }
    }
}