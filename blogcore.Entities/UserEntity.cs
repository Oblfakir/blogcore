﻿namespace blogcore.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
    }
}
