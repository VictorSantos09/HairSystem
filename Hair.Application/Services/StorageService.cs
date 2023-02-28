using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
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
            var user = _userRepository.GetById(userId);
            if (user != null)
                return BaseDtoExtension.NotFound();

            _saloonItem.Create(item);
            return BaseDtoExtension.Sucess();
        }
        public BaseDto GetItems(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
                return BaseDtoExtension.NotFound();
            var itemList = _saloonItem.GetAll().FindAll(x => x.Id == userId);
            if (itemList.Count == 0)
                return BaseDtoExtension.Sucess("Nenhum item foi encontrado");
            return BaseDtoExtension.Create(200, "Exibindo todos os itens", itemList);
        }
        public BaseDto RemoveItems(Guid userId, string itemName, int itemAmount, Guid itemId)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
                return BaseDtoExtension.NotFound();
            var item = user.Itens.Find(x => x.Id == itemId && x.Name == itemName && x.QuantityAvaible == itemAmount);

            if (item == null)
                return BaseDtoExtension.NotFound("Item");
            _saloonItem.Remove(item.Id);

            return BaseDtoExtension.Sucess("Item removido com sucesso");
        }
    }
}