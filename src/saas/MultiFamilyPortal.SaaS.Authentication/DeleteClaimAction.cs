﻿using System.Security.Claims;
using System.Text.Json;

namespace MultiFamilyPortal.SaaS.Authentication
{
    /// <summary>
    /// A ClaimAction that deletes all claims from the given ClaimsIdentity with the given ClaimType.
    /// </summary>
    public class DeleteClaimAction : ClaimAction
    {
        /// <summary>
        /// Creates a new DeleteClaimAction.
        /// </summary>
        /// <param name="claimType">The ClaimType of Claims to delete.</param>
        public DeleteClaimAction(string claimType)
            : base(claimType, ClaimValueTypes.String)
        {
        }

        /// <inheritdoc />
        public override void Run(JsonElement userData, ClaimsIdentity identity, string issuer)
        {
            foreach (var claim in identity.FindAll(ClaimType).ToList())
            {
                identity.TryRemoveClaim(claim);
            }
        }
    }
}
