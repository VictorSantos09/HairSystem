using System;

namespace Hair.Application.Dto.ClientCases
{
    public class ScheduleDutyDto
    {
        public Guid UserID { get; set; }
        public DateTime DutyDate { get; set; }
        public bool Confirmed { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string? ClientEmail { get; set; }
        public string ClientName { get; set; }
        public string DutyType { get; set; }

        public ScheduleDutyDto(Guid userID, DateTime dutyTime, bool confirmed, string clientPhoneNumber, string? clientEmail, string clientName, string dutyType)
        {
            UserID = userID;
            DutyDate = dutyTime;
            Confirmed = confirmed;
            ClientPhoneNumber = clientPhoneNumber;
            ClientEmail = clientEmail;
            ClientName = clientName;
            DutyType = dutyType;
        }
    }
}
