using Microsoft.AspNetCore.Http;

namespace QualificationExam.Identity.Services
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId { get; set; } = default!;


        

        public async Task<AppUser> GetCurrentUser()
        {

            // Take user from context "Curren User"
            var user = _httpContextAccessor.HttpContext.User;

            // Validate

            if (!user.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }
            // we get current user e-mail from user claims
            var emailClaim = user.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email));
            // e-mail validate
            if (emailClaim is null)
            {
                throw new UnauthorizedAccessException();
            }
            // this is current e-mail value for passing userManager.
            var email = emailClaim.Value;

            // Do not use a constructor injection for UserManager because of circular dependency
            var userManager = _httpContextAccessor.HttpContext.RequestServices
                .GetService<UserManager<AppUser>>();

            // geting user by e-mail then return in it 

            return await userManager.FindByEmailAsync(email);

        }

        public async Task<string> GetCurrentUserIdAsync()
        {
            // Get current user methot
            var currentUser = await GetCurrentUser();

            // and take return current user Id
            return currentUser is null ? default : currentUser.Id;
        }
    }
}
