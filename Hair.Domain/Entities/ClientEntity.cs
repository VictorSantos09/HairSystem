﻿namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do cliente do salão
    /// </summary>
    public class ClientEntity
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }

        public ClientEntity(string name, string? email, string phoneNumber)
        {
            Name = name.ToUpper();
            Email = email.ToUpper();
            PhoneNumber = phoneNumber;
        }

        public ClientEntity()
        {

        }
    }
}
