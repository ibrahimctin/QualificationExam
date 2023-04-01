namespace QualificationExam.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<bool> ChangeEmailAsync(string email, string password);
        Task<bool> ChangePasswordAsync(string currentPassword, string newPassword);
        Task<bool> ChangeUsernameAsync(string username, string password);
        Task<IdentityResult> CreateUserAsync(RegisterDto registerUser);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<VerifiedUserDto> LoginUserAsync(LoginDto userDto, string IpAddress);
    }
}