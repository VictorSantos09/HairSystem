using Hair.Domain.Common;
using Hair.Domain.Database;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        [Required]
        public string SaloonName { get; set; }
        [Required]
        [MinLength(5)]
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        public DateTime HaircuteTime { get; set; }
        [Required]
        public AdressEntity Adress { get; set; }
        public string? CNPJ { get; set; }
        public HaircutePriceEntity PriceEntity { get; set; }

        public UserEntity(string saloonName, string ownerName, string phoneNumber, string email, string password, AdressEntity adress, string? cnpj, HaircutePriceEntity priceEntity)
        {
            Id = Guid.NewGuid();
            SaloonName = saloonName;
            OwnerName = ownerName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Adress = adress;
            CNPJ = cnpj;
            PriceEntity = priceEntity;
        }

        //public static List<UserEntity> GetAll()          ---> Teste utilzando a lista dinâmica 
        //{
        //    var list = new List<UserEntity>();

        //    using (var conn = new SqlConnection(DbInfo.DBConnection))
        //    {
        //        var cmd = new SqlCommand($"SELECT ID, ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, ADDRESS, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE FROM USERS", conn);
        //        conn.Open();

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var id = reader.GetInt32(0);
        //                list.Add(new UserEntity()
        //                {
        //                    Id = reader.GetGuid(0),
        //                    SaloonName = reader.GetString(1),
        //                    OwnerName = reader.GetString(2),
        //                    PhoneNumber = reader.GetString(3),
        //                    Email = reader.GetString(4),
        //                    Password = reader.GetString(5),
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}



        public UserEntity(Guid Id)
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, ADDRESS, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE = {Id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetGuid(0);
                        SaloonName = reader.GetString(1);
                        OwnerName = reader.GetString(2);
                        PhoneNumber = reader.GetString(3);
                        Email = reader.GetString(4);
                        Password = reader.GetString(5);

                    }
                }
            }
        }

        public UserEntity()
        {
        }

        public void Create()
        {
            using var conn = new SqlConnection(DbInfo.DBConnection);
            var cmd = new SqlCommand($"INSERT INTO USERS (ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, ADDRESS, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE) VALUES ('{Id}', '{SaloonName}', '{OwnerName}', '{PhoneNumber}','{Email}','{Password}','{Adress}', '{CNPJ}','{PriceEntity}'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var querry = $"UPDATE USERS SET SALOON_NAME = '{SaloonName}', OWNER_NAME = {OwnerName}, PHONE_NUMBER = {PhoneNumber}, EMAIL = {Email}, PASSWORD = {Password}, ADDRESS = {Adress}, CNPJ = {CNPJ}, HAIRCUT_TIME = {HaircuteTime}, HAIRCUT_PRICE = {PriceEntity}') WHERE ID = {Id}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void Delete()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM USERS WHERE ID = {Id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}