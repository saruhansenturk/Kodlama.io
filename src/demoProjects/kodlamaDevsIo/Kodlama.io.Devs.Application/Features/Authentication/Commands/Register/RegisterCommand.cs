﻿using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.Dtos;
using Kodlama.io.Devs.Application.Features.Authentication.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Authentication.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationBusinessRules _authenticationBusinessRules;
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService, AuthenticationBusinessRules authenticationBusinessRules, IUserRepository userRepository)
        {
            _authService = authService;
            _authenticationBusinessRules = authenticationBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authenticationBusinessRules.UserNotDuplicatedWhenRegister(request.UserForRegisterDto.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

            User newUser = new()
            {
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                LastName = request.UserForRegisterDto.LastName,
                FirstName = request.UserForRegisterDto.FirstName,
                Status = true
            };

            User createdUser = await _userRepository.AddAsync(newUser);
            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);

            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);


            RegisteredDto registeredDto = new()
            {
                RefreshToken = addedRefreshToken,
                AccessToken = createdAccessToken
            };
            return registeredDto;
        }
    }
}