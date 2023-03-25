namespace Hair.Application.Dto.UserCases
{
    public class DeleteEmployeeDto
    {
        public Guid UserID { get; set; }
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string? EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }

        public DeleteEmployeeDto(Guid userID, Guid employeeID, string employeeName, string? employeeEmail, string employeePhoneNumber)
        {
            UserID = userID;
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            EmployeePhoneNumber = employeePhoneNumber;
        }
    }
}