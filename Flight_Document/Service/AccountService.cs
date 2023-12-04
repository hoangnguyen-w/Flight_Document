using Flight_Document.DTO;
using Flight_Document.Entity;
using Flight_Document.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Flight_Document.Service
#nullable disable
{
    public class AccountService : IAccountService
    {
        private Account _account;
        private readonly FlightManagerContext _context;
        private readonly IConfiguration _configuration;

        public AccountService(FlightManagerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Account> CheckLogin(AccountDTO account)
        {
            var check = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == account.Email);
            if (check != null)
            {
                if (account.Password != check.Password)
                {
                    throw new BadHttpRequestException("Wrong password!");
                }
            }
            else
            {
                throw new BadHttpRequestException("Định dạng không đúng hoặc yêu cầu bị thiếu");
            }
            return check;
        }

        public string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Name, account.AccountName),
                new Claim(ClaimTypes.PostalCode, account.AccountID + ""),
                new Claim(ClaimTypes.Role, account.Role.RoleName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenSecret").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshTokenDTO GenerateRefreshToken()
        {
            var refreshToken = new RefreshTokenDTO
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddHours(1), // 1 tiếng reset token 1 lần
                Created = DateTime.Now
            };
            return refreshToken;
        }

        public async Task Register(CreateAccountDTO account)
        {
            if (IsValidEmail(account.Email))
            {

                _account = new Account();
                string email = account.Email;

                _account.Email = email;
                _account.Password = account.Password;
                _account.AccountName = account.AccountName;
                _account.RoleID = account.RoleID;

                _context.Accounts.Add(_account);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new BadHttpRequestException("Not valid email!");
            }
        }

        public Account SetRefreshToken(RefreshTokenDTO newRefreshToken, HttpResponse response)
        {
            _account = new Account();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            _account.RefreshToken = newRefreshToken.Token;
            _account.TokenCreated = newRefreshToken.Created;
            _account.TokenExpires = newRefreshToken.Expires;

            return _account;
        }


        private bool IsValidEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@vietjetair\.com$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }
    }
}
