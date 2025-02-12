using System;

namespace Architect.API.Tron.Contracts.Traza
{
    public partial class TrackSession
    {
        public string DocumentId { get; set; }
        public string MessageId { get; set; }
        public int ResponseStatus { get; set; }
        public string ResponseText { get; set; }
    }
}

