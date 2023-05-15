﻿using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.passengerDtos
{
    public class GetPassengerDto
    {
  
        public string FirstName { get; set; }

     
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }


        public string PhoneNumber { get; set; }
    }
}