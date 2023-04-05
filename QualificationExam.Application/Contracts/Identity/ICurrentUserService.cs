namespace QualificationExam.Application.Contracts.Identity
{
    public interface ICurrentUserService
    {
        string UserId { get; set; }
        Task<AppUser> GetCurrentUser();
        Task<string> GetCurrentUserIdAsync();
    }
}
