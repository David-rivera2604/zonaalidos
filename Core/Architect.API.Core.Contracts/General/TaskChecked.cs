using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Contracts.General
{
    public class TaskChecked
    {
        public int StepId { get; set; }
        public int ActivityId { get; set; }
        public string Comment { get; set; }
        public bool Notify { get; set; }
        public List<Attachment> Attachments { get; set; }

        public List<Utilities.Contracts.LookUpValue> References { get; set; }
    }

    public class Attachment
    {
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
    }
}
