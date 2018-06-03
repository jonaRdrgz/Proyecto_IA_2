using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA_2.Source
{
    class Gen
    {
        public List<Agent> Gen1 { get; set; }
        public List<Agent> AgentList { get; set;}
        public double Fitness { get; set; }
        public int MutationProbability { get; set; }
        public static Random random = new Random();

        public Dictionary<string, List<Agent>> AgentesByServiceDictionary { get; set; }

        /*Constructor sin parametros*/
        public Gen() { }

        public Gen(List<Agent> pAgentList)
        {
            this.AgentList = pAgentList;
            /*valor que se dará por default, despues se calculará el fitness*/
            this.Fitness = 0;
            this.MutationProbability = 10;

            /*Valores necesarios para el Genetic Algorithm*/
            this.AgentesByServiceDictionary = new Dictionary<string, List<Agent>>();

            //Ingresa a AgentesByServiceDictionary los datos necesario para el algoritmo
            this.GroupByServiceDictionary();

            // una copia de la lista que se quiere para evitar modificaciones
            
            
        }

        public double PenaltyFitness()
        {
            //numero de agentes que se pasan de las 40 horas 
            double tmp = (from agent in Gen1
                       where agent.WorkTime > 40
                       select agent).ToList().Count;
            double tmpJob = (from agent in AgentList
                             where !agent.IsBusy
                             select agent).ToList().Count;

            // si se pasa se penaliza con 100 por cada agente que no cumpla la condicion de worktime <= 40
            tmp = tmp > 40 ? 100 * tmp : 0;
            //penaliza si alguien no esta trabajando
            tmp += (tmpJob > 0 ? 200 * tmpJob : 0);

            return tmp;
        }


        public void CalculateFitness()
        {
            double n = Gen1.Count;
            double average = 0;
            foreach(Agent agent in Gen1.AsEnumerable())
            {
                average += agent.EarnedCommission;
            }

            average /= n; // promedio

            double variance = 0;
            foreach (Agent agent in Gen1.AsEnumerable())
            {
                double tmp = agent.EarnedCommission - average;
                variance += Math.Pow(tmp, 2); // (value, power)
            }

            variance /= n;

            double standardDeviation = Math.Sqrt(variance); // si la desviacion estandar es cercana a cero los pagos son casi homogeneos.
            this.Fitness = standardDeviation + PenaltyFitness(); //Para poder saber si esta bien. // tener en cuenta el work time de cada agente.

            
        }

        //agrupar por servicios que atienden
        public void GroupByServiceDictionary()
        {
            XMLData xmlData = XMLData.GetInstance();

            List<Service> service = xmlData.XMLServices;
            foreach (Service s in service.AsEnumerable())
            {
                AgentesByServiceDictionary.Add(s.Code, GroupByService(s.Code));
            }

        }

        //Busca los agentes que hace un servicio agrupado
        public List<Agent> GroupByService(string pServiceCode)
        {
            return (from agent in this.AgentList
                    where agent.ServiceList.Contains(pServiceCode)
                    select agent
                    ).ToList();
        }

        //Busca hacer un nuevo gen desde uno ya cruzado para poder
        //hacer copias de los objeto y no afectar los demas
        public void CreateChildGen(List<Agent> pCrossedGen, List<RequestedService> pRequestedServiceList)
        {
            List<Agent> gen = new List<Agent>();

            //tuplas de agentes en blanco con los servicos.
            foreach (var item in pCrossedGen.Zip(pRequestedServiceList, (A, RS) => new { agentAux = A, requestedService = RS }))
            {
                //busca el agente en blanco que tenga las mismas caracteristicas.
                Agent agent = (from ag in this.AgentList
                               where ag.ID.Equals(item.agentAux.ID) select ag).FirstOrDefault();

                gen.Add(agent);
                agent.IsBusy = true;

                Service service = GetServiceValues(item.requestedService.ServiceCode);
                agent.WorkTime += service.Time;
                agent.EarnedCommission += service.Commission;
                agent.JobCounter += 1;

            }

            Gen1 = gen;   

        }

        //mutacion por si algún agente queda sin trabajito :(
        public void ManipulatedMutation(List<RequestedService> pRequestedServiceList)
        {

            List<Agent> agentIsNotBusy = (from agent in AgentList
                                          where agent.JobCounter < 1
                                          select agent).ToList();

            foreach(Agent agent in agentIsNotBusy.AsEnumerable())
            {
                Agent agentToReplace = (from ag in Gen1
                                               where ag.ServiceList.Intersect(agent.ServiceList).Any() && ag.JobCounter > 1
                                               select ag).OrderByDescending(x => x.JobCounter).FirstOrDefault();

                for (int i = 0; i < pRequestedServiceList.Count; i++)
                {
                    if(Gen1.ElementAt(i).ID == agentToReplace.ID && agent.ServiceList.Contains(pRequestedServiceList.ElementAt(i).ServiceCode))
                    {
                        Service service = GetServiceValues(pRequestedServiceList.ElementAt(i).ServiceCode);

                        agentToReplace.JobCounter -= 1;
                        agentToReplace.WorkTime -= service.Time;
                        agentToReplace.EarnedCommission -= service.Commission;
                        agentToReplace.IsBusy = agentToReplace.JobCounter == 0 ? false : true;

                        agent.JobCounter += 1;
                        agent.WorkTime += service.Time;
                        agent.EarnedCommission += service.Commission;
                        agent.IsBusy = true;

                        //Swap 
                        Gen1[i] = agent;

                    }
                }

                

            }
        }


        public void Mutation(List<RequestedService> pRequestedServiceList)
        {
            int lengthGen = Gen1.Count;
            for (int i = 0; i < lengthGen; i++)
            {
                if(random.Next(100) <= MutationProbability )
                {
                    Service service = GetServiceValues(pRequestedServiceList.ElementAt(i).ServiceCode);

                    Agent agentToReplace = Gen1.ElementAt(i);
                    Agent newAgent = AgentesByServiceDictionary[service.Code].ElementAt(random.Next(AgentesByServiceDictionary[service.Code].Count));

                    agentToReplace.JobCounter -= 1;
                    agentToReplace.WorkTime -= service.Time;
                    agentToReplace.EarnedCommission -= service.Commission;
                    agentToReplace.IsBusy = agentToReplace.JobCounter == 0 ? false : true;

                    newAgent.JobCounter += 1;
                    newAgent.WorkTime += service.Time;
                    newAgent.EarnedCommission += service.Commission;
                    newAgent.IsBusy = true;

                    Gen1[i] = newAgent;


                }
            }
        }

        public void CreateGen(List<RequestedService> pRequestedServiceList)
        {
            //generará un index random para crear el gen lo mas alea
            List<Agent> gen = new List<Agent>();
            foreach (var RS in pRequestedServiceList.AsEnumerable())
            {
                Service service = GetServiceValues(RS.ServiceCode);
                Agent agent = GetRandomAgent(RS.ServiceCode);

                //Suma las horas actuales con las adjudicas por el servicio e igual con la comision
                agent.WorkTime += service.Time;
                agent.EarnedCommission += service.Commission;
                agent.JobCounter += 1; //se le suma un trabajo asignado mas

                gen.Add(agent);
            }

            Gen1 = gen;
        }

        public Service GetServiceValues(string pServiceCode)
        {
            return (from service in XMLData.GetInstance().XMLServices
                    where service.Code == pServiceCode
                    select service).FirstOrDefault();

        }

        //retorna gen aleaorio con el servico pedido para el gen 
        public Agent GetRandomAgent(string pServiceCode)
        {
            random = new Random();

            //obtiene todos los agentes que realizan el servicio especificado
            List<Agent> listAgent = AgentesByServiceDictionary[pServiceCode];

            //Si queda algun agente esta sin tarea, sera la prioridad para asignar la tarea
            List<Agent> listIsNotBusyAgent = (from agent in listAgent
                                              where !agent.IsBusy
                                              select agent).ToList();
            Agent randomAgent;
            if (listIsNotBusyAgent.Count > 0)
            {
                int index = random.Next(listIsNotBusyAgent.Count);
                randomAgent = listIsNotBusyAgent.ElementAt(index);
            }
            else
            {
                int index = random.Next(listAgent.Count);
                randomAgent = listAgent.ElementAt(index);
            }

            randomAgent.IsBusy = true;
            return randomAgent;
        }


        public override string ToString()
        {
            string toString = "\n\nFitness: " + Fitness + "\n";
            foreach (Agent agent in Gen1.AsEnumerable())
            {
                toString += agent;
            }
            return toString;
        }







    }

    



















}
