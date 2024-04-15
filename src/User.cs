namespace Library
{
    class User : Book
    {
        // public string? Id { get; set; }
        // public string? Name { get; set; }
        // public DateTime CreatedDate { get; set; }

        public User(string name, DateTime? createdDate = null) : base(name, createdDate){}
    }
}
