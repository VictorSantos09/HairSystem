namespace Hair.Application.Dto
{
    public class CreateTaskDto
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }
        public string TaskType { get; set; }

        public CreateTaskDto(Guid userID, string name, float value, string? description, string taskType)
        {
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
            TaskType = taskType;
        }
    }
}