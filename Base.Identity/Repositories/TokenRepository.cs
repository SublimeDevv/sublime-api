using Base.Application.Contracts.Repositories.Auth;
using Base.Identity.Models;
using Base.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Base.Identity.Repositories
{
    public class TokenRepository(IdentityDbContext context, IOptions<JwtSettings> jwtOptions) : ITokenRepository
    {
        private readonly IdentityDbContext _context = context;
        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        public (string Token, DateTime ExpiresAt) GenerateAccessToken(string userId, string email, IList<string> roles)
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userId),
                new(ClaimTypes.Email, email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }

        public async Task<(string Token, DateTime ExpiresAt)> CreateRefreshTokenAsync(string userId)
        {
            var tokenValue = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var expiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays);

            _context.RefreshToken.Add(new RefreshToken
            {
                RefreshTokenValue = tokenValue,
                Active = true,
                Used = false,
                Expiration = expiresAt,
                UserId = userId
            });

            await _context.SaveChangesAsync();
            return (tokenValue, expiresAt);
        }

        public async Task<string?> ValidateAndConsumeRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshToken
                .FirstOrDefaultAsync(r => r.RefreshTokenValue == refreshToken && r.Active && !r.Used);

            if (token is null) return null;

            if (token.Expiration < DateTime.UtcNow)
            {
                token.Active = false;
                await _context.SaveChangesAsync();
                return null;
            }

            token.Used = true;
            await _context.SaveChangesAsync();
            return token.UserId;
        }

        public async Task RevokeRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshToken
                .FirstOrDefaultAsync(r => r.RefreshTokenValue == refreshToken);

            if (token is not null)
            {
                token.Active = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
