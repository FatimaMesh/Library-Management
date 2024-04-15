namespace Library
{
    class LibraryItem
    {
        public Guid Id { get; }
        public DateTime CreatedDate { get; set; }

        public LibraryItem(DateTime? createdDate = null)
        {
            Id = Guid.NewGuid();
            CreatedDate = createdDate ?? DateTime.Now;
        }
    }

    class Book : LibraryItem
    {
        public string? Title { get; set; }

        public Book(string title, DateTime? createdDate = null)
            : base(createdDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new Exception("Empty Title");
                }
                Title = title;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}