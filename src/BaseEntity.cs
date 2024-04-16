namespace Library
{
    class BaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedDate { get; set; }

        public BaseEntity(DateTime? createdDate = null)
        {
            Id = Guid.NewGuid();
            CreatedDate = createdDate ?? DateTime.Now;
        }
    }
}