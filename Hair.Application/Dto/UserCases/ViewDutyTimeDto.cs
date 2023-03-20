namespace Hair.Application.Dto.UserCases
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
