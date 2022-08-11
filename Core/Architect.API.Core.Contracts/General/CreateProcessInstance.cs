namespace Architect.API.Core.Contracts.General
{
    public class CreateProcessInstance
    {
        public int FlowId { get; set; }
        public int EntityType { get; set; }
        public long EntityId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }

        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }

        public string Reference4 { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int SLA { get; set; }
    }
}