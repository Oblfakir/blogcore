using System.Collections.Generic;
using blogcore.Entities;

namespace blogcore.DAL.Interfaces
{
    public interface IUserDAL
    {
        UserEntity GetUserById(int id);
        IEnumerable<UserEntity> GetAllUsers();
        int AddUser(UserEntity user);
        bool ChangeUser(int id, UserEntity user);
        bool DeleteUser(int id);
    }
}
