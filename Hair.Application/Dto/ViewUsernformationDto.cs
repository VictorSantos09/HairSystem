namespace Hair.Application.Dto
{
    public class ViewUsernformationDto
    {
        public Guid UserId { get; set; }

        public ViewUsernformationDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
