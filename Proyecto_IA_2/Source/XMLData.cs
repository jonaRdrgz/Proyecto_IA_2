using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA_2.Source
{
    class XMLData
    {
        public List<Agent> XMLAgents { get; set; }
        public List<Service> XMLServices { get; set; }
        public List<RequestedService> XMLRequestedServices { get; set; }

        private static XMLData instance = null;

        private XMLData()
        {
            this.XMLAgents = LoadAgents();
            this.XMLServices = LoadServices();
            this.XMLRequestedServices = LoadRequestedServices();
        }

        public static XMLData GetInstance()
        {
            if (instance == null)
            {
                instance = new XMLData();
            }
               
            return instance;
        }


        private  List<Agent> LoadAgents()
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

        private  List<RequestedService> LoadRequestedServices()
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

        private  List<Service> LoadServices()
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
