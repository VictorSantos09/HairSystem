using System.Collections.Generic;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração do usuário.
    /// 
    /// </summary>
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// Nome do salão.
        /// 
        /// </summary>
        public string SaloonName { get; set; }
        /// <summary>
        /// 
        /// Nome do dono.
        /// 
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// 
        /// Telefone do salão.
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// Email do salão.
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// CNPJ do salão.
        /// 
        /// </summary>
        public string? CNPJ { get; set; }
        /// <summary>
        /// 
        /// Senha do usuário.
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// Horário de abertura do salão.
        /// 
        /// </summary>
        public TimeOnly OpenTime { get; set; }
        /// <summary>
        /// 
        /// Horário de fechamento do salão.
        /// 
        /// </summary>
        public TimeOnly CloseTime { get; set; }
        /// <summary>
        /// 
        /// Link do salão no Google Maps.
        /// 
        /// </summary>
        public string? GoogleMapsLocation { get; set; }
        /// <summary>
        /// 
        /// Endereço do salão.
        /// 
        /// </summary>
        public AddressEntity Address { get; set; }
        /// <summary>
        /// 
        /// Serviços agendados.
        /// 
        /// </summary>
        public List<DutyEntity> Haircuts { get; set; } = new List<DutyEntity>();
        /// <summary>
        /// Funcionários cadastrados.
        /// </summary>
        public List<WorkerEntity> Workers { get; set; } = new List<WorkerEntity>();

        public UserEntity(string saloonName, string ownerName, string phoneNumber, string email, string? cNPJ,
            string password, TimeOnly openTime, TimeOnly closeTime, string? googleMapsLocation)
        {
            SaloonName = saloonName;
            OwnerName = ownerName;
            PhoneNumber = phoneNumber;
            Email = email;
            CNPJ = cNPJ;
            Password = password;
            OpenTime = openTime;
            CloseTime = closeTime;
            GoogleMapsLocation = googleMapsLocation;
        }

        public UserEntity()
        {

        }
    }
}