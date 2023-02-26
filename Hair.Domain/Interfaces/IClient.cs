namespace Hair.Domain.Interfaces
{
    public interface IClient : IBase
    {
        string? Email { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
    }
}