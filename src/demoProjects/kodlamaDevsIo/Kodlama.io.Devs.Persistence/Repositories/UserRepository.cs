﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, KodlamaIoContext>, IUserRepository
{
    public UserRepository(KodlamaIoContext context) : base(context)
    {
    }
}