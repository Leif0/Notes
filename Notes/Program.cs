using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Faker;

namespace Notes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création du groupe
            cls_Groupe SLAM = new cls_Groupe("SLAM");

            // Création des semestres
            cls_Semestre l_Semestre1 = new cls_Semestre(1, new DateTime(2015, 8, 1), new DateTime(2016, 1, 1));
            cls_Semestre l_Semestre2 = new cls_Semestre(2, new DateTime(2016, 1, 1), new DateTime(2016, 6, 1));

            // Création des matières
            cls_Matiere l_MatiereDev          = new cls_Matiere("C#", SLAM, 6, Faker.NameFaker.Name());
            cls_Matiere l_MatiereMathematique = new cls_Matiere("Mathématiques", SLAM, 2, Faker.NameFaker.Name());
            cls_Matiere l_MatiereHTML         = new cls_Matiere("HTML", SLAM, 3, Faker.NameFaker.Name());

            // Création des devoirs
            cls_Devoir Devoir1 = new cls_Devoir("DM de mathématique", new DateTime(2016, 05, 16), l_MatiereMathematique);
            cls_Devoir Devoir2 = new cls_Devoir("DS C# et SQL", new DateTime(2016, 03, 14), l_MatiereDev);
            cls_Devoir Devoir3 = new cls_Devoir("DS 1 HTML et Java", new DateTime(2016, 01, 24), l_MatiereHTML);
            cls_Devoir Devoir4 = new cls_Devoir("DM de mathématique numéro 2", new DateTime(2015, 08, 24), l_MatiereMathematique);
            cls_Devoir Devoir5 = new cls_Devoir("DS Javascript", new DateTime(2016, 01, 18), l_MatiereDev);
            cls_Devoir Devoir6 = new cls_Devoir("DS JavaEE", new DateTime(2016, 05, 24), l_MatiereHTML);

            // Hasard
            Random rnd = new Random();

            // Création de 3 élèves
            cls_Eleve MonEleve;
            List<cls_Eleve> l_Eleves = new List<cls_Eleve>();

            string nom, prenom, adresse;
            DateTime dateNaissance;

            for (int i = 0; i < 3; i++)
            {
                // Utilise Faker pour générer des noms et date
                nom = Faker.NameFaker.LastName();
                prenom = Faker.NameFaker.FirstName();
                dateNaissance = Faker.DateTimeFaker.DateTime(new DateTime(1980, 1, 1), new DateTime(2005, 1, 1));
                adresse = Faker.LocationFaker.Street() + "\n\n" + Faker.LocationFaker.ZipCode() + " " + Faker.LocationFaker.City();
                
                MonEleve = new cls_Eleve(nom, prenom, dateNaissance, SLAM, adresse);
                l_Eleves.Add(MonEleve);

                // Ajout des notes aléatoires
                cls_Devoir[] l_Devoirs = {Devoir1, Devoir2, Devoir3, Devoir4, Devoir5, Devoir6};

                foreach (cls_Devoir l_Devoir in l_Devoirs)
                {
                    double noteAleatoire = Math.Round(rnd.NextDouble() * 20.0, 2);
                    cls_Note Note = new cls_Note(noteAleatoire, MonEleve, l_Devoir, l_Semestre1);
                }

                // Appréciations aléatoires
                cls_Appreciation appreciation1 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereDev);
                cls_Appreciation appreciation2 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereHTML);
                cls_Appreciation appreciation3 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereMathematique);
            }

            // Affichage
            foreach (var eleve in SLAM.getListeEleve())
            {
                Utilitaires.Separateur();

                Utilitaires.WriteColor(ConsoleColor.DarkGreen, ConsoleColor.White, eleve.getNom() + " " + eleve.getPrenom());

                Console.WriteLine(" est dans le groupe " +
                    eleve.getGroupe().getLibelle() + " et a " + eleve.Age() + " ans \n");

                Utilitaires.WriteColor(ConsoleColor.DarkRed, ConsoleColor.White, "Note pour les devoirs : \n\n");

                foreach (var note in eleve.getNotes())
                {
                    Console.WriteLine("\"" + note.getDevoir().getLibelle() + "\" => " + note.getValeur() + " (Coeff. " + note.getDevoir().getMatiere().getCoefficient() + ") ");
                }

                Console.Write("\n");
                Utilitaires.WriteColor(ConsoleColor.Blue, ConsoleColor.White, "Moyenne : " + Math.Round(eleve.Moyenne(), 2));
                Console.Write("\n");
                
                Utilitaires.Separateur();
            }

            // Génère et ouvre un PDF
            cls_Pdf pdf = new cls_Pdf(SLAM, l_Semestre1);

            Console.ReadLine();
        }

    }
}
