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
    public class Voiture : Vehicule
    {
        
        public int Puissance { get; set; }
        public Voiture() { }
        public Voiture(string marque, string modele, int numero, int puissance) : base(marque, modele, numero)
        {

            Puissance = puissance;
        }


        public virtual string Afficher()
        {
            return $"Marque : {Marque} Modele : {Modele} Numero : {Numero} Puissance : {Puissance}";
        }
        public override string ToString()
        {
            return Afficher();
        }
    }
}
