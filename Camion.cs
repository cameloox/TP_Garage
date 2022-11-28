using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercice_Final
{
    [Serializable]
    public class Camion : Vehicule
    {
        
        public decimal Poids { get; set; }

        public Camion() { }
        public Camion(string marque, string modele, int numero, decimal poids) : base(marque, modele, numero)
        {
            Poids = poids;

        }

        public Camion(string marque, string modele, int numero) : base(marque, modele, numero)
        {
        }

        public override string ToString()
        {
            return $"Marque : {Marque} Modele : {Modele} Numero : {Numero} Poids : {Poids}";
        }
    }
}
