using System;
using Microsoft.EntityFrameworkCore;

namespace ProvaAPI_EntityFramework.Database
{
	public class UserRepository
	{
        //private readonly MyDbContext _dbContext;
        private readonly FakeDatabase _fakeDatabase;

        public UserRepository() //MyDbContext dbContext
        {
			//_dbContext = dbContext;
			_fakeDatabase = FakeDatabaseSingleton.Instance;
		}

		public List<UserEntity> GetAllUsers()
		{
			//return _dbContext.Users.ToList();
            return _fakeDatabase.Users.ToList();
        }

        public UserEntity GetUserById(int idUser)
        {
            //var user = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);
            var user = _fakeDatabase.Users.FirstOrDefault(u => u.IdUser == idUser);

            return user;
        }

        public List<UserEntity> GetUsersByName(string name)
        {
			//var users = _dbContext.Users.Where(u => u.Name == name).ToList();
            var users = _fakeDatabase.Users.Where(u => u.Name == name).ToList();

            return users;
        }

        public List<UserEntity> GetUsersBySurname(string surname)
        {
            //var users = _dbContext.Users.Where(u => u.Surname == surname).ToList();
            var users = _fakeDatabase.Users.Where(u => u.Surname == surname).ToList();

            return users;
        }

		public void AddUser(UserEntity user)
		{
            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();
            _fakeDatabase.AddUser(user);
        }

        public bool DeleteUser(int idUser)
        {
            //var user = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);
            var user = _fakeDatabase.Users.FirstOrDefault(u => u.IdUser == idUser);
            var flag = false;

            if (user != null)
			{
                //_dbContext.Users.Remove(user);
                //_dbContext.SaveChanges();
                _fakeDatabase.Users.Remove(user);
                flag = true;
            }

            return flag;
        }

		public void UpdateUser(UserEntity user)
		{
			//var existingUser = _dbContext.Users.FirstOrDefault(u => u.IdUser == user.IdUser);
            var existingUser = _fakeDatabase.Users.FirstOrDefault(u => u.IdUser == user.IdUser);

            if (existingUser != null)
			{
				existingUser.UserName = user.UserName;
				existingUser.Password = user.Password;
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;

				//_dbContext.SaveChanges();
            }
		}
    }
}

