// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.IdM.Identity
{
    public class DaClaimsUser : DaUserBase
    {
        /// <summary>
        /// Gets the name of a user.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets the user's tenant ID.
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// Gets a list of roles assigned to a user.
        /// </summary>
        public string[] Roles { get; set; }
    }
}
