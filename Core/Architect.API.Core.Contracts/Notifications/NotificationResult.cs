using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Notifications
{
    [Serializable(), DataContract()]
    public partial class NotificationResult
    {
        [DataMember(), JsonProperty()] public Notification Notification { get; set; }
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.Error> Errors { get; set; }
        [DataMember(), JsonProperty()] public bool Successful => Errors == null || Errors.Count == 0;
    }

    [Serializable(), DataContract()]
    public partial class NotificationPagedResult
    {
        [DataMember(), JsonProperty()] public List<Notification> Items { get; set; }
        [DataMember(), JsonProperty()] public int TotalCount { get; set; }
        [DataMember(), JsonProperty()] public int UnreadCount { get; set; }
        [DataMember(), JsonProperty()] public int Page { get; set; }
        [DataMember(), JsonProperty()] public int PageSize { get; set; }
    }
}
