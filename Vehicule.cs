using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercice_Final
{
    
    [XmlInclude(typeof(Voiture))]
    [XmlInclude(typeof(Camion))]
    [Serializable]
    public abstract class Vehicule
    {
        
        
        public string Marque { get; set; }
        
        public string Modele { get; set; }
        
        public int Numero { get; set; }

        public Vehicule() { }
        public Vehicule(string marque, string modele, int numero)
        {
            Marque = marque;
            Modele = modele;
            Numero = numero;

        }


        public override string ToString()
        {
            return $"Marque : {Marque} Modele : {Modele} Numero : {Numero}";
        }

       
       
        
    }
}

