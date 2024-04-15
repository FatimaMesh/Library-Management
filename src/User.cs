namespace Library
{
    class User : LibraryElement
    {
        public string? Name { get; set; }
        public User(string name, DateTime? createdDate = null) : base( createdDate){
            Name = name;
        }
    }
}
