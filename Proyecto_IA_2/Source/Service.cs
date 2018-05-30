using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA_2.Source
{
    class Service
    {
        public string Code { get; set; }
        public string ServiceName { get; set; }
        public int Time { get; set; }
        public int Commission { get; set; }

        public Service(string pCode, string pServiceName, int pTime, int pCommission)
        {
            this.Code = pCode;
            this.ServiceName = pServiceName;
            this.Time = pTime;
            this.Commission = pCommission;
        }
    }
}
