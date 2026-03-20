namespace Base.Application.DTOs.Auth
{
    public class LoginResponseDto
    {
        public AuthTokensDto Tokens { get; set; } = new();
        public UserDetailDto User { get; set; } = new();
    }
}
