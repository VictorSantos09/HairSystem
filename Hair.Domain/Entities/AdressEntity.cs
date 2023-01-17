using Hair.Domain.Database;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Hair.Domain.Entities
{
    public class AdressEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string? Complement { get; set; }
        public AdressEntity(string street, string number, string city, string state, string? complement)
        {
            Id = Guid.NewGuid();
            Street = street;
            Number = number;
            City = city;
            State = state;
            Complement = complement;
        }

        public AdressEntity(Guid Id)
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, STREET, NUMBER, CITY, STATE, COMPLEMENT WHERE ID = {Id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetGuid(0);
                        Street = reader.GetString(1);
                        Number = reader.GetString(2);
                        City = reader.GetString(3);
                        State = reader.GetString(4);
                        Complement = reader.GetString(5);

                    }
                }
            }
        }

        public void Create()
        {
            using var conn = new SqlConnection(DbInfo.DBConnection);
            var cmd = new SqlCommand($"INSERT INTO ADDRESSES (ID, STREET, NUMBER, CITY, STATE, COMPLEMENT) VALUES ('{Guid.NewGuid}', 'Rua 2', '450', 'Blumenau', 'Santa Catarina', 'Ao lado do posto''", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        //public void Update()
        //{
        //    using (var conn = new SqlConnection(DbInfo.DBConnection))
        //    {
        //        var querry = $"UPDATE ADDRESSES SET ID = '{SaloonName}', OWNER_NAME = {OwnerName}, PHONE_NUMBER = {PhoneNumber}, EMAIL = {Email}, PASSWORD = {Password}, ADDRESS = {Adress}, CNPJ = {CNPJ}, HAIRCUT_TIME = {HaircuteTime}, HAIRCUT_PRICE = {PriceEntity}') WHERE ID = {Id}";
        //        var cmd = new SqlCommand(querry, conn);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }

        //}
        //public void Delete()
        //{
        //    using (var conn = new SqlConnection(DbInfo.DBConnection))
        //    {
        //        var cmd = new SqlCommand($"DELETE FROM USERS WHERE ID = {Id}", conn);
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
