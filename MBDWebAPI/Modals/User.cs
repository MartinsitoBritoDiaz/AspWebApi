﻿namespace MBDWebAPI.Modals
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string[] Roles { get; set; } = new string[0];
        public string Password { get; set; } = string.Empty;
    }
}
