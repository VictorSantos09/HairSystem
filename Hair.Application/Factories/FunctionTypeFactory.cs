using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class FunctionTypeFactory
    {
        public FunctionTypeEntity Create() => new FunctionTypeEntity();
        public FunctionTypeEntity Create(string name, int code)
        {
            return new FunctionTypeEntity(name, code);
        }
    }
}