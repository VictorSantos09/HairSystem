using Hair.Domain.Entities;

namespace Hair.Repository
{
    internal class AddressEntityFromSql : BaseEntity
    {
        /// <summary>
        /// 
        /// Rua.
        /// 
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 
        /// Número do estabelecimento.
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// Cidade.
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// Estado.
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// Complemento do endereço.
        /// 
        /// </summary>
        public string? Complement { get; set; }
        /// <summary>
        /// 
        /// Endereço completo.
        /// 
        /// </summary>
        public string Full_Address { get; set; }
        /// <summary>
        /// 
        /// CEP.
        /// 
        /// </summary>
        public string CEP { get; set; }
    }
}
