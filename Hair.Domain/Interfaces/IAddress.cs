namespace Hair.Domain.Interfaces
{
    public interface IAddress
    {
        string City { get; set; }
        string? Complement { get; set; }
        string FullAddress { get; set; }
        string Number { get; set; }
        string State { get; set; }
        string Street { get; set; }
    }
}