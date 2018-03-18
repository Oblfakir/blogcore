using MySql.Data.MySqlClient;

namespace blogcore.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {

        }

        public UserEntity(MySqlDataReader reader)
        {
            Id = (int)reader["Id"];
            Role = reader["Role"].ToString();
            Password = reader["Password"].ToString();
            Username = reader["Username"].ToString();
            AvatarPath = reader["AvatarPath"].ToString();
        }

        public void SetCommandParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@userRole", Role);
            command.Parameters.AddWithValue("@userUsername", Username);
            command.Parameters.AddWithValue("@userPassword", Password);
            command.Parameters.AddWithValue("@userAvatarPath", AvatarPath);
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
    }
}
