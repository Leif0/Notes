using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Groupe : cls_ObjetBase
    {
        private string c_Libelle;
        private List<cls_Eleve> c_ListeEleve;
        private List<cls_Matiere> c_Matieres;

        /// <summary>
        /// Créer un nouveau groupe
        /// </summary>
        /// <param name="pLibelle">Le libellé du groupe</param>
        public cls_Groupe(string pLibelle, int pId):base(pId)
        {
            setLibelle(pLibelle);
            c_ListeEleve = new List<cls_Eleve>();
            c_Matieres = new List<cls_Matiere>();
        }

        /// <summary>
        /// Modifie le libellé
        /// </summary>
        /// <param name="pLibelle">Libellé du groupe</param>
        public void setLibelle(string pLibelle)
        {
            if (pLibelle != "")
            {
                c_Libelle = pLibelle;
            }
            else
            {
                throw new Exception("Le libelle ne peut pas être vide");
            }
            
        }
        /// <summary>
        /// Retourne le libellé du groupe
        /// </summary>
        /// <returns>Libellé du groupe</returns>
        public string getLibelle()
        {
            return c_Libelle;
        }

        /// <summary>
        /// Retourne la liste des élèves dans ce groupe
        /// </summary>
        /// <returns>Liste des élèves dans ce groupe</returns>
        public List<cls_Eleve> getListeEleve()
        {
            return c_ListeEleve;
        }

        /// <summary>
        /// Ajoute un élève au groupe
        /// </summary>
        /// <param name="pEleve">L'élève à ajouter au groupe</param>
        public void ajouterEleve(cls_Eleve pEleve)
        {
            c_ListeEleve.Add(pEleve);
        }

        /// <summary>
        /// Ajoute une matière au groupe
        /// </summary>
        /// <param name="pMatiere">Matière à ajouter au groupe</param>
        public void ajouterMatiere(cls_Matiere pMatiere)
        {
            c_Matieres.Add(pMatiere);
        }

        /// <summary>
        /// Retourne la matière
        /// </summary>
        /// <returns>Matière</returns>
        public List<cls_Matiere> getMatiere()
        {
            return c_Matieres;
        }
        /// <summary>
        /// Retourne la moyenne du groupe pour une matière pour un semestre
        /// </summary>
        /// <param name="pMatiere">Matière</param>
        /// <param name="pSemestre">Semestre</param>
        /// <returns></returns>
        public double MoyenneGroupePourMatiereSemestre(cls_Matiere pMatiere, cls_Semestre pSemestre)
        {
            double cumul = 0;
            int nombreEleveSansMoyenne = 0;

            foreach (cls_Eleve eleve in c_ListeEleve)
            {
                if (eleve.MoyenneMatiereSemestre(pMatiere, pSemestre) != -1)
                {
                    cumul += eleve.MoyenneMatiereSemestre(pMatiere, pSemestre);
                }
                else
                {
                    nombreEleveSansMoyenne++;
                }
            }
            return cumul / (c_ListeEleve.Count - nombreEleveSansMoyenne);
        }

        public double getMoyenneMinimumPourMatiereSemestre(cls_Matiere pMatiere, cls_Semestre pSemestre)
        {
            double l_MoyenneMinimum = 20;

            foreach (cls_Eleve l_Eleve in c_ListeEleve)
            {
                double l_MoyenneEleve = l_Eleve.MoyenneMatiereSemestre(pMatiere, pSemestre);

                if (l_MoyenneEleve != -1)
                {
                    if (l_MoyenneEleve < l_MoyenneMinimum)
                    {
                        l_MoyenneMinimum = l_MoyenneEleve;
                    }
                }
            }
            return l_MoyenneMinimum;
        }

        public double getMoyenneMaximumPourMatiereSemestre(cls_Matiere pMatiere, cls_Semestre pSemestre)
        {
            double l_MoyenneMaximum = 0;

            foreach (cls_Eleve l_Eleve in c_ListeEleve)
            {
                double l_MoyenneEleve = l_Eleve.MoyenneMatiereSemestre(pMatiere, pSemestre);

                if (l_MoyenneEleve != -1)
                {
                    if (l_MoyenneEleve > l_MoyenneMaximum)
                    {
                        l_MoyenneMaximum = l_MoyenneEleve;
                    }
                }
            }
            return l_MoyenneMaximum;
        }

        /*
        * Non utilisé pour l'instant, remplacé par les moyennes des semestres
        */

        /// <summary>
        /// Retourne la moyenne du groupe pour la matière
        /// </summary>
        /// <param name="pMatiere">Matière</param>
        /// <returns>Moyenne du groupe pour la matière</returns>
        public double MoyenneGroupePourMatiere(cls_Matiere pMatiere)
        {
            double cumul = 0;

            foreach (cls_Eleve eleve in c_ListeEleve)
            {
                cumul += eleve.MoyenneMatiere(pMatiere);
            }
            return cumul / c_ListeEleve.Count;
        }

        public double getMoyenneMinimumPourMatiere(cls_Matiere pMatiere)
        {
            double l_MoyenneMinimum = 20;

            foreach (cls_Eleve l_Eleve in c_ListeEleve)
            {
                double l_MoyenneEleve = l_Eleve.MoyenneMatiere(pMatiere);

                if (l_MoyenneEleve < l_MoyenneMinimum)
                {
                    l_MoyenneMinimum = l_MoyenneEleve;
                }
            }
            return l_MoyenneMinimum;
        }

        public double getMoyenneMaximumPourMatiere(cls_Matiere pMatiere)
        {
            double l_MoyenneMaximum = 0;

            foreach (cls_Eleve l_Eleve in c_ListeEleve)
            {
                double l_MoyenneEleve = l_Eleve.MoyenneMatiere(pMatiere);

                if (l_MoyenneEleve > l_MoyenneMaximum)
                {
                    l_MoyenneMaximum = l_MoyenneEleve;
                }
            }
            return l_MoyenneMaximum;
        }
    }

}
