namespace QualificationExam.Identity.Services
{
    public class CurrentUserService:ICurrentUserService
    {
        public string UserId { get; set; } = default!;
    }
}
