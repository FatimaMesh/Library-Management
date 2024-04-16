namespace Library
{
    class Book : BaseEntity
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

        public override string ToString()
        {
            return $"Id: {this.Id}, Title: {this.Title}, Created Date: {this.CreatedDate.ToShortDateString()}";
        }
    }
}