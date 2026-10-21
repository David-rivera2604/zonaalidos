namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Defines the lifecycle states allowed for an insured-completion invitation.
    /// </summary>
    public enum InvitationStatus
    {
        /// <summary>The invitation may be exchanged for a restricted completion session.</summary>
        Active = 1,
        /// <summary>The insured submitted the associated completion form.</summary>
        Completed = 2,
        /// <summary>The invitation was superseded or explicitly invalidated.</summary>
        Revoked = 3,
        /// <summary>The invitation exceeded its permitted lifetime.</summary>
        Expired = 4
    }
}
