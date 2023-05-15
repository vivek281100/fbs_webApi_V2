using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace fbs_webApi_v2.services.Authservice
{
    public class AuthRepository : IAuthRepository
    {
        private readonly fbscontext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(fbscontext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        //login
        public async Task<serviceResponce<string>> Login(string username, string password)
        {
            var responce = new serviceResponce<string>();
            var user = await _context.users.FirstOrDefaultAsync(u => u.User_Name.ToLower() == username.ToLower());
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

                responce.Data = CreateToken(user);
                responce.Message = "User Login success";
            }

            return responce;
        }

        public async Task<serviceResponce<int>> Register(User user, string password)
        {

            var responce = new serviceResponce<int>();

            if (await UserExists(user.User_Name))
            {
                responce.Success = false;
                responce.Message = "User Exists";
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

        public async Task<bool> UserExists(string username)
        {
            if (await _context.users.AnyAsync(u => u.User_Name.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }


        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmca = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmca.Key;
                PasswordHash = hmca.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmca = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var newHash = hmca.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return newHash.SequenceEqual(passwordHash);
            }
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
           {
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Name,user.User_Name),
               new Claim(ClaimTypes.Email,user.Email)
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
}
