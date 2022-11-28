using Exercice_Final;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;

//On crée une liste
List<Vehicule> listVehicules = new List<Vehicule>();
 
Console.WriteLine("Bien le bonjour ! \n");
int ChoixDecide = 0;


while (ChoixDecide != 7)
{
    //On demande à l'utilisateur ce qu'il veut faire
    Console.WriteLine("Que voulez vous faire ? \n " +
      "1 : Ajouter un véhicule.\n " +
      "2 : Voir les véhicules. \n " +
      "3 : Modifier un véhicule. \n " +
      "4 : Supprimer un véhicule. \n " +
      "5 : Sauvegarder la liste. \n " +
      "6 : Charger la liste precedente. \n " +
      "7 : Sortir du programme.");

    string FirstDecide = Console.ReadLine();
    if (int.TryParse(FirstDecide, out ChoixDecide))
    {
        switch (ChoixDecide)
        {
            //L'utilisateur ajoute un vehicule
            case (1):
                InfoVehicule();
                break;
            //L'utilisateur visualise la liste
            case (2):
                AfficherList();
                break;
            //L'utilisateur modifie un element
            case (3):
                ModifVehicule();
                break;
            //L'utilisateur supprime un ou plusieurs elements
            case (4):
                SupprimVehicule();
                break;
            //L'utilisateur sauvegarde la liste
            case (5):
                SauvegardeList();
                break;
            //L'utilisateur charge la liste precedemment enregistrer
            case (6):
                ImportList("Vehicules.xml");
                Console.WriteLine("Votre liste a était importer. \n");
                break;
        }
    }
    else
    {
        Console.WriteLine("Veuillez choisir un numero valide. \n");
    }
    //Toute nos méthodes
    void InfoVehicule()
    {
        //On demande à l'utilisateur si c'est une voiture ou un camion
        Console.WriteLine("Voulez vous ajouter une voiture ou un camion?");
        string ChoixVouC = Console.ReadLine();
        while (ChoixVouC != "camion" && ChoixVouC != "voiture")
        {
            Console.WriteLine("Choisissez un vehicule valide.");
            ChoixVouC = Console.ReadLine();
        }
        Console.WriteLine("Choisissez une marque pour votre véhicule.");
        string marqueVehic = Console.ReadLine();
        Console.WriteLine("Choisissez un modele pour votre véhicule.");
        string modeleVehic = Console.ReadLine();
        Console.WriteLine("Choisissez un numéro d'identification pour votre véhicule.");
        string numVehic = Console.ReadLine();
        while (numVehic.Length < 4 || numVehic.Length > 6)
        {
            Console.WriteLine("Veuillez choisir un numero de 4 à 6 chiffres.");
            numVehic = Console.ReadLine();
        }
        int numVehicule = int.Parse(numVehic);
        //Si l'utilsateur veut une voiture
        if (ChoixVouC == "voiture" || ChoixVouC == "Voiture")
        {
            Console.WriteLine("Choisissez une puissance pour votre voiture.");
            string puissVoiture = Console.ReadLine();
            int puisVoit = int.Parse(puissVoiture);
            listVehicules.Add(new Voiture(marqueVehic, modeleVehic, numVehicule, puisVoit));
        }
        //Si l'utilsateur veut un camion
        if (ChoixVouC == "camion" || ChoixVouC == "Camion")
        {
            Console.WriteLine("Choisissez le poids de votre camion.");
            string PoidsCamion = Console.ReadLine();
            decimal PoidsCam = decimal.Parse(PoidsCamion);
            listVehicules.Add(new Camion(marqueVehic, modeleVehic, numVehicule, PoidsCam));
        }
    }
    void ModifVehicule()
    {
        Console.WriteLine("Quel véhicule voulez vous modifier ? \n" +
                "Veuillez noter le numéro du véhicule à modifier.");
        foreach (var car in listVehicules)
        {
            Console.WriteLine(car.ToString());
        }
        string ChoixModif = Console.ReadLine();
        int ChoixMod = int.Parse(ChoixModif);
        foreach (var car in listVehicules)
        {
            if (car.Numero == ChoixMod)
            {
                Console.WriteLine("Veuillez saisir la nouvelle marque du véhicule.");
                string NouvMarque = Console.ReadLine();
                Console.WriteLine("Veuillez saisr le nouveau modele du véhicule.");
                string NouvModele = Console.ReadLine();
                Console.WriteLine("Veuillez choisir le nouveau numero de votre véhicule.");
                string NouvNumero = Console.ReadLine();
                while (NouvNumero.Length < 4 || NouvNumero.Length > 6)
                {
                    Console.WriteLine("Veuillez choisir un numero entre 4 et 6 chiffres");
                    NouvNumero = Console.ReadLine();
                }
                int NewNumero = int.Parse(NouvNumero);
                if (car is Voiture)
                {
                    listVehicules.Remove(car);
                    Console.WriteLine("Veuillez saisir la nouvelle puissance du véhicule.");
                    string NouvPuissance = Console.ReadLine();
                    int NewPuissance = int.Parse(NouvPuissance);
                    listVehicules.Add(new Voiture(NouvMarque, NouvModele, NewNumero, NewPuissance));
                    break;
                }
                if (car is Camion)
                {
                    listVehicules.Remove(car);
                    Console.WriteLine("Veuillez saisir le nouveau poids de votre véhicule.");
                    string NouvPoids = Console.ReadLine();
                    decimal NewPoids = int.Parse(NouvPoids);
                    listVehicules.Add(new Camion(NouvMarque, NouvModele, NewNumero, NewPoids));
                    break;
                }
            }
        }
        Console.WriteLine("Au revoir !");
    }
    void SupprimVehicule()
    {
        Console.WriteLine("Voulez vous tous supprimer ? \n oui/non");
        string DecideSup = Console.ReadLine();
        if (DecideSup == "oui")
        {
            listVehicules.Clear();
        }
        if (DecideSup == "non")
        {
            Console.WriteLine("Quel véhicule voulez vous suprrimer? \n" +
                "indiquez le numero du vehicule a supprimer.");
            foreach (var car in listVehicules)
            {
                Console.WriteLine(car.ToString() + " \n");
            }
            int ChoixSup;
            string ChoixSupr = Console.ReadLine();
            int.TryParse(ChoixSupr, out ChoixSup);
            foreach (var car in listVehicules)
            {
                if (car.Numero == ChoixSup)
                {
                    listVehicules.Remove(car);
                    Console.WriteLine("Le vehicule choisi à été supprimer. \n");
                    break;
                }
                else
                {
                    Console.WriteLine("Aucun véhicule correspondant n'a été trouver. \n");
                    break;
                }
            }
        }
    }
    void SauvegardeList()
    {
        try//On essaye de sauvegarder
        {
            using (var stream = new FileStream
        ("Vehicules.xml", FileMode.Create,
        FileAccess.Write))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Vehicule>));
                xmlSerializer.Serialize(stream, listVehicules);
                Console.WriteLine("Votre liste a été enregistrer.  \n");
            }
        }
        catch (Exception)//Si la sauvegarde ne fonctionne pas
        {
            Console.WriteLine("L'enregistrement n'a pas fonctionner.");
        }
    }
    void AfficherList()
    {
        string ChoixTri = "";
        while (ChoixTri != "oui" && ChoixTri != "non")
        {
            Console.WriteLine("Voulez vous trier la liste ? \n" +
                "oui/non");
            ChoixTri = Console.ReadLine();
            if (ChoixTri == "non")
            {
                Console.WriteLine("Voici la liste de vos véhicules \n");
                foreach (var vehic in listVehicules)
                {
                    Console.WriteLine(vehic.ToString() + " \n");
                }
            }
            if (ChoixTri == "oui")
            {
                int TriNb;
                Console.WriteLine("1 : Trier par marque \n" +
                    "2 : Trier par modele \n" +
                    "3 : Trier par Numero \n" +
                    "4 : Trier par type \n" +
                    "5 : Recherche"
                    );
                string Tri = Console.ReadLine();
                if (int.TryParse(Tri, out TriNb))
                {
                    switch (TriNb)
                    {
                        case (1):
                            {
                                List<Vehicule> listTri = listVehicules.OrderBy(x => x.Marque).ToList();
                                Console.WriteLine(String.Join(Environment.NewLine, listTri));
                                break;
                            }
                        case (2):
                            {
                                List<Vehicule> listTri = listVehicules.OrderBy(x => x.Modele).ToList();
                                Console.WriteLine(String.Join(Environment.NewLine, listTri));
                                break;
                            }
                        case (3):
                            {
                                List<Vehicule> listTri = listVehicules.OrderBy(x => x.Numero).ToList();
                                Console.WriteLine(String.Join(Environment.NewLine, listTri));
                                break;
                            }
                        case (4):
                            {
                                ChoixTri4();
                                break;
                            }
                        case (5):
                            {
                                Console.WriteLine("Veuillez saisir les 3 premiere lettre de la marque de la voiture rechercher.");
                                string SaisiUser = Console.ReadLine();
                                foreach (var vehicules in listVehicules)
                                {
                                    if (vehicules.Marque.ToUpper().StartsWith(SaisiUser.ToUpper()))
                                    {
                                        Console.WriteLine(vehicules);
                                    }
                                }
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Veuillez choisir un tri valide.");
                }               
            }
            else
            {
                Console.WriteLine("Choisissez un nombre valide.");
            }
        }
    }
    void ImportList(string FilePath)
    {
        System.IO.FileStream fsStream = new System.IO.FileStream(FilePath,
        System.IO.FileMode.Open);
        System.Xml.Serialization.XmlSerializer xsSerializer = new
        System.Xml.Serialization.XmlSerializer(typeof(List<Vehicule>));
        var oParameterList = (List<Vehicule>)xsSerializer.Deserialize
        (fsStream);
        listVehicules = oParameterList;
        fsStream.Close();
    }
    void ChoixTri4()
    {
        Console.WriteLine("Voulez vous voir les voitures ou les camions ?");
        string ChoixTriAffiche = Console.ReadLine();
        if (ChoixTriAffiche == "voiture")
        {
            foreach (var car in listVehicules)
            {
                if (car is Voiture)
                {
                    Console.WriteLine(car + "\n");
                }
            }
        }
        if (ChoixTriAffiche == "camion")
        {
            foreach (var camion in listVehicules)
            {
                if (camion is Camion)
                {
                    Console.WriteLine(camion + "\n");
                }
            }
        }

    }
}
//Fin du programme
Console.WriteLine("Au revoir !");