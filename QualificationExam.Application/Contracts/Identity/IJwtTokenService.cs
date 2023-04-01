namespace QualificationExam.Application.Contracts.Identity
{
    public interface IJwtTokenService
    {
        string GenerateJsonWebToken(AppUser user, IList<string> roles);
    }
}