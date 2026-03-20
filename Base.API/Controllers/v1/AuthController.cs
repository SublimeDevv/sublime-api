using Asp.Versioning;
using Base.Application.DTOs.Auth;
using Base.Application.UseCases.Auth.Commands.ForgotPassword;
using Base.Application.UseCases.Auth.Commands.Login;
using Base.Application.UseCases.Auth.Commands.Logout;
using Base.Application.UseCases.Auth.Commands.RefreshToken;
using Base.Application.UseCases.Auth.Commands.Register;
using Base.Application.UseCases.Auth.Commands.ResetPassword;
using Base.Application.UseCases.Auth.Queries.GetCurrentUser;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Base.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            SetTokensInCookies(result.Tokens);
            return Ok(result.User);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            SetTokensInCookies(result.Tokens);
            return Ok(result.User);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            if (!HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
                return BadRequest("No se encontró el token de refresco.");

            var tokens = await _mediator.Send(new RefreshTokenCommand { RefreshToken = refreshToken });
            SetTokensInCookies(tokens);
            return NoContent();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

            await _mediator.Send(new LogoutCommand { RefreshToken = refreshToken });

            RemoveTokensFromCookies();
            return NoContent();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok("Si el correo existe, recibirás un enlace para restablecer tu contraseña.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDetailDto>> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("No se pudo obtener el identificador del usuario.");

            var user = await _mediator.Send(new GetCurrentUserQuery { UserId = userId });
            return Ok(user);
        }

        private void SetTokensInCookies(AuthTokensDto tokens)
        {
            Response.Cookies.Append("accessToken", tokens.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = tokens.AccessTokenExpiresAt
            });

            Response.Cookies.Append("refreshToken", tokens.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = tokens.RefreshTokenExpiresAt
            });
        }

        private void RemoveTokensFromCookies()
        {
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");
        }
    }
}
