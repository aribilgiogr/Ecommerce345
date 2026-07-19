using Core.Concretes.DTOs;

namespace Core.Abstracts.IServices
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto model);
        Task<AuthResponseDto> RegisterCustomerAsync(RegisterCustomerDto model);
        Task<AuthResponseDto> RegisterAdminAsync(RegisterAdminDto model);
        Task<AuthResponseDto> RegisterStoreAsync(RegisterStoreDto model);
        Task LogoutAsync();
    }
}
