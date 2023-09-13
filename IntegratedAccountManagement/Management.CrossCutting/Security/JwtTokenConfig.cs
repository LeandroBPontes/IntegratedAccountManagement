using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IntegratedAccountManagement.CrossCutting.Security;

 public class JwtTokenConfig
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecretKey { get; set; }

        public int ExpiresIn { get; set; }

        public SymmetricSecurityKey SigningKey =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256);

        public TokenValidationParameters TokenValidationParameters => new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = Issuer,

            ValidateAudience = true,
            ValidAudience = Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SigningKey,

            RequireExpirationTime = true,
            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero
        };

        public string GenerateJwtToken(ClaimsPrincipal principal, int expiresInSeconds)
        {

            var claims = new List<Claim>();
            claims.AddRange(principal.Claims);

            var jwt = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(expiresInSeconds),
                signingCredentials: SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var jwt = new JwtSecurityToken(token);
            if (jwt.ValidTo < DateTime.UtcNow)
                return null;
            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(token, TokenValidationParameters, out var validToken);
            return principal;
        }

        public DateTime GetExpriration(string token)
        {
            var jwt = new JwtSecurityToken(token);
            return jwt.ValidTo;
        }
    }