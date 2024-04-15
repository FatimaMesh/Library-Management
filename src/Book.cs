namespace Library{
    class Book{
        public Guid Id{get;}
        public string? Title{get;set;}
        public DateTime CreatedDate{get;set;}
    public Book(string title, DateTime? createdDate = null){
        Id = Guid.NewGuid();
        Title = title;
        CreatedDate = createdDate ?? DateTime.Now;
    }
    }
}