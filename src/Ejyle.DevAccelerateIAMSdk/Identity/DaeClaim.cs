// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.IAM.Identity
{
    /// <summary>
    /// Represents a claim.
    /// </summary>
    public class DaeClaim
    {
        /// <summary>
        /// Gets the type of a claim.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the value of a claim.
        /// </summary>
        public string Value { get; set; }
    }
}
