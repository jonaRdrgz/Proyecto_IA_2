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
        public int MutationProbability { get; set; }
        public int InitialPopulationNumber { get; set; }
        public List<Gen> Population { get; set; }
        public List<Agent> AgentList { get; set; }
        public List<RequestedService> RequestedServiceList { get; set; }


        /*Constructor sin parametros*/
        public GeneticAlgorithm() { }



        public GeneticAlgorithm(List<Agent> pAgentList, List<RequestedService> pRequestedServiceList)
        {
            this.AgentList = pAgentList;
            this.RequestedServiceList = pRequestedServiceList;

            /*Valores por default*/
            this.MutationProbability = 10;
            this.GenerationsNumber = 500;
            this.InitialPopulationNumber = 100;
        }

        public void CreateInitialPopulation()
        {

        }

        public void CreateNextGeneration()
        {

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
            Gen tmp = new Gen();
            return tmp;
        }



        /*Creara el nuevo gen en a sus padres(Cruce)*/
        public Gen CreateChildGen(Gen Parent1, Gen Parent2)
        {
            Gen tmp = new Gen();
            return tmp;
        }

        public Gen Crossing(Gen Parent1, Gen Parent2)
        {
            Gen tmp = new Gen();
            return tmp;
        }




        

       /*Cuando haya llegado al limite de generaciones, se obtendra el mejor gen de la ultima poblacion*/
        public Gen BestGenByGeneration()
        {
            //Asi se ordena por propiedad.
            /*List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();*/

            Gen tmp = new Gen();
            return tmp;
        }









    }
}
