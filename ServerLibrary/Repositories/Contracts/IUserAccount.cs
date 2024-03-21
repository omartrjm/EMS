﻿using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;


namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        // User Login
        Task<GeneralResponse> CreatAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
        Task<List<ManageUser>> GetUsers();
        Task<GeneralResponse> UpdateUser(ManageUser user);
        Task<List<SystemRole>> GetRoles();
        Task<GeneralResponse> DeleteUser(int id);
    }
}
