namespace Hair.Domain.Entities
{
    public sealed class UserServiceEntity : BaseEntity
    {
        public UserServiceTypeEntity Type { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }

        public UserServiceEntity(Guid userID, string name, float value, string? description, UserServiceTypeEntity type)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
            Type = type;
        }

        public UserServiceEntity() { }
    }
}