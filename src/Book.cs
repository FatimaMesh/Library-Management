namespace Library
{
    class LibraryElement
    {
        public Guid Id { get; }
        public DateTime CreatedDate { get; set; }

        public LibraryElement(DateTime? createdDate = null)
        {
            Id = Guid.NewGuid();
            CreatedDate = createdDate ?? DateTime.Now;
        }
    }

    class Book : LibraryElement
    {
        public string? Title { get; set; }

        public Book(string title, DateTime? createdDate = null)
            : base(createdDate)
        {
            Title = title;
        }
    }
}
