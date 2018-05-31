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
        public double Fitness { get; set; }

        /*Constructor sin parametros*/
        public Gen() { }

        public Gen(List<Agent> pGen)
        {
            this.Gen1 = pGen;

            /*valor que se dará por default, despues se calculará el fitness*/
            this.Fitness = 0;
        }

        public double CalculateFitness()
        {
            return 400; //Para poder saber si esta bien. // tener en cuenta el work time de cada agente.
        }
















    }

    



















}
