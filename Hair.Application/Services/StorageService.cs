using Hair.Application.Common;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
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
        private readonly IBaseRepository<SaloonItemEntity> _saloonItem;
        //List<string> storage = new List<string>();   
        public StorageService(IBaseRepository<SaloonItemEntity> saloonItem)
        {
            _saloonItem = saloonItem;
        }
        public BaseDto AddItem(string name, double price, int quantityAvaliable, Guid itemId)
        {
            var item = new SaloonItemEntity(name, price, quantityAvaliable);
            _saloonItem.Add(item);
            return new BaseDto(200, "Item adicionado com sucesso");
        }
        public BaseDto GetItems()
        {
            _saloonItem.GetAll();
            return new BaseDto(200, "Exibindo todos os itens");
        }
        public BaseDto GetItemsId(Guid itemId)
        {
            _saloonItem.GetById(itemId);
            return new BaseDto(200, "Item encontrado");
        }
    }
}