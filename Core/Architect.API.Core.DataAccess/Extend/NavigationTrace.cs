using Architect.DataFactory;
using System;
using System.Web;

namespace Architect.API.Core.DataAccess.Extend
{
    /// <summary>
    /// Provides data access functionality for tracking user navigation actions in the system.
    /// </summary>
    /// <remarks>
    /// This partial class extends the NavigationTrace entity to provide specialized data access methods
    /// for recording user activity. It relies on session state for user identification and trace correlation.
    /// </remarks>
    public partial class NavigationTrace
    {
        #region CRUD Methods

        /// <summary>
        /// Records a user navigation action to the database.
        /// </summary>
        /// <param name="action">The navigation action to track. Maximum length is 512 characters.</param>
        /// <remarks>
        /// <para>
        /// This method inserts a new navigation trace record with the current date/time and user information
        /// retrieved from the HTTP session. The trace record includes:
        /// </para>
        /// <list type="bullet">
        /// <item><description>TraceId from <c>HttpContext.Current.Session["TraceId"]</c></description></item>
        /// <item><description>EffectDate set to <see cref="DateTime.Now"/></description></item>
        /// <item><description>UserId from <c>HttpContext.Current.Session["UserId"]</c></description></item>
        /// <item><description>The provided action description</description></item>
        /// </list>
        /// <para>
        /// The operation is executed against the "Architect.Core" database connection.
        /// </para>
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// Thrown when <see cref="HttpContext.Current"/> or its Session is null.
        /// </exception>
        /// <example>
        /// <code>
        /// NavigationTrace.Track("User viewed dashboard");
        /// NavigationTrace.Track("User clicked export button");
        /// </code>
        /// </example>
        public static void Track(string action)
        {
            Database.Select("INSERT INTO NavigationTrace (TraceId, EffectDate, UserId, Action)" + " VALUES ( :TraceId, :EffectDate, :UserId, :Action)")
                      .AddParameter("TraceId", Architect.DataFactory.Enumerations.DbType.Decimal, 9, HttpContext.Current.Session["TraceId"])
                      .AddParameter("EffectDate", Architect.DataFactory.Enumerations.DbType.Date, 9, DateTime.Now)
                      .AddParameter("UserId", Architect.DataFactory.Enumerations.DbType.Decimal, 9, HttpContext.Current.Session["UserId"])
                      .AddParameter("Action", Architect.DataFactory.Enumerations.DbType.String, 512, action)
                            .Execute("Architect.Core");
        }

        #endregion CRUD Methods
    }
}