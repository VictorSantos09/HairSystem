namespace Hair.Application.Dto
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
