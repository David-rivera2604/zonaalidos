using System;
using System.Linq;

namespace Architect.DocuSign.Integrations.Providers.Evicertia.Contracts
{
    public class EviSignQueryResult
    {
        public Result[] results { get; set; }
        public int totalMatches { get; set; }
    }

    public class Result
    {
        public string evidenceId { get; set; }
        public string lookupKey { get; set; }
        public string subject { get; set; }
        public string state { get; set; }
        public string outcome { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastStateChangeDate { get; set; }
        public DateTime submittedOn { get; set; }
        public DateTime processedOn { get; set; }
        public DateTime sentOn { get; set; }
        public DateTime closedOn { get; set; }
        public DateTime expiredOn { get; set; }
        public Signingparty[] signingParties { get; set; }
        public object[] interestedParties { get; set; }
        public affidavits[] affidavits { get; set; }
        public object[] attachments { get; set; }
        public string issuer { get; set; }
        public int timeToLive { get; set; }
        public int onlineRetentionPeriod { get; set; }
        public int notaryRetentionPeriod { get; set; }
    }

    public class Signingparty
    {
        public string partyId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string signingMethod { get; set; }
        public string signatureComments { get; set; }
        public string role { get; set; }
    }
    public class affidavits
    {
        public string uniqueId { get; set; }
        public string dates { get; set; }
        public string evidenceUniqueId { get; set; }
        public string partyUniqueId { get; set; }
        public string bytes { get; set; }
        public string description { get; set; }
        public string kind { get; set; } 
    }
}
