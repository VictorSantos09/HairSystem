namespace Hair.Domain.Entities
{
    public sealed class ServiceEntity : BaseEntity
    {
        public ServiceTypeEntity Type { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }

        public ServiceEntity(Guid userID, string name, float value, string? description, ServiceTypeEntity type)
        {
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
            Type = type;
        }

        public ServiceEntity() { }
    }
}