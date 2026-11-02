using Paybill.Models;

namespace Paybill.Auth
{
    public interface IJwtTokenHandler
    {
        Task<ResponseMessage> GenerateToken(TokenParameter param, bool isTemporary = false);
    }
}
