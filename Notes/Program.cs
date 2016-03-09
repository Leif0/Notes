using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Faker;
using Npgsql;

namespace Notes
{
    class Program
    {

        static void Main(string[] args)
        {
            // Créer l'objet base de donnée et les groupes

            cls_Base l_Base = new cls_Base("localhost", "postgres", "123456", "notes");

            // Créer les groupes
            List<cls_Groupe> l_Groupes = l_Base.CreerGroupes();

            // Créer les élèves
            List<cls_Eleve> l_Eleves = l_Base.CreerEleves();

            // Créer les matières
            List<cls_Matiere> l_Matieres = l_Base.CreerMatieres();

            // Créer les devoirs
            List<cls_Devoir> l_Devoirs = l_Base.CreerDevoirs(l_Matieres);
            
            // Créer les notes

            /************
            * Affichage *
            *************/

            // Eleves
            Utilitaires.WriteColor(ConsoleColor.DarkBlue, ConsoleColor.White, "Élèves", Utilitaires.alignement.Centrer, Utilitaires.espacement.AvantEtApres);

            foreach (cls_Eleve l_Eleve in l_Eleves)
            {
                Console.WriteLine(l_Eleve.getPrenom() + " est dans le groupe " + l_Eleve.getGroupe().getLibelle());
            }

            // Matières

            Utilitaires.WriteColor(ConsoleColor.DarkRed, ConsoleColor.White, "Matières", Utilitaires.alignement.Centrer, Utilitaires.espacement.AvantEtApres);

            foreach (cls_Matiere l_Matiere in l_Matieres)
            {
                Console.WriteLine(l_Matiere.getLibelle() + " est une matière coeff " + l_Matiere.getCoefficient() + " et le professeur de la matière est " + l_Matiere.getProfesseur());
            }

            // Devoirs

            Utilitaires.WriteColor(ConsoleColor.DarkCyan, ConsoleColor.White, "Devoirs", Utilitaires.alignement.Centrer, Utilitaires.espacement.AvantEtApres);

            foreach (cls_Devoir l_Devoir in l_Devoirs)
            {
                Console.WriteLine(l_Devoir.getLibelle() + " est un devoir qui a eu lieu le " + l_Devoir.getDateDevoir().Day + "/" + l_Devoir.getDateDevoir().Month + "/" + l_Devoir.getDateDevoir().Year + " dans la matière " + l_Devoir.getMatiere().getLibelle());
            }

            // Création des semestres
            /*  cls_Semestre l_Semestre1 = new cls_Semestre(1, new DateTime(2015, 8, 1), new DateTime(2016, 1, 1));
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

              // Devoirs du deuxième semestre
              cls_Devoir Devoir7  = new cls_Devoir("DS Mathématique fonctions", new DateTime(2016, 05, 16), l_MatiereMathematique);
              cls_Devoir Devoir8  = new cls_Devoir("DS C# objets", new DateTime(2016, 03, 14), l_MatiereDev);
              cls_Devoir Devoir9  = new cls_Devoir("DS Java orienté objet", new DateTime(2016, 01, 24), l_MatiereHTML);
              cls_Devoir Devoir10 = new cls_Devoir("DS additions", new DateTime(2015, 08, 24), l_MatiereMathematique);
              cls_Devoir Devoir11 = new cls_Devoir("DS Cobol", new DateTime(2016, 01, 18), l_MatiereDev);
              cls_Devoir Devoir12 = new cls_Devoir("DS Go", new DateTime(2016, 05, 24), l_MatiereHTML);

              // Hasard
              Random rnd = new Random();

              // Création de 3 élèves
              cls_Eleve MonEleve;
              List<cls_Eleve> l_Eleves = new List<cls_Eleve>();

              string nom, prenom, adresse;
              DateTime dateNaissance;

              for (int i = 0; i < 2; i++)
              {
                  // Utilise Faker pour générer des noms et date
                  nom           = Faker.NameFaker.LastName();
                  prenom        = Faker.NameFaker.FirstName();
                  dateNaissance = Faker.DateTimeFaker.DateTime(new DateTime(1980, 1, 1), new DateTime(2005, 1, 1));
                  adresse       = Faker.LocationFaker.Street() + "\n\n" + Faker.LocationFaker.ZipCode() + " " + Faker.LocationFaker.City();

                  MonEleve = new cls_Eleve(nom, prenom, dateNaissance, SLAM, adresse);
                  l_Eleves.Add(MonEleve);

                  // Ajout des notes aléatoires
                  // Tableau temporaire pour des données d'exemple
                  cls_Devoir[] l_DevoirsSemestre1 = {Devoir1, Devoir2, Devoir3, Devoir4, Devoir5, Devoir6};

                  // Premier semestre
                  foreach (cls_Devoir l_Devoir in l_DevoirsSemestre1)
                  {
                      double noteAleatoire = Math.Round(rnd.NextDouble() * 20.0, 2);
                      cls_Note Note = new cls_Note(noteAleatoire, MonEleve, l_Devoir, l_Semestre1);
                  }

                  // Deuxième semestre
                  cls_Devoir[] l_DevoirsSemestre2 = { Devoir7, Devoir8, Devoir9, Devoir10, Devoir11, Devoir12 };

                  foreach (cls_Devoir l_Devoir in l_DevoirsSemestre2)
                  {
                      double noteAleatoire = Math.Round(rnd.NextDouble() * 20.0, 2);
                      cls_Note Note = new cls_Note(noteAleatoire, MonEleve, l_Devoir, l_Semestre2);
                  }

                  // Appréciations aléatoires

                  // Premier semestre
                  cls_Appreciation appreciation1 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereDev, l_Semestre1);
                  cls_Appreciation appreciation2 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereHTML, l_Semestre1);
                  cls_Appreciation appreciation3 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereMathematique, l_Semestre1);

                  // Deuxième semestre
                  cls_Appreciation appreciation4 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereDev, l_Semestre2);
                  cls_Appreciation appreciation5 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereHTML, l_Semestre2);
                  cls_Appreciation appreciation6 = new cls_Appreciation(Faker.TextFaker.Sentence(), MonEleve, l_MatiereMathematique, l_Semestre2);
              }


              // Affichage

              Console.WriteLine("Moyenne du premier semestre");

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

                  Console.WriteLine("Toutes les notes en développement : ");
                  cls_Note derniereNote = eleve.getNotesMatiere(l_MatiereDev).Last();

                  foreach (cls_Note l_note in eleve.getNotesMatiere(l_MatiereDev))
                  {
                      if (l_note.Equals(derniereNote))
                      {
                          Console.Write(l_note.getValeur());
                      }
                      else
                      {
                          Console.Write(l_note.getValeur());
                          Console.Write(", ");
                      }
                  }

                  Console.Write("\n");
                  Utilitaires.WriteColor(ConsoleColor.Blue, ConsoleColor.White, "Moyenne : " + Math.Round(eleve.MoyenneSemestre(l_Semestre1), 2));
                  Console.Write("\n");

                  Utilitaires.Separateur();
              }

              Utilitaires.WriteColor(ConsoleColor.DarkCyan, ConsoleColor.White, "Moyenne maximum du groupe en C# pour le premier semestre : " + SLAM.getMoyenneMaximumPourMatiereSemestre(l_MatiereDev, l_Semestre1));
              Console.Write("\n");
              Utilitaires.WriteColor(ConsoleColor.DarkBlue, ConsoleColor.White, "Moyenne minimum du groupe en Mathématiques pour le premier semestre : " + SLAM.getMoyenneMinimumPourMatiereSemestre(l_MatiereMathematique, l_Semestre2));
              Console.Write("\n");
              Utilitaires.WriteColor(ConsoleColor.DarkMagenta, ConsoleColor.White, "Moyenne du groupe en HTML/Java pour le premier semestre : " + SLAM.MoyenneGroupePourMatiereSemestre(l_MatiereHTML, l_Semestre1));
              */
            // Génère et ouvre un PDF pour le premier semestre
            //cls_Pdf pdf = new cls_Pdf(SLAM, l_Semestre1);

            Console.ReadLine();
        }
    }
}
