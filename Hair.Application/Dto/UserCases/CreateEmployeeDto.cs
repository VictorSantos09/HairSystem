namespace Hair.Application.Dto.UserCases
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public Guid UserID { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public float Salary { get; set; }
        public string EmployeeStreet { get; set; }
        public string EmployeeHouseNumber { get; set; }
        public string? EmployeeHouseComplement { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }
        public bool Confirmed { get; set; }
        public string CEP { get; set; }
        public string EmployeeFunction { get; set; }

        public CreateEmployeeDto(string name, Guid userID, string phoneNumber, string? email, float salary, string employeeStreet, string employeeHouseNumber, 
            string? employeeHouseComplement, string employeeCity, string employeeState, bool confirmed, string cEP, string employeeFunction)
        {
            Name = name;
            UserID = userID;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            EmployeeStreet = employeeStreet;
            EmployeeHouseNumber = employeeHouseNumber;
            EmployeeHouseComplement = employeeHouseComplement;
            EmployeeCity = employeeCity;
            EmployeeState = employeeState;
            Confirmed = confirmed;
            CEP = cEP;
            EmployeeFunction = employeeFunction;
        }
    }
}