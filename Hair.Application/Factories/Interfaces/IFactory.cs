namespace Hair.Application.Factories.Interfaces
{
    public interface IFactory
    {
        AddressFactory Address { get; }
        ClientFactory Client { get; }
        EmployeeFactory Employee { get; }
        FunctionTypeFactory FunctionType { get; }
        ImageFactory Image { get; }
        ProductFactory Product { get; }
        ProductTypeFactory ProductType { get; }
        UserFactory User { get; }
        UserServiceFactory UserService { get; }
        ServiceOrderFactory ServiceOrder { get; }
        UserServiceTypeFactory UserServiceType { get; }
    }
}