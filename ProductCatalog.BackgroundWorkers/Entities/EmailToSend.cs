using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.Entities
{
    public class EmailToSend
    {
        public string To { get; set; }
        public string From { get; } = "berk.demircioglu1994@gmail.com";
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
