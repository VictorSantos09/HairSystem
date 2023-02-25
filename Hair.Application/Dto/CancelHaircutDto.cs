namespace Hair.Application.Dto
{
    public class CancelHaircutDto
    {
        public Guid UserID { get; set; }
        public bool Confirmed { get; set; }
        public string ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public DateTime HaircutTime { get; set; }

        public CancelHaircutDto(Guid userID, bool confirmed, string clientName, string? clientEmail, string clientPhoneNumber, DateTime haircutTime)
        {
            UserID = userID;
            Confirmed = confirmed;
            ClientName = clientName;
            ClientEmail = clientEmail;
            ClientPhoneNumber = clientPhoneNumber;
            HaircutTime = haircutTime;
        }
    }
}