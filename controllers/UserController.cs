    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using code_dotnet.database;
    using code_dotnet.entities;
    using code_dotnet.services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    namespace code_dotnet.controllers
    {
        [ApiController]
        [Route("api/user")]
        public class UserController : ControllerBase
        {
            private readonly ILogger<UserController> _logger;
            private readonly IUserService _userService;
            private readonly string routeBase = "api/user";

            public UserController(ILogger<UserController> logger, IUserService userService)
            {
                _logger = logger;
                _userService = userService;
            }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of users.</returns>
            [HttpGet("list")]
            public async Task<IActionResult> GetUsers()
            {
                _logger.Log(LogLevel.Debug, routeBase+"/list entry");
                var users = await _userService.GetAllUsersAsync();
                if (users == null || !users.Any())
                {
                    _logger.Log(LogLevel.Debug, routeBase+"/list nothing found");
                    return NotFound();
                }
                _logger.Log(LogLevel.Debug, routeBase + "/list response");
                return Ok(users);
            }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="createUserDto">The user data to create.</param>
        /// <returns>A response indicating the result of the operation.</returns>
            [HttpPost("create")]
            public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
            {
                _logger.Log(LogLevel.Debug, routeBase+"/create entry");
                if (createUserDto == null)
                {
                    return BadRequest("Invalid user data.");
                }

                try{
                    await _userService.AddUserAsync(createUserDto);
                    return Ok();
                } catch(Exception ex){
                    return BadRequest("Erro creating user "+ex.Message);
                }
            }

        /// <summary>
        /// Delete one user.
        /// </summary>
        /// <param name="id">The user id to be deleted.</param>
        /// <returns>A response indicating the result of the operation.</returns>
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                _logger.Log(LogLevel.Debug, $"{routeBase} delete user entry with id: {id}");
                UserEntity target = await _userService.GetUserByIdAsync(id);
                if(target.Equals(null)){
                    return NotFound();
                }
                await _userService.DeleteUserAsync(id);
                return Ok();
            }

        /// <summary>
        /// Delete one user.
        /// </summary>
        /// <param name="id">The user id to be deleted.</param>
        /// <returns>A response indicating the result of the operation.</returns>
            [HttpGet("{id}")]
            public async Task<IActionResult> FindUserById(int id)
            {
                _logger.Log(LogLevel.Debug, $"{routeBase} get user by id entry with id: {id}");

                try
                {
                    await _userService.DeleteUserAsync(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error deleting user: {ex.Message}");
                }
            }
        }
    }