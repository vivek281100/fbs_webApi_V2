﻿namespace fbs_webApi_v2.DTOs.UserDtos
{
    public class GetUserWithoutPasswordDto
    {
        public int Id { get; set; }
        public string User_Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
