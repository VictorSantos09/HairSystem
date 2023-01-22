﻿using Hair.Domain.Entities;
using System.Data.Common;
using Dapper;
using System.Data.SqlClient;
using Hair.Repository.DataBase;
using static Dapper.SqlMapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso de usuarios da entidade <see cref="UserEntity"/>
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository() : base("User")
        {

        }
        public UserEntity? GetByEmail(string email, string password)
        {
            return GetAll().Find(x => x.Email == email.ToUpper() && x.Password == password);
        }
    }
}