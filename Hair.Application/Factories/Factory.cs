using Hair.Application.Factories.Interfaces;

namespace Hair.Application.Factories
{
    public class Factory : IFactory
    {
        public UserFactory User { get; private set; }
        public EmployeeFactory Employee { get; private set; }
        public AddressFactory Address { get; private set; }
        public ImageFactory Image { get; private set; }
        public ServiceOrderFactory ServiceOrder { get; private set; }
        public ProductFactory Product { get; private set; }

        public Factory()
        {
            User = new UserFactory();
            Employee = new EmployeeFactory();
            Address = new AddressFactory();
            Image = new ImageFactory();
            ServiceOrder = new ServiceOrderFactory();
            Product = new ProductFactory();
        }
    }
}