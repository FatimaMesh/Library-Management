namespace Library
{
    class User : BaseEntity
    {
        public string? Name { get; set; }

        public User(string name, DateTime? createdDate = null)
            : base(createdDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Empty Name");
                }
                Name = name;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    
        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, Created Date: {this.CreatedDate.ToShortDateString()}";
        }
    }
}