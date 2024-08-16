using studyProject.Data;
using task_manager.Models;
using task_manager.Repositories;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace task_manager.Services
{
    public class AuthService : IAuth
    {
        private readonly dataBaseContext _dataBaseContext;

        public AuthService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public string Login(AuthModel auth)
        {
            try
            {
                AuthModel user = _dataBaseContext.tUser.Where(item => item.vchUserName == auth.vchUserName).Select(item=>new AuthModel() { vchUserName = item.vchUserName, vchPassword = item.vchPassword}).FirstOrDefault();
                if (user == null)
                {
                    throw new ArgumentException("Usuário não existe");
                }
                using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(auth.vchPassword));
                    var hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();

                    if (hashString == user.vchPassword)
                    {
                        string token = GenerateJwtToken(user);
                        return token;
                    }
                    else
                    {
                        throw new ArgumentException("Usuário ou senha inválido.");
                    }
                }

            } catch
            {
                throw;
            }
        }
        public string GenerateJwtToken(AuthModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("4D5927CC80D4DCC3357659BF501E85C1EDB5A56537D8452528C61DB58809B24554248C6246F12CCE0246FA70F3DC7E4F7D0279157780DD6A59BBE2655251ED36");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.vchUserName.ToString()),
                new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}