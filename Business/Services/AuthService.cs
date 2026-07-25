using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Core.Concretes.Enums;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return new AuthResponseDto { IsSuccessful = true };
            }
            else if (result.IsLockedOut)
            {
                return new AuthResponseDto { IsSuccessful = false, Errors = ["Hesabınız çok fazla hatalı deneme nedeniyle askıya alınmıştır!"] };
            }
            else if (result.IsNotAllowed)
            {
                return new AuthResponseDto { IsSuccessful = false, Errors = ["Giriş yapma izniniz bulunmuyor (Örn: Eposta onayı gerekli olabilir)!"] };
            }
            else if (result.RequiresTwoFactor)
            {
                return new AuthResponseDto { IsSuccessful = false, Errors = ["İki adımlı doğrulama (2FA) işlemi gereklidir!"] };
            }
            else
            {
                return new AuthResponseDto { IsSuccessful = false, Errors = ["Geçersiz eposta veya şifre!"] };
            }
        }

        public async Task LogoutAsync() => await signInManager.SignOutAsync();

        public async Task<AuthResponseDto> RegisterAdminAsync(RegisterAdminDto model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                UserType = UserType.Admin,
                AdminProfile = new Admin
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                }
            };
            return await createUserAsync(user, model.Password);
        }

        public async Task<AuthResponseDto> RegisterCustomerAsync(RegisterCustomerDto model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                UserType = UserType.Customer,
                CustomerProfile = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                }
            };
            return await createUserAsync(user, model.Password);
        }

        public async Task<AuthResponseDto> RegisterStoreAsync(RegisterStoreDto model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                UserType = UserType.StoreOwner,
                StoreProfile = new Store
                {
                    StoreName = model.StoreName,
                    TaxOffice = model.TaxOffice,
                    TaxNumber = model.TaxNumber,
                    ContactEmail = model.ContactEmail,
                    ContactPhone = model.ContactPhone,
                }
            };
            return await createUserAsync(user, model.Password);
        }

        private async Task<AuthResponseDto> createUserAsync(AppUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return new AuthResponseDto { IsSuccessful = true };
            }
            else
            {
                return new AuthResponseDto { IsSuccessful = false, Errors = result.Errors.Select(e => e.Description) };
            }
        }
    }
}
