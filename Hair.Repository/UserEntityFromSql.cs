using Hair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Repository
{
    internal class UserEntityFromSql : BaseEntity
    {
        public string SaloonName { get; set; }
        public byte[] OwnerName { get; set; }
        public byte[] PhoneNumber { get; set; }
        public byte[] Email { get; set; }
        public byte[]? CNPJ { get; set; }
        public byte[] Password { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string? GoogleMapsSource { get; set; }
        public AddressEntity Address { get; set; } = new AddressEntity();
        public HaircutPriceEntity Prices { get; set; } = new HaircutPriceEntity();
        public List<HaircutEntity> Haircuts { get; set; } = new();

        public UserEntityFromSql(string saloonName, byte[] ownerName, byte[] phoneNumber, byte[] email, byte[]? cNPJ, byte[] password, TimeOnly openTime, 
            TimeOnly closeTime, string? googleMapsSource, 
            AddressEntity address, HaircutPriceEntity prices, List<HaircutEntity> haircuts)
        {
            SaloonName = saloonName;
            OwnerName = ownerName;
            PhoneNumber = phoneNumber;
            Email = email;
            CNPJ = cNPJ;
            Password = password;
            OpenTime = openTime;
            CloseTime = closeTime;
            GoogleMapsSource = googleMapsSource;
            Address = address;
            Prices = prices;
            Haircuts = haircuts;
        }

        public UserEntityFromSql()
        {
            
        }
    }
}
