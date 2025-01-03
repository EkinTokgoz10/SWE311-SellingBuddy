﻿using IdentityService.Api.Application.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityService.Api.Application.Services
{
    public class IdentityService : IIdentityService
    {
        string secretKey = "SellingBuddyMockSecretKeyShouldBeLong";

        public Task<LoginResponseModel> Login(LoginRequestModel model)
        {
            // DB process will be here. Check if session info is valid and get user details

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, model.UserName),
            new Claim(ClaimTypes.Name, "Ekin Tokgoz")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims, expires: expiry, signingCredentials: credentials, notBefore: DateTime.Now);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponseModel response = new()
            {
                UserToken = encodedJwt,
                UserName = model.UserName
            };

            return Task.FromResult(response);
        }
    }
}
