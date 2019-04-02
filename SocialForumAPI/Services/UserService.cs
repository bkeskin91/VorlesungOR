using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialForumAPI.Helper;
using SocialForumData;
using SocialForumData.Models;

namespace SocialForumAPI.Services
{
    public class UserService : IUserService
    {
        private readonly SocialForumContext _context;
        private readonly AppSettings _appsettings;
        public UserService(SocialForumContext context, IOptions<AppSettings> appSettings)
        {
            _appsettings = appSettings.Value;
            _context = context;
        }
        public User Authenticate(string username, string password)
        {
            User user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if(user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
