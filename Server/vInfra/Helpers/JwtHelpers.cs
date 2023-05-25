using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace vApplication.Helpers
{
    public class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaimsFromRequest(HttpRequest request)
        {
            var headers = request.Headers;
            var authorizationHeader = headers["Authorization"];
            var stringToken = authorizationHeader[0].Replace("Bearer ", "");
            JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(stringToken);
            return token.Claims;
        }

        public static Claim GetClaimFromRequest(HttpRequest request, string type)
        {
            IEnumerable<Claim> claims = GetClaimsFromRequest(request);
            return claims.First(x => x.Type == type);
        }
    }
}
