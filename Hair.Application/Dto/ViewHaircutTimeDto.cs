namespace Hair.Application.Dto
{
    public class ViewHaircutTimeDto
    {
        public Guid UserID { get; set; }

        public ViewHaircutTimeDto(Guid userID)
        {
            UserID = userID;
        }
    }
}
