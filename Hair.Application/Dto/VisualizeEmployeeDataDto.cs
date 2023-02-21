namespace Hair.Application.Dto
{
    public class VisualizeEmployeeDataDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public VisualizeEmployeeDataDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}

