﻿using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.AdminDtos
{
    public class GetAdminDto
    {
        
        public int Admin_Id { get; set; }


        public string Admin_Name { get; set; }

        public string Password { get; set; }

        public string Email_Id { get; set; }
    }
}