using Hair.Application.Factories.Interfaces;

namespace Hair.Application.Factories
{
    public class Factory : IFactory
    {
        public AddressFactory Address { get; private set; } = new();
        public ClientFactory Client { get; private set; } = new();
        public EmployeeFactory Employee { get; private set; } = new();
        public FunctionTypeFactory FunctionType { get; private set; } = new();
        public ImageFactory Image { get; private set; } = new();
        public ProductFactory Product { get; private set; } = new();
        public ProductTypeFactory ProductType { get; private set; } = new();
        public ServiceOrderFactory ServiceOrder { get; private set; } = new();
        public UserFactory User { get; private set; } = new();
        public UserServiceFactory UserService { get; private set; } = new();
        public UserServiceTypeFactory UserServiceType { get; private set; } = new();
    }
}