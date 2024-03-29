﻿using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.EntitiesSql;
using Hair.Repository.Interfaces;
using Hair.Repository.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade worker contida em <see cref="WorkerEntity"/>.
    /// </summary>
    public class WorkerRepository : IBaseRepository<WorkerEntity>
    {
        public void Create(WorkerEntity worker)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spCreateworker @ID, @NAME, @PHONE_NUMBER, @EMAIL, @SALARY, @HIRED, @SALOON_ID, @ADDRESS_FK," +
                    "@STREET, @NUMBER, @CITY, @STATE, @COMPLEMENT, @CEP", new
                    {
                        ID = worker.Id,
                        NAME = CryptoSecurity.Encrypt(worker.Name),
                        PHONE_NUMBER = CryptoSecurity.Encrypt(worker.PhoneNumber),
                        EMAIL = CryptoSecurity.Encrypt(worker.Email),
                        SALARY = worker.Salary,
                        SALOON_ID = worker.UserID,
                        ADDRESS_FK = worker.Address.Id,

                        STREET = worker.Address.Street,
                        NUMBER = worker.Address.Number,
                        CITY = worker.Address.City,
                        STATE = worker.Address.State,
                        COMPLEMENT = worker.Address.Complement,
                        CEP = worker.Address.CEP
                    });
            }
        }

        public  List<WorkerEntity> GetAll()
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return conn.Query<WorkerEntity>("dbo.spGetAllWorkers").ToList();
            }
        }

        public WorkerEntity? GetById(Guid id)
        {
            var output = new WorkerEntity();
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var workerSql = conn.Query<WorkerEntityFromSql>("dbo.spGetWorkerById", new { ID = id }).FirstOrDefault();

                if (workerSql == null)
                    return null;
                
                var workerAddress = ConvertAddress(conn.Query<AddressEntityFromSql>("dbo.spGetWorkerAddress", new { ID = id }).FirstOrDefault());

                output.PhoneNumber = workerSql.Phone_Number;
                output.Id = workerSql.Id;
                output.Address = workerAddress;
                output.Email = workerSql.Email;
                output.Name = workerSql.Name;
                output.UserID = workerSql.User_ID;
                output.Salary = workerSql.Salary;

            }
            return output;
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spDeleteWorker", new { ID = id});

            }
            return true;
        }

        public void Update(WorkerEntity worker)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateWorker @ID, @NAME, @PHONE_NUMBER, @EMAIL, @SALARY, @HIRED, @SALOON_ID, @ADDRESS_FK," +
                    "@STREET, @NUMBER, @CITY, @STATE, @COMPLEMENT, @CEP", new
                    {
                        ID = worker.Id,
                        NAME = CryptoSecurity.Encrypt(worker.Name),
                        PHONE_NUMBER = CryptoSecurity.Encrypt(worker.PhoneNumber),
                        EMAIL = CryptoSecurity.Encrypt(worker.Email),
                        SALARY = worker.Salary,
                        SALOON_ID = worker.UserID,
                        ADDRESS_FK = worker.Address.Id,
                        STREET = worker.Address.Street,
                        NUMBER = worker.Address.Number,
                        CITY = worker.Address.City,
                        STATE = worker.Address.State,
                        COMPLEMENT = worker.Address.Complement,
                        CEP = worker.Address.CEP
                    });
            }
        }

        private AddressEntity ConvertAddress(AddressEntityFromSql addressSql)
        {
            return new AddressEntity(addressSql.Street, addressSql.Number, addressSql.City, addressSql.State, addressSql.Complement, addressSql.CEP, addressSql.Id);
        }
    }
}