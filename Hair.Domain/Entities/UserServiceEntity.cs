namespace Hair.Domain.Entities
{
    /// <summary>
    /// abstração do serviço fornecido pelo usuário.
    /// </summary>
    public sealed class UserServiceEntity : BaseEntity
    {
        /// <summary>
        /// Tipo de serviço.
        /// </summary>
        public UserServiceTypeEntity Type { get; set; }
        /// <summary>
        /// Id do usuário.
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// Nome do serviço.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Valor do serviço.
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Descrição do serviço.
        /// </summary>
        public string? Description { get; set; }

        public UserServiceEntity(Guid userID, string name, float value, string? description, UserServiceTypeEntity type)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Name = name;
            Value = value;
            Description = description;
            Type = type;
        }

        public UserServiceEntity() { }
    }
}