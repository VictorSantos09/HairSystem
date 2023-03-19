namespace Hair.Domain.Entities
{
    public sealed class TaskTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public TaskTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public TaskTypeEntity()
        {
            
        }
    }
}
