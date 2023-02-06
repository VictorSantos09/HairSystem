﻿using Microsoft.AspNetCore.Components;
using Hair.Application.Services;
using Hair.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Hair.Application.Dto;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = _loginService.CheckLogin(loginDto.Email.ToUpper(), loginDto.Password);

            if (result._StatusCode == 200)
                return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : new { Successful = true, Id = result._Data });

            return StatusCode(result._StatusCode, new { Message = result._Message, Successful = false });
        }
    }
}
