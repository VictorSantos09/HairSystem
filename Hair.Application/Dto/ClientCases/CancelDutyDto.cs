namespace Hair.Application.Dto.ClientCases
{
    public class CancelDutyDto
    {
        public Guid UserID { get; set; }
        public bool Confirmed { get; set; }
        public string ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public DateTime DutyTime { get; set; }

        public CancelDutyDto(Guid userID, bool confirmed, string clientName, string? clientEmail, string clientPhoneNumber, DateTime dutyTime)
        {
            UserID = userID;
            Confirmed = confirmed;
            ClientName = clientName;
            ClientEmail = clientEmail;
            ClientPhoneNumber = clientPhoneNumber;
            DutyTime = dutyTime;
        }
    }
}