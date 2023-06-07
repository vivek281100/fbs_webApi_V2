using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.UserDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace fbs_webApi_v2.services.Authservice
{
    public class AuthRepository : IAuthRepository
    {
        private readonly fbscontext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        private static string message = string.Empty;
        public AuthRepository(fbscontext context, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            this._context = context;
            this._configuration = configuration;
            this._contextAccessor = contextAccessor;
        }

        //get user Id
        private int GetUserId()
        {
            var id = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

        //login
        #region Login
        public async Task<serviceResponce<loginresponce>> Login(string username, string password)
        {
            var responce = new serviceResponce<loginresponce>();
            var user = await _context.users.FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
            if (user == null)
            {
                responce.Success = false;
                responce.Message = "user not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                responce.Success = false;
                responce.Message = "wrong Password";
            }
            else
            {
                var logintoken = CreateToken(user);
                var userStatus = user.IsActive;


                //an object to send token and user status
                var login = new loginresponce();
                login.Token = logintoken;
                login.Status = userStatus;


                responce.Data = login ;

                responce.Message = user.Role;
            }

            return responce;
        }

        #endregion


        //register
        #region register
        public async Task<serviceResponce<int>> Register(User user, string password)
        {

            var responce = new serviceResponce<int>();

            if (await UserExists(user))
            {
                responce.Success = false;
                responce.Message = message;
                return responce;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            _context.users.Add(user);
            await _context.SaveChangesAsync();

            responce.Data = user.Id;
            responce.Message = "User created";
            return responce;

        }

        #endregion


        //Change Password
       public async Task<serviceResponce<string>> changepassword(changepasswordDto passwordform)
        {
            var responce =new serviceResponce<string>();
            var user = await _context.users.Where(u => u.Id == GetUserId()).FirstOrDefaultAsync();

            if(user == null)
            {
                responce.Success = false;
                responce.Message = "try again";
                responce.Data = "user not found";
                return responce;
            }



            CreatePasswordHash(passwordform.password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;

            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            responce.Success = true;
            responce.Message = "password updated!";
            responce.Data = passwordform.password;
            return responce;
        }

        #region User Exits
        public async Task<bool> UserExists(User user)
        {
            if (await _context.users.AnyAsync(u => u.UserName.ToLower() == user.UserName.ToLower()))
            {
                message = "username already exists";
                return true;
            }
            if(await  _context.users.AnyAsync(U => U.Email.ToLower() == user.Email.ToLower()))
            {
                message = "Email already exists";
                return true;
            }
            if(await _context.users.AnyAsync(u => u.PhoneNumber.ToLower() == user.PhoneNumber.ToLower()))
            {
                message = "phone number already exists";
                return true;
            }
            return false;
        }

        #endregion


        #region Change Password
        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmca = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmca.Key;
                PasswordHash = hmca.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion

        #region Verify Password

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmca = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var newHash = hmca.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return newHash.SequenceEqual(passwordHash);
            }
        }
        #endregion


        #region Cerate token
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
           {
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Name,user.UserName)
           };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);

        }
    }
    #endregion






    //class for login responce
    public class loginresponce
    {
        public string Token { get; set; }
        public bool Status { get; set; }
    }
}
