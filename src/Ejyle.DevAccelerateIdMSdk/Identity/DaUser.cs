// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.IdM.Identity
{
    /// <summary>
    /// Represents an API user in DevAccelerate IdM.
    /// </summary>
    public class DaUser : DaUserBase
    {
        /// <summary>
        /// Gets the current status of a user.
        /// </summary>
        public DaAccountStatus Status { get; set; }
    }
}
