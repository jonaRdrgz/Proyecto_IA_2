using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA_2.Source
{
    class GeneticAlgorithm
    {
        public int GenerationsNumber { get; set; }
        public int InitialPopulationNumber { get; set; }
        public int ElitismNumber { get; set; }
        public List<Gen> Population { get; set; }
        public List<Agent> AgentList { get; set; }
        public List<RequestedService> RequestedServiceList { get; set; }
        public Dictionary<Agent, List<RequestedService>> ServicesByAgentsDictionary { get; set; }
        public static Random random;


        /*Constructor sin parametros*/
        public GeneticAlgorithm() { }



        public GeneticAlgorithm(List<Agent> pAgentList, List<RequestedService> pRequestedServiceList)
        {
            this.AgentList = pAgentList;
            this.RequestedServiceList = pRequestedServiceList;
            random = new Random();
            /*Valores por default*/
            this.GenerationsNumber = 250;
            this.InitialPopulationNumber = 50;
            this.ElitismNumber = 5;



        }

        
        public Dictionary<string, List<string>> GetDictionary(Gen gen)
        {
            Dictionary<string, List<string>> RSAPro = new Dictionary<string, List<string>>();
            foreach (Agent agent in gen.AgentList)
            {
                List<int> requestedServicesAgents = new List<int>();
                for (int i = 0; i < gen.Gen1.Count; i++)
                {
                    if(gen.Gen1[i].ID == agent.ID)
                    {
                        requestedServicesAgents.Add(i);
                    }

                }

                List<string> RSA = new List<string>();
                foreach (int RS in requestedServicesAgents.AsEnumerable())
                {
                    RSA.Add(RequestedServiceList[RS].ID);
                }


               

                RSAPro.Add(agent.ID, RSA);


            }
            



            return RSAPro;
        }

        public void CreateInitialPopulation()
        {
            // initial population
            this.Population = new List<Gen>();

            for (int i = 0; i < this.GenerationsNumber; i++)
            {
                // ingresa uin nuevo gen a la poblacion
                List<Agent> AgentListAux = AgentList.Select(agent => new Agent(agent)).ToList();
                Gen gen = new Gen(AgentListAux);
                gen.CreateGen(RequestedServiceList);
                this.Population.Add(gen);
            }


        }

        

        public void CreateNextGeneration()
        {
            List<Gen> tmp = new List<Gen>();
            for (int i = 0; i < (GenerationsNumber - ElitismNumber); i++)
            {
                Gen parent1 = GenSelection();
                Gen parent2 = GenSelection();
                tmp.Add(CreateChildGen(parent1, parent2));
            }

            //los mejores genes de la poblacion
            List<Gen> elitismGroup = Population.OrderBy(g => g.Fitness).ToList().GetRange(0, ElitismNumber);

            tmp.AddRange(elitismGroup);

            this.Population = tmp;


        }

        public void CalculateFitnessGenes()
        {
            foreach (Gen gen in Population.AsEnumerable())
            {
                gen.CalculateFitness();
            }
        }

        /*Selecion de gen, por torneo*/
        public Gen GenSelection()
        { 
            int lengthPopulation = this.Population.Count;
            //Padres para el torneo
            int index = random.Next(lengthPopulation);
            Gen parent1 = this.Population.ElementAt(index);
            Console.WriteLine(index);

            index = random.Next(lengthPopulation);
            Gen parent2 = this.Population.ElementAt(index);
            Console.WriteLine(index);
            //Devuelve el menor de los padres, ya que significa que que la desviacion
            //estandar es menor y que la cantidad de horas casi no exceden.
            return parent1.Fitness < parent2.Fitness ? parent1 : parent2;
        }



        /*Creara el nuevo gen en a sus padres(Cruce)*/
        public Gen CreateChildGen(Gen pParent1, Gen pParent2)
        {

            List<Agent> AgentListAux = AgentList.Select(agent => new Agent(agent)).ToList();

            List<Agent> crossedGen = Crossing(pParent1, pParent2);
            //Gen nuevo vacio
            Gen child = new Gen(AgentListAux);

            //Crea los objetos nuevos para no referenciar a objetos anteriores
            child.CreateChildGen(crossedGen, RequestedServiceList);

            child.Mutation(RequestedServiceList);
            child.ManipulatedMutation(RequestedServiceList);
 
            return child;
        }

        //Genes cruzados, [2, 34 , 1, 2] -- [123, 22, 232, 3] ==> [2, 34, 233, 3]
        public List<Agent> Crossing(Gen pParent1, Gen pParent2)
        {
            var random = new Random();
            int lengthGen = pParent1.Gen1.Count;
            int index = random.Next(lengthGen);

            List<Agent> newGen = new List<Agent>();
            //los primeros index elementos del parent1
            newGen.AddRange(pParent1.Gen1.GetRange(0, index));

            //los ultimos (lengthGen - index) elementos del parent2
            newGen.AddRange(pParent2.Gen1.GetRange(index, (lengthGen - index)));


            return newGen;
        }




        

       /*Cuando haya llegado al limite de generaciones, se obtendra el mejor gen de la ultima poblacion*/
        public Gen BestGenByGeneration()
        {
            //Asi se ordena por propiedad.
            Gen gen = Population.OrderBy(g => g.Fitness).ToList().FirstOrDefault();
            return gen;
        }

        public override string ToString()
        {
            string toString = "";
            foreach(Gen gen in Population.AsEnumerable())
            {
                toString += gen + "\n";
                
            }

            return toString;
            
        }







    }
}
