using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Globalization;

namespace Proyecto_IA_2.Source
{
    class AgenteDeVoz
    {
        private static SpeechRecognitionEngine escucha;
        private SpeechSynthesizer sintetizador;
        private static AgenteDeVoz instance;
        private List<string> comandosExtra = new List<string>();

        public AgenteDeVoz()
        {
            sintetizador = new SpeechSynthesizer();
            agregarComandosExtraALista();

        }
        public static AgenteDeVoz Instance
        {
            get
            {
                if (null == instance)
                    instance = new AgenteDeVoz();
                return instance;
            }
        }
        public void hablar(string frase)
        {
            try
            {
                sintetizador.Speak(frase);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No se puede iniciar");
            }

        }

        public void setEscucha(SpeechRecognitionEngine pEscucha)
        {
            escucha = pEscucha;
        }

        public SpeechRecognitionEngine getEscuchaNumerica()
        {

            escucha.UnloadAllGrammars();

            Choices comandos = aprenderComandos(new Choices());
            GrammarBuilder comandosAgente = new GrammarBuilder();
            comandosAgente.Append(comandos);
            Grammar gramaticaComandos = new Grammar(comandosAgente);
            //---------------------------------



            escucha.LoadGrammarAsync(gramaticaComandos);
            return escucha;
        }

        public SpeechRecognitionEngine getEscucha()
        {
            return escucha;
        }

        private Choices aprenderComandos(Choices comandos)
        {
            foreach (var comando in comandosExtra)
            {
                comandos.Add(comando);
            }
            return comandos;
        }

        private Choices aprenderNumeros(Choices numeros)
        {
            for (var i = 0; i <= 400; i++)
            {
                numeros.Add(i.ToString());
            }

            return numeros;

        }


        public void agregarComandosExtraALista()
        {
            //Comandos de funcionalidad
            comandosExtra.Add("cargar agentes");
            comandosExtra.Add("mostrar agentes");
            comandosExtra.Add("cargar órdenes");
            comandosExtra.Add("mostrar órdenes");
            comandosExtra.Add("repartir órdenes");


            //Comandos de geléctric
            comandosExtra.Add("cerrar ventana resultado");
            comandosExtra.Add("ayuda geléctric");
            comandosExtra.Add("canta geléctric");
            comandosExtra.Add("adiós geléctric");
            comandosExtra.Add("salir geléctric");


        }

        public void noEscuchar()
        {
            escucha.Dispose();
        }
    }
}
