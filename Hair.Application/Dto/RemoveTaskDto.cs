namespace Hair.Application.Dto
{
    public class RemoveTaskDto
    {
        public Guid UserID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public float TaskValue { get; set; }

        public RemoveTaskDto(Guid userID, string taskName, float taskValue, string taskType)
        {
            UserID = userID;
            TaskName = taskName;
            TaskValue = taskValue;
            TaskType = taskType;
        }
    }
}
