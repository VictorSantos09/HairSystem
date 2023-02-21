namespace Hair.Application.Dto
{
    public class ViewSaloonInformationDto
    {
        public Guid UserId { get; set; }

        public ViewSaloonInformationDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
