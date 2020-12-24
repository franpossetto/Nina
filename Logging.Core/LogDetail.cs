using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Core
{
    public class LogDetail
    {
        public LogDetail()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public string Message { get; set; }

        // Where
        public string Product { get; set; }
        public string Layer { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }

        //Who
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CustomerId { get; set; }
        public string CostumerName { get; set; }

        //Everything else
        public long? ElampsedMilliseconds { get; set; }
        public Exception Exception { get; set; }
        public string CorrelationId { get; set; }
        public Dictionary<string, object> AdditionalInfo { get; set; }





    }
}
