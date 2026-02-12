using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;

namespace Architect.API.Core.Security
{
    /// <summary>
    /// Provides session management functionality for authenticated users.
    /// Handles session creation, retrieval, refresh, and tracking of user activities.
    /// </summary>
    public static class Session
    {
        /// <summary>
        /// Creates a new session activity for an authenticated user.
        /// </summary>
        /// <param name="activity">The activity information to create the session.</param>
        public static void Create(Contracts.Security.Activity activity)
        {
            List<Contracts.Security.Activity> sessions = (List<Contracts.Security.Activity>)Architect.Utilities.Cache.GetItem("SessionActivity");
            if (sessions.IsEmpty())
                sessions = new List<Contracts.Security.Activity>();
            activity.InitDateTime = DateTime.Now;
            activity.LastDateTime = DateTime.Now;
            activity.Id = sessions.Count + 1;
            sessions.Add(activity);
            Architect.Utilities.Cache.SetItem("SessionActivity", sessions, -1);
        }

        /// <summary>
        /// Creates a session from an authentication response and token information.
        /// Extension method for AuthenticationResponse.
        /// </summary>
        /// <param name="response">The authentication response containing user information.</param>
        /// <param name="token">The security token with user details.</param>
        /// <param name="ipAddress">The IP address of the authentication request.</param>
        /// <param name="userAgent">The user agent string from the authentication request.</param>
        public static void CreateSession(this Contracts.Security.AuthenticationResponse response, Contracts.Security.Token token, string ipAddress, string userAgent)
        {
            Create(new Contracts.Security.Activity
            {
                Token = response.Token,
                CompanyId = token.CompanyId,
                CompanyName = response.Tenant,
                UserId = token.UserId,
                UserName = token.UserName,
                EMail = response.EMail,
                IP = ipAddress,
                UserAgent = userAgent
            });
        }

        /// <summary>
        /// Retrieves a session activity by token.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>The activity associated with the token, or null if not found.</returns>
        public static Contracts.Security.Activity Get(string token)
        {
            List<Contracts.Security.Activity> sessions = (List<Contracts.Security.Activity>)Architect.Utilities.Cache.GetItem("SessionActivity");
            if (sessions.IsEmpty())
                sessions = new List<Contracts.Security.Activity>();
            int timeout = "Session.Timeout".IntegerValue(30);
            foreach (Contracts.Security.Activity item in sessions)
            {
                if (!item.Expired && DateTime.Now > item.LastDateTime.AddMinutes(timeout))
                {
                    item.Expired = true;
                }
            }

            return (from s in sessions where s.Token.Equals(token) select s).FirstOrDefault();
        }

        /// <summary>
        /// Refreshes a session activity by updating its last activity time and tracking navigation.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="track">The tracking information (e.g., current page or action).</param>
        public static void Refresh(string token, string track)
        {
            Contracts.Security.Activity result = Get(token);
            if (result.IsNotEmpty())
            {
                result.LastDateTime = DateTime.Now;
                if (result.ActivityTracks.IsEmpty())
                {
                    result.ActivityTracks = new List<Contracts.Security.ActivityTrack>() { new Contracts.Security.ActivityTrack() { LastDateTime = DateTime.Now, Summary = track } };
                    result.Navigation = track;
                }
                if (result.ActivityTracks.Last().Summary != track)
                {
                    result.Navigation = track;
                    result.ActivityTracks.Add(new Contracts.Security.ActivityTrack() { LastDateTime = DateTime.Now, Summary = track });
                }
            }
        }

        /// <summary>
        /// Tracks an error that occurred during the session.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="code">The error code.</param>
        /// <param name="currentException">The exception that occurred.</param>
        public static void TrackError(string token, string code, Exception currentException)
        {
            Contracts.Security.Activity result = Get(token);
            if (result.IsNotEmpty())
            {
                result.ErrorTime = DateTime.Now;
                result.ErrorCode = code;
                result.ErrorDetail = currentException?.Message;
            }
        }

        /// <summary>
        /// Retrieves all sessions, optionally filtered.
        /// </summary>
        /// <param name="filter">
        /// The filter to apply:
        /// - "active": Returns only active (non-expired) sessions
        /// - "error": Returns sessions with errors, sorted by error time
        /// - "company{id}": Returns sessions for a specific company (e.g., "company123")
        /// - Empty or null: Returns all sessions
        /// </param>
        /// <returns>A list of session activities matching the filter criteria.</returns>
        public static List<Contracts.Security.Activity> Sessions(string filter)
        {
            List<Contracts.Security.Activity> sessions = (List<Contracts.Security.Activity>)Architect.Utilities.Cache.GetItem("SessionActivity");
            if (sessions.IsEmpty())
                sessions = new List<Contracts.Security.Activity>();

            if (filter.IsNotEmpty() && filter.Equals("active", StringComparison.CurrentCultureIgnoreCase))
            {
                sessions = (from s in Sessions(string.Empty) where !s.Expired select s).ToList();
            }
            if (filter.IsNotEmpty() && filter.Equals("error", StringComparison.CurrentCultureIgnoreCase))
            {
                sessions = (from s in Sessions(string.Empty) where s.ErrorCode.IsNotEmpty() orderby s.ErrorTime descending select s).ToList();
            }
            if (filter.IsNotEmpty() && filter.StartsWith("company", StringComparison.CurrentCultureIgnoreCase))
            {
                int companyid = Convert.ToInt32(filter.Substring(7));
                sessions = (from s in Sessions(string.Empty) where s.CompanyId == companyid select s).ToList();
            }

            return sessions;
        }

        /// <summary>
        /// Retrieves a session activity by its ID.
        /// </summary>
        /// <param name="id">The session ID.</param>
        /// <returns>The activity with the specified ID, or null if not found.</returns>
        public static Contracts.Security.Activity SessionById(int id)
        {
            return (from s in Sessions(string.Empty) where s.Id.Equals(id) select s).FirstOrDefault();
        }
    }
}
