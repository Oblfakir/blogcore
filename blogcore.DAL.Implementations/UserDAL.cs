using System.Collections.Generic;
using System.Data;
using blogcore.DAL.Interfaces;
using blogcore.Entities;
using MySql.Data.MySqlClient;

namespace blogcore.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public UserEntity GetUserById(int id)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetUserById"
                };

                command.Parameters.AddWithValue("@userId", id);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new UserEntity(reader);
                }

                return null;
            }
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetAllUsers"
                };

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new UserEntity(reader);
                }
            }
        }

        public int AddUser(UserEntity user)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "AddUser"
                };

                user.SetCommandParameters(command);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return int.Parse(reader["id"].ToString());
                }

                return -1;
            }
        }

        public bool ChangeUser(int id, UserEntity user)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ChangeUser"
                };

                command.Parameters.AddWithValue("@userId", id);
                user.SetCommandParameters(command);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteUser"
                };

                command.Parameters.AddWithValue("@userId", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
