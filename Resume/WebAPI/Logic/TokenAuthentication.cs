using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using DatabaseAccess.Context;
using DatabaseAccess.Models;
using System.Security.Claims;

namespace WebAPI.Logic
{
    
    public class TokenAuthOptions:AuthenticationSchemeOptions
    {
        public const string DefaultSchemeName = "TokenAuthScheme";
        public string TokenHeaderName { get; set; } = "Bearer";
    }

    public class TokenAuthHandler : AuthenticationHandler<TokenAuthOptions>
    {
        public TokenAuthHandler(IOptionsMonitor<TokenAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(Options.TokenHeaderName))
            {
                return Task.FromResult(AuthenticateResult.Fail($"Missing Header For Token: {Options.TokenHeaderName}"));
            }

            var token = Request.Headers[Options.TokenHeaderName];
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                EndUser user = dbContext.EndUser.Where(eu => eu.LoginToken == token && eu.LoginTokenExpiry < DateTime.UtcNow).FirstOrDefault();
                if (user == null) return Task.FromResult(AuthenticateResult.Fail($"The provided token is not valid. It may have expired"));
                else
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Email),
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                    var id = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(id);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
            }
        }
    }

}
