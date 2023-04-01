namespace QualificationExam.Application.Contracts.Identity
{
    public interface IRefreshTokenService
    {
        RefreshToken CreateRefreshToken(string ipAddress);
        Task<VerifiedUserDto> RefreshToken(string token, string ipAddress);
        void RemoveOldRefreshTokens(AppUser user);
        Task RevokeToken(string token, string ipAddress);
    }
}