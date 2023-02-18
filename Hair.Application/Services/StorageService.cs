using Hair.Application.Common;
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
        private readonly StorageRepository _saloonItem;
        //List<string> storage = new List<string>();   
        public StorageService(StorageRepository saloonItem)
        {
            _saloonItem = saloonItem;
        }



        public BaseDto AddItem(string name, double price, int quantityAvaliable, Guid userId)
        {
            var item = new SaloonItemEntity(name, price, quantityAvaliable, userId);
            _saloonItem.Create(item);
            return new BaseDto(200, "Item adicionado com sucesso");
        }



        //public BaseDto GetItems()
        //{
        //    _saloonItem.GetAll();
        //    return new BaseDto(200, "Exibindo todos os itens");
        //}
        //public BaseDto GetItemsId(Guid itemId)
        //{
        //    _saloonItem.GetById(itemId);
        //    return new BaseDto(200, "Item encontrado");
        //}
    }
}