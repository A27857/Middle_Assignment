using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Middle_Assignments.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Middle_Assignments.Models.Users;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace Middle_Assignments.Controllers
{
    [Authorize]
    [ApiController]
    //[Route("server/[controller]")]
    //[Authorize(AuthenticationSchemes = "AuthenticatedUserSchemeName", Policy = "AuthorizedUserPolicyName")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config;
        private IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.UserId,
                Username = user.UserName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _userService.CreateUser(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("gets")]
        public List<User> GetAllUser()
        {
            return _userService.GetAllUser();
        }

        [HttpGet]
        [Route("get/{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPut]
        [Route("put/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserModel model)
        {
                var user = _mapper.Map<User>(model);
                user.UserId = id;
                try
                {
                    // update user 
                    _userService.UpdateUser(user, model.Password);
                    return Ok();
                }
                catch (AppException ex)
                {
                    // return error message if there was an exception
                    return BadRequest(new { message = ex.Message });
                }
            // map model to entity and set id
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _userService.DeleteUserById(id);
            return Ok();
        }

        // public string Generate(User user)
        // {
        //     List<Claim> claims = new List<Claim>() {
        //         new Claim (JwtRegisteredClaimNames.Jti,
        //             Guid.NewGuid().ToString()),

        //         new Claim (JwtRegisteredClaimNames.Sub,
        //         user.UserId.ToString()),

        //         new Claim (JwtRegisteredClaimNames.Sub,
        //         user.UserName.ToString()),

        //         new Claim (JwtRegisteredClaimNames.Sub,
        //         user.UserRole.ToString()),

        //         new Claim (ClaimTypes.Role, user.UserRole)
        // };
        //     var tokenDecriptontor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(claims)
        //     };

        //     var accessToken = new JwtSecurityTokenHandler();
        //     var token = accessToken.CreateToken(tokenDecriptontor);

        //     return accessToken.WriteToken(token);
        // }
    }
}