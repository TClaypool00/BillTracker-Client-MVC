using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class UserService : IUserService, IGeneralService
    {
        private readonly BillTrackerContext _billTrackerContext;

        public UserService(BillTrackerContext billTrackerContext)
        {
            _billTrackerContext = billTrackerContext;
        }

        public Task AddUserAsync(RegisterModel model)
        {
            //var user = Mapper.MapUser(model, null, true);

            //if (user.IsAdmin)
            //{
            //    user.IsAdmin = false;
            //}

            //await _billTrackerContext.Users.AddAsync(user);
            //await SaveAsync();

            throw new NotImplementedException();
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            return _billTrackerContext.Users.AnyAsync(a => a.Email == email);
        }

        public Task<UserModel> GetUserByEmailAsync(string email)
        {
            //var dataUser = await _billTrackerContext.Users.FirstOrDefaultAsync(a => a.Email == email);

            //return dataUser == null ? null : Mapper.MapUser(dataUser, true);

            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByIdAsync(int id)
        {
            //return Mapper.MapUser(await GetUserAsync(id));

            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetUsersAsync(int index)
        {
            //var dataUsers = await _billTrackerContext.Users.ToListAsync();
            //var users = new List<UserModel>();
            //User user;

            //for (int i = 0; i < dataUsers.Count; i++)
            //{
            //    user = dataUsers[i];
            //    users.Add(Mapper.MapUser(user));
            //}

            //return users;

            throw new NotImplementedException();
        }

        public Task<bool> PhoneNumberExistsAsync(string phoneNumber)
        {
            return _billTrackerContext.Users.AnyAsync(a =>a.PhoneNumber == phoneNumber);
        }

        public async Task RemoveUserAsync(int id)
        {
            _billTrackerContext.Users.Remove(await GetUserAsync(id));
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _billTrackerContext.SaveChangesAsync();
        }

        public Task<UserModel> UpdateUserAsync(int id, UserModel model)
        {
            //var oldUser = await GetUserAsync(id);
            //var newUser = Mapper.MapUser(model);

            //_billTrackerContext.Entry(oldUser).CurrentValues.SetValues(newUser);

            //await SaveAsync();

            //return model;

            throw new NotImplementedException();
        }

        public Task<bool> UserExistsByIdAsync(int id)
        {
            return _billTrackerContext.Users.AnyAsync(a => a.UserId == id);
        }

        private Task<User> GetUserAsync(int id)
        {
            return _billTrackerContext.Users.FirstOrDefaultAsync(a => a.UserId == id);
        }
    }
}
