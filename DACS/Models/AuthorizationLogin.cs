using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DACS.Models
{
    public class AuthorizationLogin : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserMasterRepository _repo = new UserMasterRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Sai tên tài khoản hoặc mật khẩu!");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.USERNAME));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.IDUSER.ToString()));
                identity.AddClaim(new Claim("Email", user.EMAIL));
                identity.AddClaim(new Claim("UserName", user.USERNAME));
                context.Validated(identity);
            }
        }
    }
}