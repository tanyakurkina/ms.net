using AutoMapper;
using VetClinic.BL.Users.Entity;
using VetClinic.BL.Users.Exceptions;
using VetClinic.DataAccess.Entities;
using VetClinic.DataAccess.Repository;

namespace VetClinic.BL.Users.Provider;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UsersProvider(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers(UserFilterModel filter = null)
    {
        // Применяем фильтры
        string? namePart = filter?.NamePart;
        string? emailPart = filter?.EmailPart;
        DateTime? creationTimeFrom = filter?.CreationTimeFrom;
        DateTime? creationTimeTo = filter?.CreationTimeTo;
        DateTime? modificationTimeFrom = filter?.ModificationTimeFrom;
        DateTime? modificationTimeTo = filter?.ModificationTimeTo;
        int? roleId = filter?.RoleId;

        var users = _userRepository.GetAll(); // Получаем всех пользователей

        // Фильтрация в памяти с помощью LINQ
        if (namePart != null)
            users = users.Where(u => (u.Name + " " + u.Surname).Contains(namePart));

        if (emailPart != null)
            users = users.Where(u => u.Email.Contains(emailPart));

        if (creationTimeFrom != null)
            users = users.Where(u => u.CreationTime >= creationTimeFrom);

        if (creationTimeTo != null)
            users = users.Where(u => u.CreationTime <= creationTimeTo);

        if (modificationTimeFrom != null)
            users = users.Where(u => u.ModificationTime >= modificationTimeFrom);

        if (modificationTimeTo != null)
            users = users.Where(u => u.ModificationTime <= modificationTimeTo);

        if (roleId != null)
            users = users.Where(u => u.RoleId == roleId);

        return _mapper.Map<IEnumerable<UserModel>>(users); // Маппинг в UserModel
    }

    public UserModel GetUserInfo(int id)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
        {
            throw new UserNotFoundException($"User with ID {id} not found");
        }
        return _mapper.Map<UserModel>(entity);
    }
}