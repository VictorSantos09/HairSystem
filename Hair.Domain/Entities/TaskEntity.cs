namespace Hair.Domain.Entities
{
    public sealed class TaskEntity : BaseEntity
    {
        public TaskTypeEntity Type { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }

        public TaskEntity(Guid userID, string name, float value, string? description, TaskTypeEntity type)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
            Type = type;
        }

        public TaskEntity() { }
    }
}