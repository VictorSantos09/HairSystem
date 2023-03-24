namespace Hair.Application.Factories.Interfaces
{
    public interface IFactory
    {
        UserFactory User { get; }
        EmployeeFactory Employee { get; }
        AddressFactory Address { get; }
        ImageFactory Image { get; }
        ServiceOrderFactory ServiceOrder { get; }
        ProductFactory Product { get; }
    }
}