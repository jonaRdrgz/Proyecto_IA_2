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
        public int JobCounter { get; set; }
        public bool IsBusy { get; set; }

        public Agent()
        { }

        public Agent(Agent pCopy)
        {
            this.ID = pCopy.ID;
            this.Name = pCopy.Name;
            this.ServiceList = pCopy.ServiceList;
            this.EarnedCommission = 0;// Comision ganada
            this.WorkTime = 0;
            this.JobCounter = 0;
            this.IsBusy = false;
        }


        public Agent(string pID, string pName, List<string> pServiceList)
        {
            this.ID = pID;
            this.Name = pName;
            this.ServiceList = pServiceList;
            this.EarnedCommission = 0;    // Comision ganada
            this.WorkTime = 0;
            this.JobCounter = 0;
            this.IsBusy = false;
        }

        public override string ToString()
        {
            return ID + " :{\tName:" + Name + ", \tEarnedCommission:" + EarnedCommission + ",\tWorkTime: " + WorkTime + ",\tJobCounter: " + JobCounter + "}\n" ;
        }


    }
}
