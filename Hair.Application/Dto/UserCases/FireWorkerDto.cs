using System;

namespace Hair.Application.Dto.UserCases
{
    public class FireWorkerDto
    {
        public Guid UserID { get; set; }
        public Guid WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string? WorkerEmail { get; set; }
        public string WorkerPhoneNumber { get; set; }

        public FireWorkerDto(Guid userID, Guid workerID, string workerName, string? workerEmail, string workerPhoneNumber)
        {
            UserID = userID;
            WorkerID = workerID;
            WorkerName = workerName;
            WorkerEmail = workerEmail;
            WorkerPhoneNumber = workerPhoneNumber;
        }
    }
}