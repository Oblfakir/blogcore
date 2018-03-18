using System.Collections.Generic;
using blogcore.Entities;

namespace blogcore.BLL.Interfaces
{
    public interface IUserBLL
    {
        UserEntity GetUserById(int id);
        List<UserEntity> GetAllUsers();
        int AddUser(UserEntity user);
        bool ChangeUser(int id, UserEntity user);
        bool DeleteUser(int id);
    }
}
