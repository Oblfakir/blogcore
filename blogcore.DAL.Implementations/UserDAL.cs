using System.Collections.Generic;
using blogcore.DAL.Interfaces;
using blogcore.Entities;

namespace blogcore.DAL.Implementations
{
    public class UserDAL: IUserDAL
    {
        public UserEntity GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<UserEntity> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public int AddUser(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public bool ChangeUser(int id, UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
