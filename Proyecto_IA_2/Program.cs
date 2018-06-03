using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_IA_2.Source;

namespace Proyecto_IA_2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XMLData e = XMLData.GetInstance();
            GeneticAlgorithm a = new GeneticAlgorithm(e.XMLAgents, e.XMLRequestedServices);
            a.CreateInitialPopulation();
            a.CalculateFitnessGenes();
            Console.WriteLine(a.BestGenByGeneration());
            Console.WriteLine("Generación 0...");
            for (int i = 0; i < a.GenerationsNumber; i++)
            {
                Console.WriteLine("Generación " + i + "...");
                a.CreateNextGeneration();
                a.CalculateFitnessGenes();

                Console.WriteLine(a.BestGenByGeneration());
            }

            foreach(Agent r in a.BestGenByGeneration().AgentList.AsEnumerable())
            {
                Console.WriteLine(r);
            }
            

        }

        public static List<Agent> LoadAgents()
        {
            XElement XMLAgents = XElement.Load("../../XMLData/Agents.xml");

            return (from agent in XMLAgents.Elements("Agent")
                    select new Agent
                    (
                        agent.Attribute("ID").Value,
                        agent.Attribute("Name").Value,

                        (from service in agent.Elements("Service")
                        select
                        (
                            service.Attribute("Code").Value
                        )).ToList() // Lista de servicio 

                    )).ToList();
        }

        public static List<RequestedService> LoadRequestedServices()
        {
            XElement XMLRequestedService = XElement.Load("../../XMLData/RequestedService.xml");

            return (from requestedService in XMLRequestedService.Elements("RequestedService")
                    select new RequestedService
                    (
                        requestedService.Attribute("ID").Value,
                        requestedService.Element("Customer").Attribute("Name").Value,
                        requestedService.Element("Service").Attribute("Code").Value

                    )).ToList();
        }

        public static List<Service> LoadServices()
        {
           
            XElement XMLServices = XElement.Load("../../XMLData/Services.xml");

            return (from service in XMLServices.Elements("Service")
                    select new Service
                    (
                        service.Attribute("Code").Value,
                        service.Attribute("ServiceName").Value,
                        int.Parse(service.Attribute("Time").Value),
                        int.Parse(service.Attribute("Commission").Value)

                    )).ToList();
        }












    }
}
