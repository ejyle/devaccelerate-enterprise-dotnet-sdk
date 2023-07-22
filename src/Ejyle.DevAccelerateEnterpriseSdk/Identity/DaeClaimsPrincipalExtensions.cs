// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Ejyle.DevAccelerate.Enterprise.Identity
{
    /// <summary>
    /// Contains a set of DevAccelerate Enterprise-specific extensions methods of <see cref="ClaimsPrincipal"/>.
    /// </summary>
    public static class DaeClaimsPrincipalExtensions
    {
        /// <summary>
        /// Creates an instance <see cref="DaeClaimsUser"/> based on a set of available claims.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns>Returns an instance of the <see cref="DaeClaimsUser"/> class.</returns>
        public static DaeClaimsUser GetDaeUser(this ClaimsPrincipal claimsPrincipal)
        {
            var claims = claimsPrincipal.Claims;

            if (claims == null || claims.Count() < 1)
            {
                return null;
            }

            var user = new DaeClaimsUser();

            var roles = new List<string>();

            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case "sub":
                        user.Id = claim.Value;
                        break;
                    case "preferred_username":
                        user.UserName = claim.Value;
                        break;
                    case "name":
                        user.Name = claim.Value;
                        break;
                    case "email":
                        user.Email = claim.Value;
                        break;
                    case "role":
                        roles.Add(claim.Value);
                        break;
                    case "tenant":
                        user.Tenant = claim.Value;
                        break;
                }
            }

            user.Roles = roles.ToArray();
            return user;
        }
    }
}
