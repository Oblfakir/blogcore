using System.Collections.Generic;
using blogcore.BLL.Interfaces;
using blogcore.DAL.Interfaces;
using blogcore.Entities;

namespace blogcore.BLL.Implementations
{
    public class UserBLL: IUserBLL
    {
        private readonly IUserDAL _userDal;

        public UserBLL(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public UserEntity GetUserById(int id)
        {
            return _userDal.GetUserById(id);
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _userDal.GetAllUsers();
        }

        public int AddUser(UserEntity user)
        {
            return _userDal.AddUser(user);
        }

        public bool ChangeUser(int id, UserEntity user)
        {
            return _userDal.ChangeUser(id, user);
        }

        public bool DeleteUser(int id)
        {
            return _userDal.DeleteUser(id);
        }
    }
}
