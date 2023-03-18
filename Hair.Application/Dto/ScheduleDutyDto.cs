using System;

namespace Hair.Application.Dto
{
    public class ScheduleDutyDto
    {
        public Guid UserID { get; set; }
        public DateTime HaircuteTime { get; set; }
        public bool Confirmed { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string? ClientEmail { get; set; }
        public string ClientName { get; set; }

        public ScheduleDutyDto(Guid userID, DateTime haircuteTime, bool confirmed, string clientPhoneNumber, string? clientEmail, string clientName)
        {
            UserID = userID;
            HaircuteTime = haircuteTime;
            Confirmed = confirmed;
            ClientPhoneNumber = clientPhoneNumber;
            ClientEmail = clientEmail;
            ClientName = clientName;
        }
    }
}
