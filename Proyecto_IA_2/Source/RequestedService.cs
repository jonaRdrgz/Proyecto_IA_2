using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA_2.Source
{
    class RequestedService
    {
        public string ID { get; set; }
        public string CustomerName { get; set; }
        public string ServiceCode { get; set; }

        public RequestedService(string pID, string pCustomerName, string pServiceCode)
        {
            this.ID = pID;
            this.CustomerName = pCustomerName;
            this.ServiceCode = pServiceCode;
        }
    }
}
