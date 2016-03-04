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
        private List<cls_Appreciation> c_Appreciations; 
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
            c_Appreciations = new List<cls_Appreciation>();
        }

        /// <summary>
        /// Retourne le nom de l'élève
        /// </summary>
        /// <returns>Nom de l'élève</returns>
        public string getNom()
        {
            return c_Nom;
        }

        /// <summary>
        /// Modifie le nom de l'élève
        /// </summary>
        /// <param name="pNom">Nom de l'élève</param>
        public void setNom(string pNom)
        {
            if(pNom == "")
            {
                throw new Exception("Le nom ne doit pas être vide");
            }
            else
            {
                c_Nom = pNom;
            }
        }

        /// <summary>
        /// Modifie le prénom de l'élève
        /// </summary>
        /// <returns>Prénom de l'élève</returns>
        public string getPrenom()
        {
            return c_Prenom;
        }

        /// <summary>
        /// Modifie le prénom de l'élève
        /// </summary>
        /// <param name="pPrenom">Prénom de l'élève</param>
        public void setPrenom(string pPrenom)
        {
            if (pPrenom == "")
            {
                throw new Exception("Le prénom ne doit pas être vide");
            }
            else
            {
                c_Prenom = pPrenom;
            }
        }

        /// <summary>
        /// Retourne le groupe
        /// </summary>
        /// <returns>Groupe</returns>
        public cls_Groupe getGroupe()
        {
            return c_Groupe;
        }

        /// <summary>
        /// Modifie le groupe de l'élève
        /// </summary>
        /// <param name="pGroupe">Groupe de l'élève</param>
        public void setGroupe(cls_Groupe pGroupe)
        {
            c_Groupe = pGroupe;
        }

        /// <summary>
        /// Retourne la date de naissance de l'élève
        /// </summary>
        /// <returns>Date de naissance de l'élève</returns>
        public DateTime getDateNaissance()
        {
            return c_DateNaissance;
        }

        /// <summary>
        /// Modifie la date de naissance de l'élève
        /// </summary>
        /// <param name="pDate">Date de naissance de l'élève</param>
        public void setDateNaissance(DateTime pDate)
        {
            c_DateNaissance = pDate;
        }

        /// <summary>
        /// Retourne l'âge de l'élève
        /// </summary>
        /// <returns>Age de l'élève</returns>
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

        /// <summary>
        /// Ajoute une note à l'élève
        /// </summary>
        /// <param name="pNote">Note à ajouter</param>
        public void ajouterNote(cls_Note pNote)
        {
            c_Notes.Add(pNote);
        }

        /// <summary>
        /// Retourne la liste des notes de l'élève
        /// </summary>
        /// <returns>Liste des notes de l'élève</returns>
        public List<cls_Note> getNotes()
        {
            return c_Notes;
        }

        public List<cls_Note> getNotesMatiere(cls_Matiere pMatiere)
        {
            List<cls_Note> l_NotesMatiere = new List<cls_Note>();
            foreach (cls_Note l_note in c_Notes)
            {
                if (l_note.getDevoir().getMatiere() == pMatiere)
                {
                    l_NotesMatiere.Add(l_note);
                }
            }

            return l_NotesMatiere;
        } 

        /// <summary>
        /// Retourne la moyenne générale de l'élève à l'année
        /// </summary>
        /// <returns>Moyenne générale de l'élève</returns>
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

        public double MoyenneSemestre(cls_Semestre pSemestre)
        {
            double total = 0, totalNotes = 0;
            int coefficient;

            foreach (var l_note in c_Notes)
            {
                if (l_note.getSemestre() == pSemestre)
                {
                    coefficient = l_note.getDevoir().getMatiere().getCoefficient();

                    double noteAvecCoeff = l_note.getValeur() * coefficient;
                    total += noteAvecCoeff;
                    totalNotes += coefficient;
                }
            }

            return total / totalNotes;
        }

        /// <summary>
        /// Retourne la moyenne de l'élève pour une matière spécifique
        /// </summary>
        /// <param name="pMatiere">Matière</param>
        /// <returns>Moyenne de l'élève pour une matière spécifique</returns>
        public double MoyenneMatiere(cls_Matiere pMatiere)
        {
            double cumul = 0;
            int totalNotes = 0;

            for (int i = 0; i < c_Notes.Count; i++)
            {
                if (c_Notes[i].getDevoir().getMatiere() == pMatiere)
                {
                    cumul += c_Notes[i].getValeur();
                    totalNotes++;
                }
            }
            return cumul / totalNotes;
        }

        /// <summary>
        /// Retourne la moyenne du semestre pour l'élève
        /// </summary>
        /// <param name="pMatiere">Matière</param>
        /// <param name="pSemestre">Semestre</param>
        /// <returns></returns>
        public double MoyenneMatiereSemestre(cls_Matiere pMatiere, cls_Semestre pSemestre)
        {
            double cumul = 0;
            int totalNotes = 0;

            for (int i = 0; i < c_Notes.Count; i++)
            {
                if (c_Notes[i].getDevoir().getMatiere() == pMatiere && 
                   pSemestre == c_Notes[i].getSemestre() )
                {
                    cumul += c_Notes[i].getValeur();
                    totalNotes++;
                }
            }
            return cumul / totalNotes;
        }

        /// <summary>
        /// Modifie l'adresse de l'élève
        /// </summary>
        /// <param name="pAdresse">Adresse de l'élève</param>
        public void setAdresse(string pAdresse)
        {
            c_Adresse = pAdresse;
        }

        /// <summary>
        /// Retourne l'adresse de l'élève
        /// </summary>
        /// <returns>Adresse de l'élève</returns>
        public string getAdresse()
        {
            return c_Adresse;
        }

        /// <summary>
        /// Ajoute une appréciation dans une matière pour l'élève
        /// </summary>
        /// <param name="pAppreciation">Appréciation à ajouter</param>
        public void ajouterAppreciation(cls_Appreciation pAppreciation)
        {
            c_Appreciations.Add(pAppreciation);
        }

        /// <summary>
        /// Retourne l'appréciation de la matière
        /// </summary>
        /// <param name="pMatiere">Matière</param>
        /// <returns>Appréciation de la matière pour l'élève</returns>
        public cls_Appreciation getAppreciation(cls_Matiere pMatiere)
        {
            cls_Appreciation result = c_Appreciations.Find(
                delegate (cls_Appreciation ap)
                {
                    return ap.getMatiere() == pMatiere;
                }
                );
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Aucune appréciation");
            }
        }

        public cls_Appreciation getAppreciationSemestre(cls_Matiere pMatiere, cls_Semestre pSemestre)
        {
            cls_Appreciation result = c_Appreciations.Find(
                delegate (cls_Appreciation ap)
                {
                    return ap.getMatiere() == pMatiere && ap.getSemestre() == pSemestre;
                }
                );
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Aucune appréciation pour ce semestre et cette matière");
            }
        }
    }
}
