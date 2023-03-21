namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do tipo de função do funcionário.
    /// </summary>
    public sealed class FunctionTypeEntity : BaseEntity
    {
        /// <summary>
        /// Nome da função.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Código da função.
        /// </summary>
        public int Code { get; set; }

        public FunctionTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public FunctionTypeEntity()
        {

        }
    }
}