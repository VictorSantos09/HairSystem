namespace Hair.Domain.Entities
{
    public sealed class ServiceTypeEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public ServiceTypeEntity(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public ServiceTypeEntity()
        {
            
        }
    }
}
