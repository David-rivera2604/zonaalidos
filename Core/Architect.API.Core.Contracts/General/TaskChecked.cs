using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General
{
    public class TaskChecked
    {
        public int ActivityId { get; set; }
        public string Comment { get; set; }
        public bool Notify { get; set; }
        public List<Attachment> Attachments { get; set; }
    }

    public class Attachment
    {
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
    }
}
