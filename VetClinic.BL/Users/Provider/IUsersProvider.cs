using VetClinic.BL.Users.Entity;

namespace VetClinic.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(UserFilterModel filter = null);
    UserModel GetUserInfo(int id);
}