using Hair.Domain.Entities;

namespace Hair.Application.Dto
{
    public class ScheduleHaircutDto
    {
        public Guid UserID { get; set; }
        public string HaircuteTime { get; set; }
        public bool Confirmed { get; set; }
        public ClientEntity Client { get; set; }

        public ScheduleHaircutDto(Guid userID, string haircuteTime, bool confirmed, ClientEntity client)
        {
            UserID = userID;
            HaircuteTime = haircuteTime;
            Confirmed = confirmed;
            Client = client;
        }
    }
}
