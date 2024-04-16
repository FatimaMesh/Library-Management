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
}