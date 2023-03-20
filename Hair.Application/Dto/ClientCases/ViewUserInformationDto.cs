namespace Hair.Application.Dto.ClientCases
{
    public class ViewUserInformationDto
    {
        public Guid UserId { get; set; }

        public ViewUserInformationDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
