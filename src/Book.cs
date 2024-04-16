namespace Library
{
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