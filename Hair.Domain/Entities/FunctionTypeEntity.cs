namespace Hair.Domain.Entities
{
    public sealed class FunctionTypeEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public FunctionTypeEntity(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public FunctionTypeEntity()
        {
            
        }
    }
}