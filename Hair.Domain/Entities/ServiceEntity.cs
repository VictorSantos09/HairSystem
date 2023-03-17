namespace Hair.Domain.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }

        public ServiceEntity(Guid userID, string name, float value, string? description)
        {
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
        }

        public ServiceEntity() { }
    }
}