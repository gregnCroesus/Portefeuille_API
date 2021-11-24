using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Domain
{
    /// <summary>
    /// service to manage the current authentication tokens.
    /// </summary>
    public interface IHttpContextTokenService
    {
        /// <summary>
        /// Retrieve the access_token of the current Http context
        /// </summary>
        /// <returns></returns>
        Task<string> GetAccessTokenAsync();
    }
}
