using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Eleve
    {
        private string c_Nom;
        private string c_Prenom;
        private DateTime c_DateNaissance;
        private cls_Groupe c_Groupe;
        private List<cls_Note> c_Notes;
        static Random rnd = new Random();
        private string c_Adresse;

        /// <summary>
        /// Créer un nouvel élève
        /// </summary>
        /// <param name="pNom">Nom de l'élève</param>
        /// <param name="pPrenom">Prénom de l'élève</param>
        /// <param name="pDateNaissance">Date de naissance de l'élève</param>
        /// <param name="pGroupe">Groupe à lequel l'élève appartient</param>
        /// <param name="pAdresse">L'adresse postale de l'élève</param>
        public cls_Eleve(string pNom, string pPrenom, DateTime pDateNaissance, cls_Groupe pGroupe, string pAdresse)
        {
            setNom(pNom);
            setPrenom(pPrenom);
            setDateNaissance(pDateNaissance);
            setGroupe(pGroupe);
            pGroupe.ajouterEleve(this);
            c_Notes = new List<cls_Note>();
            setAdresse(pAdresse);
        }

        /// <summary>
        /// Retourne le nom de l'élève
        /// </summary>
        /// <returns>Nom de l'élève</returns>
        public string getNom()
        {
            return c_Nom;
        }

        public void setNom(string pValeur)
        {
            if(pValeur == "")
            {
                throw new Exception("Le nom ne doit pas être vide");
            }
            else
            {
                c_Nom = pValeur;
            }
        }

        public string getPrenom()
        {
            return c_Prenom;
        }

        public void setPrenom(string pValeur)
        {
            if (pValeur == "")
            {
                throw new Exception("Le prénom ne doit pas être vide");
            }
            else
            {
                c_Prenom = pValeur;
            }
        }

        public cls_Groupe getGroupe()
        {
            return c_Groupe;
        }

        public void setGroupe(cls_Groupe pGroupe)
        {
            c_Groupe = pGroupe;
        }

        public DateTime getDateNaissance()
        {
            return c_DateNaissance;
        }

        public void setDateNaissance(DateTime pDate)
        {
            c_DateNaissance = pDate;
        }

        public int Age()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - c_DateNaissance.Year;

            if (c_DateNaissance > now.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public void ajouterNote(cls_Note pNote)
        {
            c_Notes.Add(pNote);
        }

        public List<cls_Note> getNotes()
        {
            return c_Notes;
        }

        public double Moyenne()
        { 
            double total = 0, totalNotes = 0;
            int coefficient;

            foreach (var l_note in c_Notes)
            {
                coefficient = l_note.getDevoir().getMatiere().getCoefficient();

                double noteAvecCoeff = l_note.getValeur() * coefficient;
                total += noteAvecCoeff;
                totalNotes += coefficient;
            }

            return total / totalNotes;
        }

        public double MoyenneMatiere(cls_Matiere pMatiere)
        {
            double cumul = 0;

            for (int i = 0; i < c_Notes.Count; i++)
            {
                if (c_Notes[i].getDevoir().getMatiere() == pMatiere)
                {
                    cumul += c_Notes[i].getValeur();
                }
            }
            return cumul;
        }

        public void setAdresse(string pAdresse)
        {
            c_Adresse = pAdresse;
        }

        public string getAdresse()
        {
            return c_Adresse;
        }
    }
}
