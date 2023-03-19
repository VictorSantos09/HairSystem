namespace Hair.Application.Dto
{
    public class ViewDutyTimeDto
    {
        public Guid UserID { get; set; }

        public ViewDutyTimeDto(Guid userID)
        {
            UserID = userID;
        }
    }
}
