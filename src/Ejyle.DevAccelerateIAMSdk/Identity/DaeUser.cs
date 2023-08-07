// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.IAM.Identity
{
    /// <summary>
    /// Represents an API user in DevAccelerate IAM.
    /// </summary>
    public class DaeUser : DaeUserBase
    {
        /// <summary>
        /// Gets the current status of a user.
        /// </summary>
        public DaeAccountStatus Status { get; set; }
    }
}
