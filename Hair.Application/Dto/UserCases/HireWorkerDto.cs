using System;

namespace Hair.Application.Dto.UserCases
{
    public class HireWorkerDto
    {
        public string Name { get; set; }
        public Guid UserID { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public float Salary { get; set; }
        public string WorkerStreet { get; set; }
        public string WorkerHouseNumber { get; set; }
        public string? WorkerHouseComplement { get; set; }
        public string WorkerCity { get; set; }
        public string WorkerState { get; set; }
        public bool Confirmed { get; set; }
        public string CEP { get; set; }
        public string WorkerFunction { get; set; }

        public HireWorkerDto(string name, Guid userID, string phoneNumber, string? email, float salary, string workerStreet,
            string workerHouseNumber, string? workerHouseComplement, string workerCity, string workerState, bool confirmed, string cEP, string workerFunction)
        {
            Name = name;
            UserID = userID;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            WorkerStreet = workerStreet;
            WorkerHouseNumber = workerHouseNumber;
            WorkerHouseComplement = workerHouseComplement;
            WorkerCity = workerCity;
            WorkerState = workerState;
            Confirmed = confirmed;
            CEP = cEP;
            WorkerFunction = workerFunction;
        }
    }
}