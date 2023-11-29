using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaAPI_EntityFramework.Database;
using ProvaAPI_EntityFramework.Model;
using ProvaAPI_EntityFramework.Model.Request;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaAPI_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{idUser}")]
        // [Route("{idUser}")]
        public IActionResult GetUserById(int idUser)
        {
            UserEntity user = _userRepository.GetUserById(idUser);

            if (user == null)
                return NotFound();

            UserModel u = MapUserEntityToUserModel(user);

            return Ok(u);
        }

        /*[HttpGet("name")]
        public IActionResult GetUserByName(string name)
        {
            List<UserEntity> users = _userRepository.GetUsersByName(name);

            if (users.Count == 0)
                return NotFound();

            List<UserModel> u = users.Select(MapUserEntityToUserModel).ToList();

            return Ok(u);
        }*/

        /*[HttpGet("surname")]
        public IActionResult GetUserBySurname(string surname)
        {
            List<UserEntity> users = _userRepository.GetUsersBySurname(surname);

            if (users.Count == 0)
                return NotFound();

            List<UserModel> u = users.Select(MapUserEntityToUserModel).ToList();

            return Ok(u);
        }*/

        [HttpGet]
        public IActionResult AllUsers(string? name)
        {
            if(name == null)
            {
                List<UserEntity> allUsers = _userRepository.GetAllUsers();
                List<UserModel> us = allUsers.Select(MapUserEntityToUserModel).ToList();

                return Ok(us);
            }

            List<UserEntity> users = _userRepository.GetUsersByName(name);

            if(users == null)
            {
                return NotFound();
            }

            List<UserModel> u = users.Select(MapUserEntityToUserModel).ToList();

            return Ok(u);   
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequest userRequest)
        {
            var user = new UserEntity
            {
                UserName = userRequest.UserName,
                Password = userRequest.Password,
                Name = userRequest.Name,
                Surname = userRequest.SurName
            };

            _userRepository.AddUser(user);

            return Ok();
        }

        /*[HttpPost("addByLine")]
        public IActionResult AddUser(string username, string password, string name, string surname)
        {
            var user = new UserEntity
            {
                UserName = username,
                Password = password,
                Name = name,
                Surname = surname
            };

            _userRepository.AddUser(user);

            return Ok();
        }*/

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserEntity user)
        {
            _userRepository.UpdateUser(user);

            return Ok(user);
        }

        /*[HttpPut("updateByLine")]
        public IActionResult UpdateUser(int idUser, string username, string password, string name, string surname)
        {
            var user = new UserEntity
            {
                IdUser = idUser,
                UserName = username,
                Password = password,
                Name = name,
                Surname = surname
            };

            _userRepository.UpdateUser(user);

            return Ok(user);
        }*/

        [HttpDelete]
        public IActionResult DeleteUser(int idUser)
        {
            bool result = _userRepository.DeleteUser(idUser);

            if (!result)
                return NotFound();

            return Ok();
        }

        private UserModel MapUserEntityToUserModel(UserEntity user)
        {
            return new UserModel
            {
                IdUser = user.IdUser,
                UserName = user.UserName,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}

