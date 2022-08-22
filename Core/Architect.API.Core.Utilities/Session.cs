using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Security
{
    public static class Session
    {
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

        public static Contracts.Security.Activity Get(string token)
        {
            List<Contracts.Security.Activity> sessions = (List<Contracts.Security.Activity>)Architect.Utilities.Cache.GetItem("SessionActivity");
            if (sessions.IsEmpty())
                sessions = new List<Contracts.Security.Activity>();
            int timeout = Architect.Utilities.Helpers.Settings.IntegerValue("Session.Timeout", 30);
            foreach (Contracts.Security.Activity item in sessions)
            {
                if (!item.Expired && DateTime.Now > item.LastDateTime.AddMinutes(timeout))
                {
                    item.Expired = true;
                }
            }

            return (from s in sessions where s.Token.Equals(token) select s).FirstOrDefault();
        }

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

        public static Contracts.Security.Activity SessionById(int id)
        {
            return (from s in Sessions(string.Empty) where s.Id.Equals(id) select s).FirstOrDefault();
        }
    }
}
