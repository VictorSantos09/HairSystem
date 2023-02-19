using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Services
{

    public class StorageService
    {
        private readonly UserRepository _userRepository;
        private readonly StorageRepository _saloonItem;
        //List<string> storage = new List<string>();   
        public StorageService(StorageRepository saloonItem, UserRepository userRepository)
        {
            _saloonItem = saloonItem;
            _userRepository = userRepository;
        }

        public BaseDto AddItem(string name, double price, int quantityAvaliable, Guid userId)
        {
            if (quantityAvaliable <= 0)
            return BaseDtoExtension.Invalid("Quantidade deve ser maior que 0 (zero)");

            if (name == null)
            return BaseDtoExtension.NotNull("Nome do produto");

            if (price <= 0)
                return BaseDtoExtension.Invalid("O valor do Produto deve ser superior a R$0,00");

            var item = new SaloonItemEntity(name, price, quantityAvaliable, userId);
            _saloonItem.Create(item);
            var user = _userRepository.GetById(userId);
            if (user != null)
                return BaseDtoExtension.NotFound();

            //user.Itens.Add(item);             { Métodos descartados pelas mudanças na StorageRepository
            //_userRepository.Update(user);     }   
            return BaseDtoExtension.Sucess();
        }
        public BaseDto GetItems(Guid userId)
        {
            // A linha 51 substitui a instância da List<SaloonItemEntity>
            var itemList = _saloonItem.GetAll().FindAll(x => x.Id == userId); // Pega todos os itens do DB e filtra pelo ID do usuário
            if (itemList.Count == 0)
                return BaseDtoExtension.Sucess("Nenhum item foi encontrado");
           
            return BaseDtoExtension.Create(200, "Exibindo todos os itens", itemList);
        }
    }
}