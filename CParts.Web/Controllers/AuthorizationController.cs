﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CParts.Domain.Core.Model.Internal;
using CParts.Services.Abstractions.Internal;
using CParts.Services.Abstractions.Internal.ViewModels;
using CParts.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CParts.Web.Controllers
{
    [Route("api/v1/auth")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationServiceMapper _authorizationServiceMapper; 
        
        public AuthorizationController(IAuthorizationServiceMapper authorizationServiceMapper)
        {
            _authorizationServiceMapper = authorizationServiceMapper;
        }

        [HttpPost]
        [OnlyAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(await _authorizationServiceMapper.RegisterUserAsync(registerModel));
        }

        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeViewModel passwordChangeViewModel)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgottenPasswordViewModel forgotPasswordModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [OnlyAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] SignInViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Some parameters are missing or have invalid values");
            return Ok(await _authorizationServiceMapper.LoginAndGenerateTokenAsync(model));
        }
    }
}