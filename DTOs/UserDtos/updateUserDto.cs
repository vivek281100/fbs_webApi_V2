﻿using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.UserDtos
{
    public class updateUserDto
    {
  
        public int User_Id { get; set; }

       
        public string User_Name { get; set; }

       
        public string Email { get; set; }


       
        public string PhoneNumber { get; set; }
    }
}