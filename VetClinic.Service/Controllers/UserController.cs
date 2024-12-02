using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.BL.Users.Entity;
using VetClinic.BL.Users.Manager;
using VetClinic.BL.Users.Provider;
using VetClinic.Service.Controllers.Entities.UserEntities;
using VetClinic.Service.Validation.User;

namespace VetClinic.Service.Controllers;

public class UsersController : ControllerBase
{
    private readonly IUsersManager _usersManager;
    private readonly IUsersProvider _usersProvider;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    public UsersController(IUsersManager usersManager, IUsersProvider usersProvider,
        IMapper mapper, ILogger logger)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
        _logger = logger;
    }
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = new RegisterUserRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createUserModel = _mapper.Map<CreateUserModel>(request);
            var userModel = _usersManager.CreateUser(createUserModel);
            return Ok(new UsersResponse()
            {
                Users = [userModel]
            });
        }
        _logger.LogError(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _usersProvider.GetUsers();
        return Ok(new UsersResponse()
        {
            Users = users.ToList()
        });
    }
    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromBody] UserFilter filter)
    {
        var userFilterModel = _mapper.Map<UserFilterModel>(filter);
        var users = _usersProvider.GetUsers(userFilterModel);
        return Ok(new UsersResponse()
        {
            Users = users.ToList()
        });
    }
}