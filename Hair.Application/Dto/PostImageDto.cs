namespace Hair.Application.Dto
{
    public class PostImageDto
    {
        public Guid UserID { get; set; }
        public object Image { get; set; }

        public PostImageDto(Guid userID, object image)
        {
            UserID = userID;
            Image = image;
        }
    }
}
