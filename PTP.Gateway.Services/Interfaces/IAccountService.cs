using PTP.Gateway.Business.Models;

namespace PTP.Gateway.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}