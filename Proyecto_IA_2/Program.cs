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
            //IEnumerable<Agent> c = LoadAgents();
            //IEnumerable<RequestedService> rs = LoadRequestedServices();
            //Console.WriteLine("\n\n");



            //foreach (RequestedService r in rs)
            //{
            //    Console.WriteLine(r.ID + " " + r.CustomerName + " " + r.ServiceCode);
            //}
            //foreach (Agent a in c)
            //{
            //    Console.WriteLine(a.ID + " " + a.Name);
            //    IEnumerable<string> l = a.ServiceList;
            //    foreach(string s in l)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
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

    }
}
