namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do tipo de serviço do usuário.
    /// </summary>
    public sealed class UserServiceTypeEntity : BaseEntity
    {
        /// <summary>
        /// Nome do tipo de serviço.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Código do tipo de serviço.
        /// </summary>
        public int Code { get; set; }

        public UserServiceTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public UserServiceTypeEntity()
        {
            
        }
    }
}
