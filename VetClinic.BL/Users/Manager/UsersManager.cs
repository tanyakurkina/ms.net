using AutoMapper;
using VetClinic.BL.Users.Entity;
using VetClinic.BL.Users.Exceptions;
using VetClinic.DataAccess.Entities;
using VetClinic.DataAccess.Repository;

namespace VetClinic.BL.Users.Manager;

public class UsersManager : IUsersManager
{
    private readonly IRepository<User> _usersRepository;
    private readonly IMapper _mapper;
    public UsersManager(IRepository<User> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public UserModel CreateUser(CreateUserModel createModel)
    {
        var entity = _mapper.Map<User>(createModel);
        entity = _usersRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }
    public void DeleteUser(int id)
    {
        try
        {
            var entity = _usersRepository.GetById(id);
            _usersRepository.Delete(entity);
        }
        catch (Exception e)
        {
            throw new UserNotFoundException(e.Message);
        }
    }
    public UserModel UpdateUser(UpdateUserModel updateModel)
    {
        var entity = _mapper.Map<User>(updateModel);
        entity = _usersRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }
}