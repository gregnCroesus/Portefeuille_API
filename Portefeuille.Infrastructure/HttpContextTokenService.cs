using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Portefeuille.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Infrastructure
{
    /// <summary>
    /// service to manage the current authentication tokens.
    /// </summary>
    public class HttpContextTokenService : IHttpContextTokenService
    {
        private const string AccessTokenName = "access_token";
        private readonly IHttpContextAccessor accessor;

        /// <summary>
        /// default constructor.
        /// </summary>
        public HttpContextTokenService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        /// <inheritdoc/>
        public Task<string> GetAccessTokenAsync()
        {
            return this.accessor.HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, AccessTokenName);
        }
    }
}
