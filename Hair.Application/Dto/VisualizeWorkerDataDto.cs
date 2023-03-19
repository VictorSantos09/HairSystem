namespace Hair.Application.Dto
{
    public class VisualizeWorkerDataDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public VisualizeWorkerDataDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}

