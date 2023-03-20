namespace Hair.Application.Dto.UserCases
{
    public class DeleteAccountDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? CNPJ { get; set; }
        public bool Confirmed { get; set; }

        public DeleteAccountDto(string userName, string email, string password, string? cNPJ, bool confirmed)
        {
            UserName = userName.ToUpper();
            Email = email.ToUpper();
            Password = password;
            CNPJ = cNPJ;
            Confirmed = confirmed;
        }
    }
}