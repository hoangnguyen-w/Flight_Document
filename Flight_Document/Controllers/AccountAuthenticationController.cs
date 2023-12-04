using Flight_Document.DTO;
using Flight_Document.Entity;
using Flight_Document.IService;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountAuthenticationController : Controller
    {
        private static Account account = new Account();
        private readonly IAccountService _accountService;
        private readonly FlightManagerContext _context;

        public AccountAuthenticationController(IAccountService accountService, FlightManagerContext context)
        {
            _accountService = accountService;
            _context = context;
        }



        [HttpPost("login")]
        public async Task<ActionResult<Account>> Login(AccountDTO request)
        {
            try
            {
                var acc = await _accountService.CheckLogin(request);
                string token = _accountService.CreateToken(acc);

                var refreshToken = _accountService.GenerateRefreshToken();
                var setToken = _accountService.SetRefreshToken(refreshToken, Response);

                account = acc;
                account.RefreshToken = setToken.RefreshToken;
                account.TokenExpires = setToken.TokenExpires;

                TokenDTO dto = new TokenDTO();

                dto.Token = token;
                dto.AccountID = acc.AccountID;
                dto.Email= acc.Email; 
                dto.AccountName = acc.AccountName;
                dto.Role = acc.Role.RoleName;

                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
