namespace Hair.Domain.Interfaces
{
    public interface IUser : IBase
    {
        IAddress Address { get; set; }
        DateTime CloseTime { get; set; }
        string? CNPJ { get; set; }
        string Email { get; set; }
        string? GoogleMapsSource { get; set; }
        List<IHaircut> Haircuts { get; set; }
        DateTime OpenTime { get; set; }
        string OwnerName { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        IHaircutPrice Prices { get; set; }
        string SaloonName { get; set; }
    }
}