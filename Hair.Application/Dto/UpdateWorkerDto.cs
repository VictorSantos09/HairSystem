using Hair.Domain.Entities;
using System;

namespace Hair.Application.Dto
{
    public class UpdateWorkerDto
    {
        public Guid UserID { get; set; }
        public string WorkerName { get; set; }
        public string? WorkerEmail { get; set; }
        public string? WorkerPhoneNumber { get; set; }
        public double WorkerSalary { get; set; }
        public AddressEntity NewAddress { get; set; }
        public string? NewEmail { get; set; }
        public string? NewPhoneNumber { get; set; }
        public string NewName { get; set; }
        public float NewSalary { get; set; }
        public string NewFunction { get; set; }

        public UpdateWorkerDto(Guid userID, string workerName, string? workerEmail, string? workerPhoneNumber, double workerSalary,
            AddressEntity newAddress, string? newEmail, string? newPhoneNumber, string newName, float newSalary, string newFunction)
        {
            UserID = userID;
            WorkerName = workerName;
            WorkerEmail = workerEmail;
            WorkerPhoneNumber = workerPhoneNumber;
            WorkerSalary = workerSalary;
            NewAddress = newAddress;
            NewEmail = newEmail;
            NewPhoneNumber = newPhoneNumber;
            NewName = newName;
            NewSalary = newSalary;
            NewFunction = newFunction;
        }
    }
}