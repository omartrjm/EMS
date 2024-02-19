﻿

using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using Constants = ServerLibrary.Helpers.Constants;

namespace ServerLibrary.Repositories.Implementations
{
    internal class UserAccountRepository(IOptions<JwtSection> config, AppDbContext appDbContext) : IUserAccount
    {
        public async Task<GeneralResponse> CreatAsync(Register user)
        {
            if (user is null) return new GeneralResponse(false,"Model is empty");

            var checkUser = await FindUserByEmail(user.Email!);
            if (checkUser != null) return new GeneralResponse(false,"User Registered Already");

            // save user
            var applicationUser = await AddToDatabase(new ApplicationUser()
                { 
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
                });

            // check, creat and assign role
            var checkAdminRole = await appDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.Admin));
            if (checkAdminRole is null)
            {
                var createAdminRole = await AddToDatabase(new SystemRole() {Name = Constants.Admin });
                await AddToDatabase(new UserRole() { RoleId = createAdminRole.Id, UserId = applicationUser.Id });
                return new GeneralResponse(true,"Account created");
            }

            var checkUserRole = await appDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.User));
            SystemRole response = new();
            if (checkUserRole is null) 
            {
                response 
            }

        }   

        public Task<LoginResponse> SignInAsync(Login user)
        {
            throw new NotImplementedException();
        }

        private async Task<ApplicationUser> FindUserByEmail(string email) =>
            await appDbContext.ApplicationUsers.FirstOrDefaultAsync(_ => _.Email!.ToLower()!.Equals(email!.ToLower()));

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = appDbContext.Add(model!);
            await appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }
    }
}
