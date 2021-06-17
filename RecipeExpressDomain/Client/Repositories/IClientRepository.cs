﻿using System;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Repositories
{
    public interface IClientRepository
    {
        Task<bool> EnrollClient(c.Client client);

        Task<c.Client> GetClient(Guid clientId);
    }
}
