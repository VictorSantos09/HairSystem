﻿using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="HaircutEntity"/>.
    /// </summary>
    public class HaircutRepository : IBaseRepository<HaircutEntity>
    {
        private readonly static string TableName = "HAIRCUTS";
        public HaircutRepository()
        {
        }
        public void Create(HaircutEntity haircut)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO {TableName} VALUES (@SALOON_ID, @HAIRCUT_TIME, @AVAILABLE, @CLIENT_NAME, @CLIENT_EMAIL, @CLIENT_PHONE_NUMBER, @ID)", conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@SALOON_ID", haircut.SaloonId);
                cmd.Parameters.AddWithValue("@HAIRCUT_TIME", haircut.HaircuteTime);
                cmd.Parameters.AddWithValue("@AVAILABLE", haircut.Available);
                cmd.Parameters.AddWithValue("@CLIENT_NAME", haircut.Client.Name);
                cmd.Parameters.AddWithValue("@CLIENT_EMAIL", haircut.Client.Email);
                cmd.Parameters.AddWithValue("@CLIENT_PHONE_NUMBER", haircut.Client.PhoneNumber);
                cmd.Parameters.AddWithValue("@ID", haircut.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(HaircutEntity haircut)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"UPDATE {TableName} SET " +
                    $"SALOON_ID = @SALOON_ID, " +
                    $"HAIRCUT_TIME = @HAIRCUT_TIME, " +
                    $"AVAILABLE = @AVAILABLE, " +
                    $"CLIENT_NAME = @CLIENT_NAME," +
                    $" CLIENT_EMAIL = @CLIENT_EMAIL, " +
                    $"CLIENT_PHONE_NUMBER = @CLIENT_PHONE_NUMBER " +
                    $"WHERE ID = @ID";

                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@SALOON_ID", haircut.SaloonId);
                cmd.Parameters.AddWithValue("@HAIRCUT_TIME", haircut.HaircuteTime);
                cmd.Parameters.AddWithValue("@AVAILABLE", haircut.Available);
                cmd.Parameters.AddWithValue("@CLIENT_NAME", haircut.Client.Name);
                cmd.Parameters.AddWithValue("@CLIENT_EMAIL", haircut.Client.Email);
                cmd.Parameters.AddWithValue("@CLIENT_PHONE_NUMBER", haircut.Client.PhoneNumber);
                cmd.Parameters.AddWithValue("@ID", haircut.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public bool Remove(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"DELETE FROM {TableName} WHERE ID= @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();

                var affectRows = cmd.ExecuteNonQuery();

                if (affectRows == 0)
                    return false;

                return true;
            }
        }
        public List<HaircutEntity> GetAll()
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var haircuts = new List<HaircutEntity>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HaircutEntity haircut = BuildEntity(reader);

                        haircuts.Add(haircut);
                    }
                }

                return haircuts;
            }
        }
        public HaircutEntity? GetById(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName} WHERE Id= @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                return BuildEntity(cmd.ExecuteReader());
            }
        }

        private HaircutEntity? BuildEntity(SqlDataReader reader)
        {
            HaircutEntity? haircut = new HaircutEntity();

            while (reader.Read())
            {
                haircut.Id = reader.GetGuid("ID");
                haircut.SaloonId = reader.GetGuid("SALOON_ID");
                haircut.Available = reader.GetBoolean(reader.GetString("AVAILABLE"));
                haircut.HaircuteTime = reader.GetDateTime(reader.GetString("HAIRCUT_TIME"));
                haircut.Client.PhoneNumber = reader.GetString(reader.GetString("CLIENT_PHONE_NUMBER"));
                haircut.Client.Email = reader.GetString(reader.GetString("CLIENT_EMAIL"));
                haircut.Client.Name = reader.GetString(reader.GetString("CLIENT_NAME"));

            }
            return haircut.Id == Guid.Empty ? null : haircut;
        }
    }
}