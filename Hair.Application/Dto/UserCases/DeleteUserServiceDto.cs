namespace Hair.Application.Dto.UserCases
{
    public class DeleteUserServiceDto
    {
        public Guid UserID { get; set; }
        public string ServiceName { get; set; }

        public DeleteUserServiceDto(Guid userID, string serviceName)
        {
            UserID = userID;
            ServiceName = serviceName;
        }
    }
}
