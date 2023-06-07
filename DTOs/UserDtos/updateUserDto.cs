using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.UserDtos
{
    public class updateUserDto
    {

        public int User_Id { get; set; }


        public string UserName { get; set; }

       
        public string Email { get; set; }


       
        public string PhoneNumber { get; set; }
    }
}
