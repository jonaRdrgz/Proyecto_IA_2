using Proyecto_IA_2.Source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_IA_2
{

    public partial class Form1 : Form
    {
        private List<Agent> agents;
        private List<RequestedService> requestedServices;
        private AgenteDeVoz agente = AgenteDeVoz.Instance;
        private Form2 formResultado;
        public Form1()
        {
            InitializeComponent();
            //agente.getEscucha().RecognizeAsyncStop();

        }

        private void loadAgents_Click(object sender, EventArgs e)
        {
            cargarAgentes();

        }

        private void cargarAgentes() {
            try
            {
                agentsDataGridView.Rows.Clear();
                agentsDataGridView.Refresh();
                agents = Program.LoadAgents();
                agente.hablar("Los agentes se cargaron con éxito");
            }
            catch (Exception ex)
            {
                agente.hablar("lamentablemente no pude cargar los agentes");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void mostrarAgents_Click(object sender, EventArgs e)
        {
            mostrarAgentes();
        }

        private void mostrarAgentes() {
            try
            {
                foreach (Agent agent in agents)
                {
                    string[] agentInfo = { "", "", "" };
                    IEnumerable<string> listOfServices = agent.ServiceList;
                    agentInfo[0] = agent.ID;
                    agentInfo[1] = agent.Name;
                    string serviceListSTR = "";
                    foreach (string service in listOfServices)
                    {
                        serviceListSTR += service + ", ";
                    }
                    agentInfo[2] = serviceListSTR;
                    agentsDataGridView.Rows.Add(agentInfo);
                }
            }
            catch (Exception ex)
            {
                agente.hablar("Debe cargar los agentes primero");
            }
        }

        private void agentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadRequestedServices_Click(object sender, EventArgs e)
        {
            cargarOrdenes();

        }

        private void cargarOrdenes() {
            try
            {

                requestedServicesDataGridView.Rows.Clear();
                requestedServicesDataGridView.Refresh();
                requestedServices = Program.LoadRequestedServices();
                agente.hablar("Las órdenes se cargaron con éxito");
            }
            catch (Exception ex)
            {
                agente.hablar("lamentablemente no pude cargar las órdenes");
            }
        }

        private void ShowRequestedServices_Click(object sender, EventArgs e)
        {

            mostrarOrdenes();

        }

        private void mostrarOrdenes() {
            try
            {
                foreach (RequestedService service in requestedServices)
                {
                    string[] serviceInfo = { "", "", "" };
                    serviceInfo[0] = service.ID;
                    serviceInfo[1] = service.CustomerName;
                    serviceInfo[2] = service.ServiceCode;
                    requestedServicesDataGridView.Rows.Add(serviceInfo);
                }
            }
            catch (Exception ex)
            {
                agente.hablar("Debe cargar las órdenes primero");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            repartirOrdenes();

        }

        private void repartirOrdenes() {
            try
            {
                
                GeneticAlgorithm a = new GeneticAlgorithm(agents, requestedServices);
                agente.hablar("Espera mientras resuelvo el problema");
                a.CreateInitialPopulation();
                a.CalculateFitnessGenes();
                for (int i = 0; i < a.GenerationsNumber; i++)
                {
                    a.CreateNextGeneration();
                    a.CalculateFitnessGenes();
                }


                Console.WriteLine(a.BestGenByGeneration());

                formResultado = new Form2();
                formResultado.Show();
                formResultado.cargarGen(a);
                agente.hablar("Así se debe repartir las órdenes");
            }
            catch (Exception ex)
            {
                agente.hablar("Debe cargar los agentes y órdenes primero");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1;





            timer.Tick += delegate (object s, EventArgs ee)
            {
                ((Timer)s).Stop();

                agente.hablar("Hola bienvenido al programa de asignar tareas");
                agente.hablar(" Mi nombre es Geléctric,  y te acompañaré en tu estadía");
                agente.hablar(" Los comandos a utilizar son: cargar agentes, mostrar agente, cargar órdenes, mostrar órdenes y distribuir tareas");
                agente.hablar("Para conocer la función de cada comando di: ayuda geléctric");

                CultureInfo ci = new CultureInfo("es-ES");
                agente.setEscucha(new SpeechRecognitionEngine(ci));
                SpeechRecognitionEngine rec = agente.getEscuchaNumerica();
                rec.SetInputToDefaultAudioDevice();
                rec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(lector);
                rec.RecognizeAsync(RecognizeMode.Multiple);

            };
            timer.Start();
        }

        private void lector(object sender, SpeechRecognizedEventArgs e)
        {
            
            if (e.Result.Text == "cargar agentes")
            {

                cargarAgentes();

            }
            else if (e.Result.Text == "mostrar agentes") {
                mostrarAgentes();
            }
            else if (e.Result.Text == "cargar órdenes")
            {
                cargarOrdenes();
            }
            else if (e.Result.Text == "mostrar órdenes")
            {
                mostrarOrdenes();
            }
            else if (e.Result.Text == "repartir órdenes")
            {
                repartirOrdenes();
            }
            else if (e.Result.Text == "cerrar ventana resultado")
            {
                formResultado.Close();
            }
            else if (e.Result.Text == "canta geléctric")
            {
                agente.hablar("Cumbia cumbia cumbia tra-tra, yeah");
                agente.hablar("Bueno, no tengo ritmo, espero haberte ayudado jaja xD saludos");
            }
            else if (e.Result.Text == "adiós geléctric" || e.Result.Text == "salir geléctric")
            {
                agente.hablar("Creo que fuimos grandes amigos, pero Adiós,  espero que pases ía");
                this.Close();
                Application.Exit();
            }
            else if (e.Result.Text == "ayuda geléctric")
            {
                //callar = false;
                agente.hablar("Gracias, se que me ocupás humano");
                agente.hablar("Diga el comando cargar agentes para leer el archivo XML con los datos de los agentes.");
                agente.hablar("O Diga el comando mostrar agentes para mostrar en la pantalla la información de los agentes");
                agente.hablar("O Diga el comando cargar órdenes para leer el archivo XML con los datos de las órdenes.");
                agente.hablar("O Diga el comando mostrar órdenes para mostrar en la pantalla la información de las órdenes");
                agente.hablar("O Diga el comando repartir órdenes para asignar tareas a los agentes");
                agente.hablar("Si quieres que cante di: canta geléctric y escucharás un cumbión");
                agente.hablar("O si te aburristes, di nada mas: Adiós geléctric, y saldras de la aplicacion y estaré triste jajaja xD");
            }
            else
            {
                agente.hablar("No entiendo, habla mas claro por favor");
            }
        }
     }
}
