namespace Hair.Application.Dto.UserCases
{
    public class CreateUserServiceDto
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }
        public string ServiceType { get; set; }

        public CreateUserServiceDto(Guid userID, string name, float value, string? description, string taskType)
        {
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
            ServiceType = taskType;
        }
    }
}