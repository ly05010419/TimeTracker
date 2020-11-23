﻿using System.Threading.Tasks;

namespace TimeTracker.Services.Account
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username,string password);
    }
}