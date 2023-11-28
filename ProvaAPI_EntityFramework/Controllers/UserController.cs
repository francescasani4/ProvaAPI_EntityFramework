using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult AllUser(int? gender)
        {
                List<UserEntity> users = _userRepository.GetAllUsers();
                List<UserModel> u = users.Select(MapUserEntityToUserModel).ToList();
                return Ok(users);
            
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

