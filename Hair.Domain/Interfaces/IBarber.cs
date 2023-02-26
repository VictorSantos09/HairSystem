namespace Hair.Domain.Interfaces
{
    public interface IBarber : IBase
    {
        IAddress Address { get; set; }
        string? Email { get; set; }
        bool Hired { get; set; }
        string Name { get; set; }
        string? PhoneNumber { get; set; }
        double Salary { get; set; }
        Guid SaloonId { get; set; }
        string SaloonName { get; set; }
    }
}