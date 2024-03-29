﻿using QualificationExam.Domain.Constants.ResponseMessages;

namespace QualificationExam.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtTokenService _jwtAuthentication;
        private readonly JwtOptions _jwtOptions;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ICurrentUserService _currentUser;
        public UserService(
      UserManager<AppUser> userManager,
      SignInManager<AppUser> signInManager,
      ICurrentUserService currentUser,
      IJwtTokenService jwtAuthentication,
      IOptions<JwtOptions> jwtOptions,
      IRefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtAuthentication = jwtAuthentication;
            _currentUser = currentUser;
            _jwtOptions = jwtOptions.Value;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<bool> ChangeUsernameAsync(string username, string password)
        {
            var user = await _userManager.FindByIdAsync(_currentUser?.UserId!);
            if (user is null)
                throw new HandledException(ErrorMessages.UserNotFound);

            if (string.IsNullOrEmpty(username))
                throw new HandledException("Username cannot be empty");

            if (user.UserName == username)
                return true;

            var passwordVerification = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordVerification)
                throw new HandledException("Wrong password");

            var duplicateUser = await _userManager.FindByNameAsync(username);
            if (duplicateUser is not null)
                throw new HandledException("This username is already taken");

            await _userManager.SetUserNameAsync(user, username);

            return true;
        }

        public async Task<bool> ChangePasswordAsync(string currentPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
                throw new HandledException("New and old password can't be empty");

            var user = await _userManager.FindByIdAsync(_currentUser?.UserId!);
            if (user is null)
                throw new HandledException("Couldn't find this user");

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
                throw new HandledException("Couldn't change password, the current password is incorrect");

            return true;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto registerUser)
        {
            if (registerUser is null)
                throw new HandledException("Register User model cannot be empty");

            var user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerUser.Username,
                Email = registerUser?.Email,
                AccountCreatedDate = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, registerUser?.Password!);

            if (!result.Succeeded)
                throw new HandledExceptionList(result.Errors.Select(errors => errors.Description).ToList());

            // seed data
            await _userManager.AddToRoleAsync(user, Roles.USER);

            return result;
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new HandledException("Couldn't find this user");

            var result = await _userManager.DeleteAsync(user);

            return result;
        }

        public async Task<VerifiedUserDto> LoginUserAsync(LoginDto userDto, string IpAddress)
        {
            if (userDto is null && string.IsNullOrEmpty(IpAddress))
                throw new HandledException("User model and Ip address cannot be empty");

            var user = await _userManager.Users
                .Where(u => u.UserName == userDto!.Username)
                .Include(e => e.UserRoles)
                .ThenInclude(e => e.Role)
                .Include(e => e.RefreshTokens)
                .FirstOrDefaultAsync();

            return await HandleLogin(user!, userDto!.Password!, IpAddress);
        }

        public async Task<bool> ChangeEmailAsync(string email, string password)
        {
            var user = await _userManager.FindByIdAsync(_currentUser?.UserId!);
            if (user is null)
                throw new HandledException("Couldn't find this user");

            if (string.IsNullOrEmpty(email))
                throw new HandledException("Email cannot be empty");

            if (user.Email == email)
                return true;

            var passwordVerification = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordVerification)
                throw new HandledException("Wrong password");

            var duplicateUser = await _userManager.FindByEmailAsync(email);
            if (duplicateUser is not null)
                throw new HandledException("This email is already taken");

            var result = await _userManager.ChangeEmailAsync(user, email, "");

            if (!result.Succeeded)
                throw new HandledExceptionList(result.Errors.Select(errors => errors.Description).ToList());

            return result.Succeeded;
        }

        private async Task<VerifiedUserDto> HandleLogin(AppUser user, string password, string ipAddress)
        {
            if (user is null)
                throw new HandledException("Couldn't log in, check your login or password"); // Couldn't find user

            // Validate credentials 
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                throw new HandledException("Couldn't log in, check your login or password");

            var refreshToken = _refreshTokenService.CreateRefreshToken(ipAddress);
            user.RefreshTokens ??= new();
            user.RefreshTokens?.Add(refreshToken);

            var roles = user.UserRoles.Select(e => e.Role.Name).ToList();
            var token = _jwtAuthentication.GenerateJsonWebToken(user!, roles!);

            _refreshTokenService.RemoveOldRefreshTokens(user);

            // save removal of old refresh tokens
            await _userManager.UpdateAsync(user);

            return new VerifiedUserDto()
            {
                Username = user!.UserName,
                Roles = roles?.ToArray()!,
                RefreshToken = refreshToken!.Token,
                RefreshTokenExpiration = refreshToken!.Expires,
                Token = token,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenExpireTime),
                Email = user.Email
            };
        }
    }
}
