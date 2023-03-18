namespace Hair.Application.Dto
{
    public class PostImageDto
    {
        public Guid UserID { get; set; }
        public object Image { get; set; }
        public string UploadDate { get; set; }
        public string Type { get; set; }

        public PostImageDto(Guid userID, object image, string uploadDate, string type)
        {
            UserID = userID;
            Image = image;
            UploadDate = uploadDate;
            Type = type;
        }
    }
}
