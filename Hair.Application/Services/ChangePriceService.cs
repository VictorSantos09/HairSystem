﻿using Hair.Application.Common;
using Hair.Application.Interfaces;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class ChangePriceService : IChangePriceService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private double _newPrice;
        private Guid _saloonId;

        public ChangePriceService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto ChangeHaircutePrice(double newPrice, Guid saloonId, bool confirmed, bool hair, bool mustache, bool beard)
        {
            if (!confirmed)
                return new BaseDto(200, "Solicitação cancelada");

            _saloonId = saloonId;
            _newPrice = newPrice;

            if (double.IsNegative(newPrice) == true)
                return new BaseDto(406, "Valor não permitido");

            var saloon = _userRepository.GetById(saloonId);

            if (saloon == null)
                return new BaseDto(404, "Usuário não encontrado");

            var haircutePlace = CheckAndApplyPrice(hair, mustache, beard);

            if (!haircutePlace)
                return new BaseDto(406, "Escolha algum item");

            return new BaseDto(200, "Alteração Concluída");
        }
        private bool CheckAndApplyPrice(bool hair, bool mustache, bool beard)
        {
            if (!beard || !mustache || !beard)
                return false;

            if (hair)
                ApplyHairPrice();

            if (mustache)
                ApplyMustachePrice();


            if (beard)
                ApplyBeardPrice();
            
            return true;
        }
        private void ApplyHairPrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            saloon.PriceEntity.Hair = _newPrice;
        }
        private void ApplyBeardPrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            saloon.PriceEntity.Beard = _newPrice;
        }
        private void ApplyMustachePrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            saloon.PriceEntity.Mustache = _newPrice;
        }
    }
}