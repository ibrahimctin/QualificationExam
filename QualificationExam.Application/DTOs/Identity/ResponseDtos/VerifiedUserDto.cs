namespace QualificationExam.Application.DTOs.Identity.ResponseDtos
{
    public class VerifiedUserDto
    {
        public string? Username { get; set; }
        public string[]? Roles { get; set; }
        public string? Email { get; set; }

       
        public string? RefreshToken { get; set; }

  
        public DateTime RefreshTokenExpiration { get; set; }

     
        public string? Token { get; set; }

        [JsonIgnore]
        public DateTime AccessTokenExpiration { get; set; }

        public VerifiedUserDto() { }

        public VerifiedUserDto(AppUser user, string[] roles, string jwtToken, string email, RefreshToken refreshToken, DateTime accessTokenExireDate)
        {
            Username = user.UserName;
            Roles = roles;
            Token = jwtToken;
            Email = email;
            RefreshToken = refreshToken.Token;
            RefreshTokenExpiration = refreshToken.Expires;
            AccessTokenExpiration = accessTokenExireDate;
        }
    }
}
