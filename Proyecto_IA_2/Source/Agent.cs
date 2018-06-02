using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA_2.Source
{
    class Agent
    {

        /*Variable estatica para poder indexar entre los agentes*/
        private static int AgentIDClass = 0;

        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> ServiceList { get; set; }
        public int EarnedCommission {get; set;}
        public int WorkTime { get; set; }

        public Agent()
        { }

        public Agent(string pID, string pName, List<string> pServiceList)
        {
            this.ID = pID;
            this.Name = pName;
            this.ServiceList = pServiceList;
            this.EarnedCommission = 0;    // Comision ganada
            this.WorkTime = 0;
        }


    }
}
