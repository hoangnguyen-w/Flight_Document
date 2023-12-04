using Flight_Document.DTO;
using Flight_Document.Entity;

namespace Flight_Document.IService
{
    public interface IAccountService
    {
        Task<Account> CheckLogin (AccountDTO account);

        Task Register(CreateAccountDTO account);
        string CreateToken(Account account);
        RefreshTokenDTO GenerateRefreshToken();
        Account SetRefreshToken(RefreshTokenDTO newRefreshToken, HttpResponse response);
    }
}
