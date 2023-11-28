﻿using System;
using Microsoft.EntityFrameworkCore;

namespace ProvaAPI_EntityFramework.Database
{
	public class UserRepository
	{
		private readonly MyDbContext _dbContext;

		public UserRepository(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<UserEntity> GetAllUsers()
		{
			return _dbContext.Users.ToList();
		}

        public UserEntity GetUsersById(int idUser)
        {
			var user = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);

			return user;
        }

        public List<UserEntity> GetUsersByName(string name)
        {
			var users = _dbContext.Users.Where(u => u.Name == name).ToList();

			return users;
        }

        public List<UserEntity> GetUsersBySurname(string surname)
        {
            var users = _dbContext.Users.Where(u => u.Surname == surname).ToList();

            return users;
        }

		public void AddUser(UserEntity user)
		{
			_dbContext.Users.Add(user);
			_dbContext.SaveChanges();
		}

        public void DeleteUser(int idUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);

			if(user != null)
			{
				_dbContext.Users.Remove(user);
				_dbContext.SaveChanges();
			}
        }

		public void UpdateUser(UserEntity user)
		{
			var existingUser = _dbContext.Users.FirstOrDefault(u => u.IdUser == user.IdUser);

			if(existingUser != null)
			{
				existingUser.UserName = user.UserName;
				existingUser.Password = user.Password;
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;

				_dbContext.SaveChanges();
            }
		}
    }
}
