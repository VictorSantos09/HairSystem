﻿using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ChangePriceController : ControllerBase
    {
        private readonly ChangePriceService _changePrice;
        private readonly IBaseRepository<IUser> _userRepository;

        public ChangePriceController(IBaseRepository<IUser> userRepository)
        {
            _userRepository = userRepository;
            _changePrice = new ChangePriceService(_userRepository);
        }

        [HttpPost]
        [Route("ChangeHaircutePrice")]
        public IActionResult ChangePrice(ChangePriceDto dto)
        {
            var result = _changePrice.ChangeHaircutePrice(dto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
    }
}