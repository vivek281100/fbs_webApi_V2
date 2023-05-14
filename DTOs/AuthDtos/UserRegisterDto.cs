namespace fbs_webApi_v2.DTOs.AuthDtos
{
    public class UserRegisterDto
    {

        public string UserName { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string phonenumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
